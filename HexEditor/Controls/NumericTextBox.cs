using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace HexEditor
{
    public partial class NumericTextBox : TextBox
    {
        public delegate void ValueChangedHandler(NumericTextBox TextBox, long Value);
        public event ValueChangedHandler ValueChanged;

        protected NumberBase _NumberBase = NumberBase.Decimal;
        protected long _Value = 0;

        public NumericTextBox()
        {
            InitializeComponent();
            this.Value = 0;
        }

        public NumberBase NumberBase
        {
            get
            {
                return this._NumberBase;
            }
            set
            {
                if (this._NumberBase == value)
                {
                    return;
                }
                this._NumberBase = value;
                this.UpdateText();
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.A &&
                e.Control)
            {
                this.SelectAll();
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            bool Block = true;
            if (e.KeyChar >= '0' &&
                e.KeyChar <= '9')
            {
                Block = false;
            }
            else if (this.NumberBase == NumberBase.Hexadecimal)
            {
                if (char.ToLower(e.KeyChar) >= 'a' &&
                    char.ToLower(e.KeyChar) <= 'f')
                {
                    Block = false;
                }
            }
            if (e.KeyChar == '\b')
            {
                Block = false;
            }
            if ((Control.ModifierKeys & Keys.Control) != 0)
            {
                Block = false;
            }
            if (Block)
            {
                e.Handled = true;
            }
            else
            {
                base.OnKeyPress(e);
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            if (this.Text.Length == 0)
            {
                this._Value = 0;
                return;
            }
            string Clean = "";
            int Delta = 0;
            switch (this._NumberBase)
            {
                case NumberBase.Decimal:
                    for (int i = 0; i < this.Text.Length; i++)
                    {
                        if (this.Text[i] >= '0' &&
                            this.Text[i] <= '9')
                        {
                            Clean += this.Text[i];
                        }
                        else if (i < this.SelectionStart)
                        {
                            Delta++;
                        }
                    }
                    if (this.Text != Clean)
                    {
                        Delta = this.SelectionStart - Delta;
                        this.Text = Clean;
                        this.SelectionStart = Delta;
                        return;
                    }
                    long.TryParse(this.Text, out this._Value);
                    break;
                case NumberBase.Hexadecimal:
                    for (int i = 0; i < this.Text.Length; i++)
                    {
                        if ((this.Text[i] >= '0' &&
                             this.Text[i] <= '9') ||
                            (char.ToLower(this.Text[i]) >= 'a' &&
                             char.ToLower(this.Text[i]) <= 'f'))
                        {
                            Clean += this.Text[i];
                        }
                        else if (i < this.SelectionStart)
                        {
                            Delta++;
                        }
                    }
                    if (this.Text != Clean)
                    {
                        Delta = this.SelectionStart - Delta;
                        this.Text = Clean;
                        this.SelectionStart = Delta;
                        return;
                    }
                    long.TryParse(this.Text,NumberStyles.HexNumber, null, out this._Value);
                    break;
            }
            if (this.ValueChanged != null)
            {
                this.ValueChanged(this, this.Value);
            }
        }

        protected void UpdateText()
        {
            switch (this._NumberBase)
            {
                case NumberBase.Decimal:
                    this.Text = this.Value.ToString();
                    break;
                case NumberBase.Hexadecimal:
                    this.Text = this.Value.ToString("x");
                    break;
            }
        }

        public long Value
        {
            get
            {
                return this._Value;
            }
            set
            {
                if (this._Value == value)
                {
                    return;
                }
                this._Value = value;
                this.UpdateText();
            }
        }
    }
}
