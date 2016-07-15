namespace HexEditor
{
    partial class UnrealCompactIndex
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Hexadecimal = new System.Windows.Forms.Label();
            this.Decimal = new System.Windows.Forms.Label();
            this.Hex = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Hexadecimal
            // 
            this.Hexadecimal.AutoSize = true;
            this.Hexadecimal.Location = new System.Drawing.Point(12, 48);
            this.Hexadecimal.Name = "Hexadecimal";
            this.Hexadecimal.Size = new System.Drawing.Size(71, 13);
            this.Hexadecimal.TabIndex = 6;
            this.Hexadecimal.Text = "Hexadecimal:";
            // 
            // Decimal
            // 
            this.Decimal.AutoSize = true;
            this.Decimal.Location = new System.Drawing.Point(12, 35);
            this.Decimal.Name = "Decimal";
            this.Decimal.Size = new System.Drawing.Size(48, 13);
            this.Decimal.TabIndex = 5;
            this.Decimal.Text = "Decimal:";
            // 
            // Hex
            // 
            this.Hex.Location = new System.Drawing.Point(12, 12);
            this.Hex.Name = "Hex";
            this.Hex.Size = new System.Drawing.Size(530, 20);
            this.Hex.TabIndex = 4;
            this.Hex.TextChanged += new System.EventHandler(this.Hex_TextChanged);
            // 
            // UnrealCompactIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 86);
            this.Controls.Add(this.Hexadecimal);
            this.Controls.Add(this.Decimal);
            this.Controls.Add(this.Hex);
            this.Name = "UnrealCompactIndex";
            this.Text = "UnrealCompactIndex";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Hexadecimal;
        private System.Windows.Forms.Label Decimal;
        private System.Windows.Forms.TextBox Hex;

    }
}