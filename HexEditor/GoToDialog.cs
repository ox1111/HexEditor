using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HexEditor
{
    public partial class GoToDialog : Form
    {
        public static long LastOffset = 0;
        public static NumberBase LastNumberBase = NumberBase.Decimal;
        public static SeekMode LastSeekMode = SeekMode.Absolute;

        public long _Offset = 0;
        public NumberBase _NumberBase = NumberBase.Decimal;
        public SeekMode _SeekMode = SeekMode.Absolute;

        public GoToDialog()
        {
            InitializeComponent();

            this.DialogResult = DialogResult.Cancel;

            this.Offset = GoToDialog.LastOffset;
            this.NumberBase = GoToDialog.LastNumberBase;
            this.SeekMode = GoToDialog.LastSeekMode;
        }

        public NumberBase NumberBase
        {
            get
            {
                return this._NumberBase;
            }
            set
            {
                if (value == this._NumberBase)
                {
                    return;
                }
                this._NumberBase = value;
                this.Address.NumberBase = value;
                GoToDialog.LastNumberBase = value;
                if (value == NumberBase.Decimal)
                {
                    this.DecimalButton.Checked = true;
                    this.HexadecimalButton.Checked = false;
                }
                else if (value == NumberBase.Hexadecimal)
                {
                    this.DecimalButton.Checked = false;
                    this.HexadecimalButton.Checked = true;
                }
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
                if (value == this._Offset)
                {
                    return;
                }
                this._Offset = value;
                this.Address.Value = value;
                GoToDialog.LastOffset = value;
            }
        }

        public SeekMode SeekMode
        {
            get
            {
                return this._SeekMode;
            }
            set
            {
                if (value == this._SeekMode)
                {
                    return;
                }
                this._SeekMode = value;
                GoToDialog.LastSeekMode = value;
                switch (this._SeekMode)
                {
                    case SeekMode.Absolute:
                        this.AbsoluteButton.Checked = true;
                        this.UpButton.Checked = false;
                        this.DownButton.Checked = false;
                        break;
                    case SeekMode.Up:
                        this.AbsoluteButton.Checked = false;
                        this.UpButton.Checked = true;
                        this.DownButton.Checked = false;
                        break;
                    case SeekMode.Down:
                        this.AbsoluteButton.Checked = false;
                        this.UpButton.Checked = false;
                        this.DownButton.Checked = true;
                        break;
                }
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (this.Visible)
            {
                this.Address.Focus();
                this.Address.SelectionStart = this.Address.Text.Length;
            }
        }

        private void DecimalButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.DecimalButton.Checked)
            {
                this.NumberBase = NumberBase.Decimal;
            }
        }

        private void HexadecimalButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.HexadecimalButton.Checked)
            {
                this.NumberBase = NumberBase.Hexadecimal;
            }
        }

        private void AbsoluteButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.AbsoluteButton.Checked)
            {
                this.SeekMode = SeekMode.Absolute;
            }
        }

        private void UpButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.UpButton.Checked)
            {
                this.SeekMode = SeekMode.Up;
            }
        }

        private void DownButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.DownButton.Checked)
            {
                this.SeekMode = SeekMode.Down;
            }
        }

        private void Address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Cancel_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                this.OK_Click(sender, e);
            }
        }

        private void Address_ValueChanged(NumericTextBox TextBox, long Value)
        {
            this.Offset = Value;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
