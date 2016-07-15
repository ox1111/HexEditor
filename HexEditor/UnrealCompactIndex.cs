using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace HexEditor
{
    public partial class UnrealCompactIndex : Form
    {
        public UnrealCompactIndex()
        {
            InitializeComponent();
        }

        private void Hex_TextChanged(object sender, EventArgs e)
        {
            string Text = this.Hex.Text.Replace(" ", "");
            List<byte> Bytes = new List<byte>();
            while (Text.Length > 0)
            {
                string Substring = Text;
                if (Substring.Length > 2)
                {
                    Substring = Substring.Substring(0, 2);
                }
                byte Byte = 0;
                byte.TryParse(Substring, NumberStyles.HexNumber, null, out Byte);
                Bytes.Add(Byte);
                Text = Text.Substring(Substring.Length);
            }

            int ByteIndex = 0;
            int Value = 0;
            byte B = Bytes[ByteIndex];
            int BitsRead = 0;
            bool Negative = ((B & 0x80) != 0) ? true : false;
            bool Continued = ((B & 0x40) != 0) ? true : false;
            Value = B & 0x3F;

            BitsRead = 6;
            ByteIndex++;
            while (Continued && ByteIndex < Bytes.Count)
            {
                B = Bytes[ByteIndex];
                Continued = ((B & 0x80) != 0) ? true : false;
                Value |= B << BitsRead;
                ByteIndex++;
                BitsRead += 7;
            }
            if (Negative)
            {
                Value = -Value;
            }

            this.Decimal.Text = "Decimal: " + Value.ToString();
            this.Hexadecimal.Text = "Hexadecimal: " + Value.ToString("X");
        }
    }
}
