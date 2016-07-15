using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HexEditor
{
    public partial class HexView : UserControl
    {
        public delegate void SelectionChangedHandler(HexView HexView);
        public event SelectionChangedHandler SelectionChanged;

        public readonly Document Document;
        public long _Offset = 0;
        protected long _SelectionStart = 0;
        protected long _SelectionEnd = 0;

        private bool IgnoreHexGrid = false;
        private bool IgnoreTextGrid = false;
        private bool IgnoreScrollbar = false;

        public HexView(Document Document)
        {
            InitializeComponent();

            this.Document = Document;
            this.UpdateScrollbar();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageDown)
            {
                this.Offset += (long)this.BytesPerScreen;
            }
            else if (e.KeyCode == Keys.PageUp)
            {
                long Offset = this.Offset;
                if ((long)this.BytesPerScreen > Offset)
                {
                    Offset = 0;
                }
                else
                {
                    Offset -= (long)this.BytesPerScreen;
                }
                this.Offset = Offset;
            }
        }

        private void HexView_Paint(object sender, PaintEventArgs e)
        {
            long Offset = this.Offset;
            Point Point = new Point(0, 2);
            while (Point.Y < this.Height)
            {
                e.Graphics.DrawString(Offset.ToString("x8"), this.Font, SystemBrushes.ControlText, Point);
                Offset += this.BytesPerLine;
                Point.Y += this.Font.Height;
            }
        }

        private void HexGrid_ColumnCountChanged(DataGrid Grid, int OldColumnCount, int NewColumnCount)
        {
            this.PopulateGrid();
        }

        private void HexGrid_Resize(object sender, EventArgs e)
        {
            this.HexGrid.RowCount = this.HexGrid.Height / this.HexGrid.RowHeight + 1;
            this.HexGrid.ColumnWidth = TextRenderer.MeasureText("WW", this.Font).Width;
            this.TextGrid.RowCount = this.HexGrid.RowCount;
            this.TextGrid.ColumnWidth = TextRenderer.MeasureText("W", this.Font).Width;
            this.TextGrid.ColumnCount = this.HexGrid.Width / this.HexGrid.ColumnWidth;
            if (this.TextGrid.ColumnCount == 0)
            {
                this.TextGrid.ColumnCount = 1;
            }
            this.HexGrid.ColumnCount = this.TextGrid.ColumnCount;

            this.HexGrid.Invalidate();
            this.TextGrid.Invalidate();
            this.UpdateScrollbar();
        }

        private void HexGrid_RowCountChanged(DataGrid Grid, int OldRowCount, int NewRowCount)
        {
            this.TextGrid.RowCount = NewRowCount;
            this.PopulateGrid();
        }

        private void HexGrid_SelectionChanged(DataGrid Grid)
        {
            if (this.IgnoreHexGrid)
            {
                return;
            }
            this.IgnoreTextGrid = true;
            this.TextGrid.SelectionStart = this.HexGrid.SelectionStart;
            this.TextGrid.SelectionEnd = this.HexGrid.SelectionEnd;
            this.IgnoreTextGrid = false;

            this.SelectionStart = this.Offset + (long)(this.HexGrid.SelectionStartY * this.BytesPerLine + this.HexGrid.SelectionStartX);
            this.SelectionEnd = this.Offset + (long)(this.HexGrid.SelectionEndY * this.BytesPerLine + this.HexGrid.SelectionEndX);
        }

        private void TextGrid_SelectionChanged(DataGrid Grid)
        {
            if (this.IgnoreTextGrid)
            {
                return;
            }
            this.IgnoreHexGrid = true;
            this.HexGrid.SelectionStart = this.TextGrid.SelectionStart;
            this.HexGrid.SelectionEnd = this.TextGrid.SelectionEnd;
            this.IgnoreHexGrid = false;

            this.SelectionStart = this.Offset + (long)(this.TextGrid.SelectionStartY * this.BytesPerLine + this.TextGrid.SelectionStartX);
            this.SelectionEnd = this.Offset + (long)(this.TextGrid.SelectionEndY * this.BytesPerLine + this.TextGrid.SelectionEndX);
        }

        private void Scrollbar_ValueChanged(object sender, EventArgs e)
        {
            if (this.IgnoreScrollbar)
            {
                return;
            }
            this.Offset = (long)(this.Scrollbar.Value / this.BytesPerLine * this.BytesPerLine);
            this.UpdateGridSelection();
        }

        public int BytesPerLine
        {
            get
            {
                return this.HexGrid.ColumnCount;
            }
        }

        public int BytesPerScreen
        {
            get
            {
                return this.BytesPerLine * this.LinesPerScreen;
            }
        }

        public int LinesPerScreen
        {
            get
            {
                return this.Height / this.Font.Height;
            }
        }

        public long Offset
        {
            get
            {
                return this._Offset;
            }
            set
            {
                if (value > (long)this.Document.DataSource.Size)
                {
                    value = (long)(this.Document.DataSource.Size / (ulong)(this.BytesPerLine) * (ulong)(this.BytesPerLine));
                }
                if (this._Offset == value)
                {
                    return;
                }
                this._Offset = value;
                this.PopulateGrid();
                this.UpdateScrollbar();
                this.UpdateGridSelection();
                this.Invalidate();
            }
        }

        protected void PopulateGrid()
        {
            byte[] Buffer = this.Document.DataSource.Read((ulong)this.Offset, (ulong)(this.HexGrid.ColumnCount * this.HexGrid.RowCount));
            for (int y = 0; y < this.HexGrid.RowCount; y++)
            {
                for (int x = 0; x < this.HexGrid.ColumnCount; x++)
                {
                    if (y * this.HexGrid.ColumnCount + x < Buffer.Length)
                    {
                        this.HexGrid.SetCellText(x, y, Buffer[y * this.HexGrid.ColumnCount + x].ToString("x2"));
                        char c = (char)Buffer[y * this.HexGrid.ColumnCount + x];
                        Brush Brush = SystemBrushes.ControlText;
                        if (c == '\r')
                        {
                            this.TextGrid.SetCellText(x, y, "\\r");
                            Brush = Brushes.SlateGray;
                        }
                        else if (c == '\n')
                        {
                            this.TextGrid.SetCellText(x, y, "\\n");
                            Brush = Brushes.SlateGray;
                        }
                        else if (c == '\t')
                        {
                            this.TextGrid.SetCellText(x, y, "\\t");
                            Brush = Brushes.SlateGray;
                        }
                        else
                        {
                            if (c < 32)
                            {
                                c = '.';
                                Brush = Brushes.DarkGray;
                            }
                            this.TextGrid.SetCellText(x, y, c.ToString());
                        }
                        this.HexGrid.SetCellTextBrush(x, y, Brush);
                        this.TextGrid.SetCellTextBrush(x, y, Brush);
                    }
                    else
                    {
                        this.HexGrid.SetCellText(x, y, "");
                        this.TextGrid.SetCellText(x, y, "");
                    }
                }
            }
            this.HexGrid.Invalidate();
            this.TextGrid.Invalidate();
        }

        public Point PositionToGrid(long Position)
        {
            long SignedPosition = Position - this.Offset;
            return new Point((int)(SignedPosition % (long)this.BytesPerLine), (int)(SignedPosition / (long)this.BytesPerLine));
        }

        public long SelectionEnd
        {
            get
            {
                return this._SelectionEnd;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                    this.UpdateGridSelectionEnd(value);
                }
                else if (value > (long)this.Document.DataSource.Size)
                {
                    value = (long)this.Document.DataSource.Size;
                    this.UpdateGridSelectionEnd(value);
                }
                if (this._SelectionEnd == value)
                {
                    return;
                }
                this._SelectionEnd = value;
                Point GridPosition = this.PositionToGrid(value);
                if (GridPosition.X < 0)
                {
                    GridPosition.X += this.BytesPerLine;
                    GridPosition.Y--;
                }
                if (GridPosition.Y < 0)
                {
                    this.Offset -= (long)(this.BytesPerLine * -GridPosition.Y);
                }
                if (GridPosition.Y >= this.HexGrid.RowCount - 1)
                {
                    this.Offset += (long)(this.BytesPerLine * (GridPosition.Y - this.HexGrid.RowCount + 2));
                }
                this.UpdateGridSelectionEnd(value);

                if (this.SelectionChanged != null)
                {
                    this.SelectionChanged(this);
                }
            }
        }

        public long SelectionLength
        {
            get
            {
                return this.SelectionEnd - this.SelectionStart;
            }
            set
            {
                this.SelectionEnd = this.SelectionStart + value;
            }
        }

        public long SelectionStart
        {
            get
            {
                return this._SelectionStart;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                    this.UpdateGridSelectionStart(value);
                }
                else if (value > (long)this.Document.DataSource.Size)
                {
                    value = (long)this.Document.DataSource.Size;
                    this.UpdateGridSelectionStart(value);
                }
                if (value == this._SelectionStart)
                {
                    return;
                }
                this._SelectionStart = value;
                this.UpdateGridSelectionStart(value);

                if (this.SelectionChanged != null)
                {
                    this.SelectionChanged(this);
                }
            }
        }

        protected void UpdateScrollbar()
        {
            this.IgnoreScrollbar = true;
            this.Scrollbar.Maximum = (int)this.Document.DataSource.Size;
            this.Scrollbar.LargeChange = (int)(this.BytesPerLine * this.LinesPerScreen);
            this.Scrollbar.Value = (int)this.Offset;
            this.Scrollbar.Enabled = this.Scrollbar.LargeChange < this.Scrollbar.Maximum;
            this.IgnoreScrollbar = false;
        }

        protected void UpdateGridSelection()
        {
            int StartY = (int)((long)(this.SelectionStart - this.Offset) / (long)this.BytesPerLine);
            int EndY = (int)((long)(this.SelectionEnd - this.Offset) / (long)this.BytesPerLine);
            int StartX = (int)((long)(this.SelectionStart - this.Offset) % (long)this.BytesPerLine);
            int EndX = (int)((long)(this.SelectionEnd - this.Offset) % (long)this.BytesPerLine);

            this.IgnoreHexGrid = true;
            this.IgnoreTextGrid = true;
            this.HexGrid.SelectionStart = new Point(StartX, StartY);
            this.HexGrid.SelectionEnd = new Point(EndX, EndY);
            this.TextGrid.SelectionStart = new Point(StartX, StartY);
            this.TextGrid.SelectionEnd = new Point(EndX, EndY);
            this.IgnoreHexGrid = false;
            this.IgnoreTextGrid = false;
        }

        protected void UpdateGridSelectionEnd(long End)
        {
            int EndY = (int)((long)(End - this.Offset) / (long)this.BytesPerLine);
            int EndX = (int)((long)(End - this.Offset) % (long)this.BytesPerLine);

            this.IgnoreHexGrid = true;
            this.IgnoreTextGrid = true;
            this.HexGrid.SelectionEnd = new Point(EndX, EndY);
            this.TextGrid.SelectionEnd = new Point(EndX, EndY);
            this.IgnoreHexGrid = false;
            this.IgnoreTextGrid = false;
        }

        protected void UpdateGridSelectionStart(long Start)
        {
            int StartY = (int)((long)(Start - this.Offset) / (long)this.BytesPerLine);
            int StartX = (int)((long)(Start - this.Offset) % (long)this.BytesPerLine);

            this.IgnoreHexGrid = true;
            this.IgnoreTextGrid = true;
            this.HexGrid.SelectionStart = new Point(StartX, StartY);
            this.TextGrid.SelectionStart = new Point(StartX, StartY);
            this.IgnoreHexGrid = false;
            this.IgnoreTextGrid = false;
        }
    }
}
