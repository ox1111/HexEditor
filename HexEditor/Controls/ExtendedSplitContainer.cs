using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace HexEditor
{
    // Summary:
    //     Represents a control consisting of a movable bar that divides a container's
    //     display area into two resizable panels.
    [Designer("System.Windows.Forms.Design.SplitContainerDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    public class ExtendedSplitContainer : SplitContainer
    {
        protected bool _IsSplitterFixed = false;
        protected bool IsDraggingSplitter = false;

        public ExtendedSplitContainer()
            : base()
        {
        }

        public new bool IsSplitterFixed
        {
            get
            {
                return this._IsSplitterFixed;
            }
            set
            {
                this._IsSplitterFixed = value;
                if (!this.IsDraggingSplitter)
                {
                    base.IsSplitterFixed = value;
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Do not pass event on: this disables the default dragging behaviour.
            // base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                base.IsSplitterFixed = true;
                this.IsDraggingSplitter = true;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (this.IsDraggingSplitter)
            {
                if (this.Orientation == Orientation.Vertical)
                {
                    if (e.X > 0 && e.X < this.Width)
                    {
                        this.SplitterDistance = e.X;
                    }
                }
                else
                {
                    if (e.Y > 0 && e.Y < this.Height)
                    {
                        this.SplitterDistance = e.Y;
                    }
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            base.IsSplitterFixed = this._IsSplitterFixed;
            this.IsDraggingSplitter = false;
        }
    }
}
