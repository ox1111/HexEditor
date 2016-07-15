using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HexEditor
{
    [Designer(typeof(ExtendedTabPageDesigner))]
    public class ExtendedTabPage : TabPage
    {
        protected bool _CanClose = true;
        protected Image _Image = null;

        public ExtendedTabPage()
            : base()
        {
        }

        public ExtendedTabPage(string Text)
            : base(Text)
        {
        }

        public bool CanClose
        {
            get
            {
                return this._CanClose;
            }
            set
            {
                if (value == this._CanClose)
                {
                    return;
                }
                this._CanClose = value;
            }
        }

        public Image Image
        {
            get
            {
                return this._Image;
            }
            set
            {
                if (this._Image == value)
                {
                    return;
                }
                this._Image = value;
                this.ImageKey = this._Image == null ? null : "Tab";
            }
        }

        [Browsable(false)]
        public new int ImageIndex
        {
            get
            {
                return base.ImageIndex;
            }
            set
            {
                base.ImageIndex = value;
            }
        }

        [Browsable(false)]
        public new string ImageKey
        {
            get
            {
                return base.ImageKey;
            }
            set
            {
                base.ImageKey = value;
            }
        }
    }
}
