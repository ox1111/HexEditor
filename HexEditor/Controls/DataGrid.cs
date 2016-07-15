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
    public partial class DataGrid : UserControl
    {
        public delegate void ColumnCountChangedHandler(DataGrid Grid, int OldColumnCount, int NewColumnCount);
        public delegate void RowCountChangedHandler(DataGrid Grid, int OldRowCount, int NewRowCount);
        public delegate void SelectionChangedHandler(DataGrid Grid);
        public event ColumnCountChangedHandler ColumnCountChanged;
        public event RowCountChangedHandler RowCountChanged;
        public event SelectionChangedHandler SelectionChanged;

        protected int _RowCount = 0;
        protected int _ColumnCount = 0;
        protected int _ColumnWidth = 16;

        protected Point _SelectionStart = new Point();
        protected Point _SelectionEnd = new Point();
        protected bool InSelection = false;

        private List<List<DataCell>> Cells = new List<List<DataCell>>();

        public DataGrid()
        {
            InitializeComponent();

            this.ColumnCount = 32;
            this.RowCount = 32;
        }

        public Point CellFromPoint(Point Position)
        {
            PointF CellF = new PointF((float)Position.X / (float)this.ColumnWidth, (float)Position.Y / (float)this.RowHeight);
            if (CellF.X < 0)
            {
                CellF.X = 0;
            }
            if (CellF.X >= this.ColumnCount)
            {
                CellF.X = this.ColumnCount - 1;
            }
            return new Point((int)Math.Floor(CellF.X), (int)Math.Floor(CellF.Y));
        }

        public int ColumnCount
        {
            get
            {
                return this._ColumnCount;
            }
            set
            {
                if (this._ColumnCount == value)
                {
                    return;
                }
                foreach (List<DataCell> Row in this.Cells)
                {
                    while (Row.Count < value)
                    {
                        Row.Add(new DataCell());
                    }
                    Row.RemoveRange(value, Row.Count - value);
                }
                int LastColumnCount = this._ColumnCount;
                this._ColumnCount = value;
                if (this.ColumnCountChanged != null)
                {
                    this.ColumnCountChanged(this, LastColumnCount, value);
                }
                this.Invalidate();
            }
        }

        public int ColumnWidth
        {
            get
            {
                return this._ColumnWidth;
            }
            set
            {
                this._ColumnWidth = value;
            }
        }

        public DataCell GetCell(int x, int y)
        {
            return this.Cells[y][x];
        }

        public Rectangle GetCellRect(int x, int y)
        {
            return new Rectangle(x * this.ColumnWidth, y * this.RowHeight, this.ColumnWidth, this.RowHeight);
        }

        public string GetCellText(int x, int y)
        {
            return this.Cells[y][x].Text;
        }

        protected override bool IsInputKey(Keys keyData)
        {
            if ((keyData & Keys.Shift) != 0)
            {
                keyData &= ~Keys.Shift;
            }
            switch (keyData)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    return true;
            }
            return base.IsInputKey(keyData);
        }

        protected virtual void OnDrawCell(Graphics g, int x, int y, Rectangle CellRect)
        {
            DataCell Cell = this.GetCell(x, y);
            g.DrawString(Cell.Text, this.Font, Cell.TextBrush, CellRect.Location);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            bool SelectionChanged = false;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    SelectionChanged = true;
                    this.SelectionEndY--;
                    break;
                case Keys.Down:
                    SelectionChanged = true;
                    this.SelectionEndY++;
                    break;
                case Keys.Left:
                    SelectionChanged = true;
                    if (this.SelectionEndX == 0)
                    {
                        this.SelectionEnd = new Point(this.ColumnCount - 1, this.SelectionEndY - 1);
                        break;
                    }
                    this.SelectionEndX--;
                    break;
                case Keys.Right:
                    SelectionChanged = true;
                    if (this.SelectionEndX == this.ColumnCount - 1)
                    {
                        this.SelectionEnd = new Point(0, this.SelectionEndY + 1);
                        break;
                    }
                    this.SelectionEndX++;
                    break;
            }
            if (SelectionChanged && !e.Shift)
            {
                this.SelectionStart = this.SelectionEnd;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if ((e.Button & MouseButtons.Left) != 0)
            {
                Point Cell = this.CellFromPoint(e.Location);
                this.SelectionEnd = Cell;
                this.SelectionStart = Cell;
                this.InSelection = true;
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.InSelection = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (InSelection)
            {
                Point Cell = this.CellFromPoint(e.Location);
                this.SelectionEnd = Cell;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            this.InSelection = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle CellRect = new Rectangle(0, 0, this.ColumnWidth, this.RowHeight);

            // Draw selection
            Point End = this.SelectionEnd;
            Point Start = this.SelectionStart;
            if (End.Y < Start.Y ||
                (End.Y == Start.Y &&
                 End.X < Start.X))
            {
                Point Temp = End;
                End = Start;
                Start = Temp;
            }
            Rectangle EndRect = this.GetCellRect(End.X, End.Y);
            Rectangle StartRect = this.GetCellRect(Start.X, Start.Y);

            int DeltaY = End.Y - Start.Y - 1;
            Rectangle TopLeft = this.GetCellRect(0, Start.Y + 1);
            Rectangle BottomRight = this.GetCellRect(this.ColumnCount - 1, End.Y - 1);
            if (DeltaY > 0)
            {
                Rectangle Fill = new Rectangle(TopLeft.X, TopLeft.Y, BottomRight.Right, BottomRight.Bottom - TopLeft.Y);
                e.Graphics.FillRectangle(Brushes.LightBlue, Fill);
            }
            if (DeltaY >= 0)
            {
                // Both endpoints are on separate lines.
                Rectangle Fill = new Rectangle(StartRect.X, StartRect.Y, BottomRight.Right - StartRect.X, StartRect.Height);
                e.Graphics.FillRectangle(Brushes.LightBlue, Fill);
                Fill = new Rectangle(TopLeft.X, EndRect.Y, EndRect.Right, EndRect.Height);
                e.Graphics.FillRectangle(Brushes.LightBlue, Fill);
            }
            else
            {
                Rectangle Fill = new Rectangle(StartRect.X, StartRect.Y, EndRect.Right - StartRect.X, EndRect.Bottom - StartRect.Y);
                e.Graphics.FillRectangle(Brushes.LightBlue, Fill);
            }
            e.Graphics.FillRectangle(Brushes.LightBlue, StartRect);
            e.Graphics.FillRectangle(Brushes.LightBlue, EndRect);

            for (int y = 0; y < this.RowCount; y++)
            {
                CellRect.Y = y * this.RowHeight;
                for (int x = 0; x < this.ColumnCount; x++)
                {
                    CellRect.X = x * this.ColumnWidth;
                    this.OnDrawCell(e.Graphics, x, y, CellRect);
                }
            }
        }

        public int RowCount
        {
            get
            {
                return this._RowCount;
            }
            set
            {
                if (this._RowCount == value)
                {
                    return;
                }
                while (this.Cells.Count < value)
                {
                    List<DataCell> Row = new List<DataCell>();
                    this.Cells.Add(Row);
                    while (Row.Count < this.ColumnCount)
                    {
                        Row.Add(new DataCell());
                    }
                }
                this.Cells.RemoveRange(value, this.Cells.Count - value);
                int LastRowCount = this._RowCount;
                this._RowCount = value;
                if (this.RowCountChanged != null)
                {
                    this.RowCountChanged(this, LastRowCount, value);
                }
                this.Invalidate();
            }
        }

        public int RowHeight
        {
            get
            {
                return this.Font.Height;
            }
        }

        public Point SelectionEnd
        {
            get
            {
                return this._SelectionEnd;
            }
            set
            {
                if (this._SelectionEnd == value)
                {
                    return;
                }
                this._SelectionEnd = value;
                if (this.SelectionChanged != null)
                {
                    this.SelectionChanged(this);
                }
                this.Invalidate();
            }
        }

        public int SelectionEndX
        {
            get
            {
                return this._SelectionEnd.X;
            }
            set
            {
                if (this._SelectionEnd.X == value)
                {
                    return;
                }
                this._SelectionEnd.X = value;
                if (this.SelectionChanged != null)
                {
                    this.SelectionChanged(this);
                }
                this.Invalidate();
            }
        }

        public int SelectionEndY
        {
            get
            {
                return this._SelectionEnd.Y;
            }
            set
            {
                if (this._SelectionEnd.Y == value)
                {
                    return;
                }
                this._SelectionEnd.Y = value;
                if (this.SelectionChanged != null)
                {
                    this.SelectionChanged(this);
                }
                this.Invalidate();
            }
        }

        public Point SelectionStart
        {
            get
            {
                return this._SelectionStart;
            }
            set
            {
                if (this._SelectionStart == value)
                {
                    return;
                }
                this._SelectionStart = value;
                if (this.SelectionChanged != null)
                {
                    this.SelectionChanged(this);
                }
                this.Invalidate();
            }
        }

        public int SelectionStartX
        {
            get
            {
                return this._SelectionStart.X;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                if (this._SelectionStart.X == value)
                {
                    return;
                }
                this._SelectionStart.X = value;
                if (this.SelectionChanged != null)
                {
                    this.SelectionChanged(this);
                }
                this.Invalidate();
            }
        }

        public int SelectionStartY
        {
            get
            {
                return this._SelectionStart.Y;
            }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                if (this._SelectionStart.Y == value)
                {
                    return;
                }
                this._SelectionStart.Y = value;
                if (this.SelectionChanged != null)
                {
                    this.SelectionChanged(this);
                }
                this.Invalidate();
            }
        }

        public void SetCellText(int x, int y, string Text)
        {
            this.Cells[y][x].Text = Text;
        }

        public void SetCellTextBrush(int x, int y, Brush Brush)
        {
            this.Cells[y][x].TextBrush = Brush;
        }

        public void ShiftRows(int Offset)
        {
            if (Offset < 0)
            {
                Offset = -Offset;
                this.Cells.RemoveRange(0, Offset);
                for (int i = 0; i < Offset; i++)
                {
                    List<DataCell> Row = new List<DataCell>();
                    while (Row.Count < this.ColumnCount)
                    {
                        Row.Add(new DataCell());
                    }
                    this.Cells.Add(Row);
                }
            }
            else
            {
                for (int i = 0; i < Offset; i++)
                {
                    List<DataCell> Row = new List<DataCell>();
                    while (Row.Count < this.ColumnCount)
                    {
                        Row.Add(new DataCell());
                    }
                    this.Cells.Insert(0, Row);
                }
            }
        }
    }
}
