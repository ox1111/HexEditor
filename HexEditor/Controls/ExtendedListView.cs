using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace VirtualLan
{
    public partial class ExtendedListView : ListView
    {
        private const int WM_CREATE = 0x00000001;
        private const int WM_PAINT = 0x0000000F;
        private const int WM_ERASEBKGND = 0x00000014;
        private bool PaintSuspended = false;

        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private extern static int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

        public ExtendedListView()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        public void ResumePaint()
        {
            this.PaintSuspended = false;
            this.Refresh();
        }

        public void SuspendPaint()
        {
            this.PaintSuspended = true;
        }

        protected override void WndProc(ref Message Message)
        {
            if (Message.Msg == ExtendedListView.WM_CREATE)
            {
                ExtendedListView.SetWindowTheme(this.Handle, "Explorer", null);
            }
            if (Message.Msg != ExtendedListView.WM_ERASEBKGND)
            {
                if (Message.Msg != ExtendedListView.WM_PAINT ||
                    !this.PaintSuspended)
                {
                    base.WndProc(ref Message);
                }
            }
        }
    }
}
