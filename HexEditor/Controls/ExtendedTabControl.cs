using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Drawing.Drawing2D;

namespace HexEditor
{
    [Designer(typeof(ExtendedTabControlDesigner))]
    public partial class ExtendedTabControl : TabControl
    {
        public delegate void TabClosedEventHandler(object sender, TabPage Tab, int TabIndex);
        public event TabClosedEventHandler TabClosed;

        private const int WM_PAINT = 0x0000000F;
        private bool PaintSuspended = false;

        protected int HotTabIndex = -1;
        protected bool HoveredOnCross = false;
        protected int PressedCrossIndex = -1;
        protected bool PressedOnCross = false;
        protected int DragInsertionIndex = -1;

        private Font Webdings = new Font("Webdings", 7.5f);
        private ExtendedTabCollection ExtendedTabCollection = null;

        public ExtendedTabControl()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.UserPaint, true);
            // this.SetStyle(ControlStyles.UserPaint, false);

            this.ExtendedTabCollection = new ExtendedTabCollection(this);
            base.ImageList = this.ImageList;
        }

        public void CloseTab(int TabIndex)
        {
            if (this.TabClosed != null)
            {
                this.TabClosed(this, this.TabPages[TabIndex], TabIndex);
            }
            this.TabPages.RemoveAt(TabIndex);
            if (TabIndex >= this.TabCount)
            {
                TabIndex = this.TabCount - 1;
            }
            this.SelectedIndex = TabIndex;
        }

        [Browsable(false)]
        public Rectangle ContentRect
        {
            get
            {
                Rectangle ContentRectangle = this.ClientRectangle;
                if (this.Alignment == TabAlignment.Top)
                {
                    ContentRectangle.Y = this.ItemSize.Height;
                    ContentRectangle.Width += 2;
                    ContentRectangle.Height -= this.ItemSize.Height - 1;
                }
                else if (this.Alignment == TabAlignment.Bottom)
                {
                    ContentRectangle.Height -= this.ItemSize.Height - 1;
                }
                return ContentRectangle;
            }
        }

        public int GetTabIndex(TabPage Tab)
        {
            for (int i = 0; i < this.TabCount; i++)
            {
                if (this.TabPages[i] == Tab)
                {
                    return i;
                }
            }
            return -1;
        }

        public Rectangle GetTabCrossRect(int TabIndex)
        {
            Rectangle TabRect = this.GetTabRect(TabIndex);
            if (TabIndex == this.SelectedIndex)
            {
                TabRect.Y -= 2;
                TabRect.Height += 2;
            }

            Rectangle CrossRect = new Rectangle();
            CrossRect.X = TabRect.Right - 16;
            CrossRect.Y = TabRect.Y + 7;
            CrossRect.Width = 12;
            CrossRect.Height = 12;
            return CrossRect;
        }

        public Rectangle GetSelectedTabRect(int TabIndex)
        {
            Rectangle Rect = this.GetTabRect(TabIndex);
            Rect.X -= 2;
            Rect.Width += 4;
            if (this.Alignment == TabAlignment.Top)
            {
                Rect.Y -= 2;
                Rect.Height += 2;
            }
            else
            {
                Rect.Height += 2;
            }
            return Rect;
        }

        public new Rectangle GetTabRect(int TabIndex)
        {
            if (TabIndex < 0 ||
                TabIndex > this.TabCount)
            {
                return Rectangle.Empty;
            }
            if (TabIndex == this.TabCount)
            {
                if (this.TabCount == 0)
                {
                    return new Rectangle(new Point(0, 2), new Size(this.ClientRectangle.Width, this.ItemSize.Height));
                }
                Rectangle TabRect = base.GetTabRect(TabIndex - 1);
                TabRect.X = TabRect.X + TabRect.Width;
                TabRect.Width = this.ClientRectangle.Width - TabRect.X;
                return TabRect;
            }
            return base.GetTabRect(TabIndex);
        }

        public Rectangle GetTabTextRect(int TabIndex)
        {
            Rectangle Rect;
            if (this.SelectedIndex == TabIndex)
            {
                Rect = this.GetSelectedTabRect(TabIndex);
                Rect.X += 2;
            }
            else
            {
                Rect = this.GetTabRect(TabIndex);
            }
            if (this.TabPages[TabIndex].Image != null)
            {
                Rect.X += 16;
            }
            Rect.X += 4;
            return Rect;
        }

        public new ImageList ImageList
        {
            get
            {
                return this.Images;
            }
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            base.OnDragDrop(drgevent);
            if (this.DragInsertionIndex != -1 &&
                drgevent.Data.GetDataPresent(typeof(ExtendedTabPage)))
            {
                ExtendedTabPage Tab = (ExtendedTabPage)drgevent.Data.GetData(typeof(ExtendedTabPage));
                int TabIndex = this.GetTabIndex(Tab);
                if (TabIndex != -1)
                {
                    this.SuspendPaint();
                    this.TabPages.Remove(Tab);
                    if (TabIndex < this.DragInsertionIndex)
                    {
                        this.DragInsertionIndex--;
                    }
                    this.TabPages.Insert(this.DragInsertionIndex, Tab);
                    this.SelectedTab = Tab;
                    this.ResumePaint();
                }
            }

            this.DragInsertionIndex = -1;
            this.Invalidate(false);
        }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            base.OnDragEnter(drgevent);

            if (!drgevent.Data.GetDataPresent(typeof(ExtendedTabPage)))
            {
                drgevent.Effect = DragDropEffects.None;
            }
            else
            {
                drgevent.Effect = DragDropEffects.Move;
            }
        }

        protected override void OnDragLeave(EventArgs e)
        {
            base.OnDragLeave(e);
            this.DragInsertionIndex = -1;
            this.Invalidate(false);
        }

        protected override void OnDragOver(DragEventArgs drgevent)
        {
            base.OnDragOver(drgevent);

            Point Position = this.PointToClient(new Point(drgevent.X, drgevent.Y));
            int TabIndex = this.TabIndexFromPoint(Position);
            if (TabIndex == -1 &&
                Position.Y <= this.ItemSize.Height)
            {
                TabIndex = this.TabCount - 1;
            }
            if (TabIndex == -1)
            {
                this.DragInsertionIndex = -1;
                return;
            }

            Rectangle TabRect = this.GetTabRect(TabIndex);
            float X = Position.X - TabRect.X;
            float Width = TabRect.Width * 0.5f;
            if (X > Width)
            {
                TabIndex++;
            }

            this.DragInsertionIndex = TabIndex;
            this.Invalidate(false);
        }

        protected virtual void OnDrawTab(Graphics g, int TabIndex)
        {
            ExtendedTabPage Tab = this.TabPages[TabIndex];
            Rectangle TabRect = this.GetTabRect(TabIndex);

            VisualStyleRenderer Renderer = new VisualStyleRenderer(VisualStyleElement.Tab.TabItem.Normal);

            StringFormat StringFormat = new StringFormat();
            StringFormat.Alignment = StringAlignment.Near;
            StringFormat.LineAlignment = StringAlignment.Center;

            if (this.SelectedTab == Tab)
            {
                TabRect = this.GetSelectedTabRect(TabIndex);
                Renderer.SetParameters(Renderer.Class, Renderer.Part, (int)TabItemState.Selected);
            }
            else if (TabIndex == this.HotTabIndex)
            {
                Renderer.SetParameters(Renderer.Class, Renderer.Part, (int)TabItemState.Hot);
            }
            Renderer.DrawBackground(g, TabRect);

            if (Tab.Image != null)
            {
                g.DrawImage(Tab.Image, TabRect.Location + new Size(4, 4));
            }
            g.DrawString(Tab.Text, this.Font, SystemBrushes.ControlText, this.GetTabTextRect (TabIndex), StringFormat);

            if (Tab.CanClose)
            {
                StringFormat.LineAlignment = StringAlignment.Near;
                Rectangle CrossRect = this.GetTabCrossRect(TabIndex);
                CrossRect.Y -= 3;
                if (TabIndex != this.SelectedIndex)
                {
                    CrossRect.Y -= 1;
                }

                int HighlightedCrossIndex = -1;
                if (this.HoveredOnCross)
                {
                    HighlightedCrossIndex = this.HotTabIndex;
                }
                if (this.PressedOnCross)
                {
                    HighlightedCrossIndex = this.PressedCrossIndex;
                }
                if (TabIndex == HighlightedCrossIndex)
                {
                    g.DrawString("r", this.Webdings, SystemBrushes.ControlText, CrossRect, StringFormat);
                }
                else
                {
                    g.DrawString("r", this.Webdings, Brushes.Gray, CrossRect, StringFormat);
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if ((e.Button & MouseButtons.Left) != 0 &&
                this.HoveredOnCross)
            {
                this.PressedOnCross = true;
                this.PressedCrossIndex = this.HotTabIndex;
                this.Invalidate(false);
            }

            if ((e.Button & MouseButtons.Right) != 0)
            {
                if (this.HotTabIndex != -1)
                {
                    this.SelectedIndex = this.HotTabIndex;
                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.HotTabIndex = -1;
            this.HoveredOnCross = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            this.HotTabIndex = this.TabIndexFromPoint(e.Location);
            if (this.HotTabIndex != -1 &&
                this.TabPages[this.HotTabIndex].CanClose &&
                this.GetTabCrossRect(this.HotTabIndex).Contains(e.Location))
            {
                this.HoveredOnCross = true;
                this.Invalidate(false);
            }
            else
            {
                if (this.HoveredOnCross &&
                    (e.Button & MouseButtons.Left) == 0)
                {
                    this.HoveredOnCross = false;
                    this.Invalidate(false);
                }
            }

            if (!this.AllowDrop ||
                this.HoveredOnCross)
            {
                return;
            }
            if ((e.Button & MouseButtons.Left) != 0)
            {
                TabPage Tab = this.TabFromPoint(e.Location);
                if (Tab != null)
                {
                    this.DoDragDrop(Tab, DragDropEffects.All);
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (!this.DesignMode)
            {
                if (this.PressedOnCross &&
                    this.HotTabIndex != -1 &&
                    this.HotTabIndex == this.PressedCrossIndex)
                {
                    Rectangle CrossRect = this.GetTabCrossRect(this.HotTabIndex);
                    if (CrossRect.Contains(e.Location))
                    {
                        this.CloseTab(this.HotTabIndex);
                    }
                }
            }
            this.HoveredOnCross = false;
            this.PressedOnCross = false;
            this.PressedCrossIndex = -1;
            this.Invalidate(false);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            for (int i = 0; i < this.TabCount; i++)
            {
                ExtendedTabPage Tab = this.TabPages[i];
                if (i == this.SelectedIndex)
                {
                    continue;
                }
                this.OnDrawTab(e.Graphics, i);
            }

            VisualStyleRenderer Renderer = new VisualStyleRenderer(VisualStyleElement.Tab.Pane.Normal);
            Renderer.DrawBackground(e.Graphics, this.ContentRect);

            if (this.SelectedTab != null)
            {
                this.OnDrawTab(e.Graphics, this.SelectedIndex);
            }

            if (this.DragInsertionIndex != -1)
            {
                Rectangle TabRect = this.GetTabRect(this.DragInsertionIndex);
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                if (this.Alignment == TabAlignment.Top)
                {
                    e.Graphics.FillPolygon(Brushes.Black, new PointF[] { new PointF(TabRect.X - 4, TabRect.Y - 2.5f), new PointF(TabRect.X + 4, TabRect.Y - 2.5f), new PointF(TabRect.X, TabRect.Y + 2) });
                }
                else
                {
                    e.Graphics.FillPolygon(Brushes.Black, new PointF[] { new PointF(TabRect.X - 4, TabRect.Bottom + 2.5f), new PointF(TabRect.X + 4, TabRect.Bottom + 2.5f), new PointF(TabRect.X, TabRect.Bottom - 2) });
                }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        protected override void OnSelecting(TabControlCancelEventArgs e)
        {
            base.OnSelecting(e);
            if (e.TabPageIndex == this.HotTabIndex &&
                this.HoveredOnCross)
            {
                e.Cancel = true;
            }
        }

        public void ResumePaint()
        {
            this.PaintSuspended = false;
            this.Invalidate(false);
        }

        public new ExtendedTabPage SelectedTab
        {
            get
            {
                return (ExtendedTabPage)base.SelectedTab;
            }
            set
            {
                base.SelectedTab = value;
            }
        }

        public void SuspendPaint()
        {
            this.PaintSuspended = true;
        }

        public int TabIndexFromPoint(Point p)
        {
            for (int i = 0; i < this.TabCount; i++)
            {
                if (this.GetTabRect(i).Contains(p))
                {
                    return i;
                }
            }
            return -1;
        }

        public TabPage TabFromPoint(Point p)
        {
            for (int i = 0; i < this.TabCount; i++)
            {
                if (this.GetTabRect(i).Contains(p))
                {
                    return this.TabPages[i];
                }
            }
            return null;
        }

        public new ExtendedTabCollection TabPages
        {
            get
            {
                return this.ExtendedTabCollection;
            }
        }

        protected override void WndProc(ref Message Message)
        {
            if (Message.Msg != ExtendedTabControl.WM_PAINT ||
                !this.PaintSuspended)
            {
                base.WndProc(ref Message);
            }
        }
    }
}
