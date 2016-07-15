namespace HexEditor
{
    partial class GoToDialog
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
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.DecimalButton = new System.Windows.Forms.RadioButton();
            this.HexadecimalButton = new System.Windows.Forms.RadioButton();
            this.AbsoluteButton = new System.Windows.Forms.RadioButton();
            this.UpButton = new System.Windows.Forms.RadioButton();
            this.DownButton = new System.Windows.Forms.RadioButton();
            this.GoToModeGroupBox = new System.Windows.Forms.GroupBox();
            this.OffsetTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.Address = new HexEditor.NumericTextBox();
            this.GoToModeGroupBox.SuspendLayout();
            this.OffsetTypeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OK.Location = new System.Drawing.Point(318, 137);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(80, 28);
            this.OK.TabIndex = 2;
            this.OK.Text = "Go";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.Location = new System.Drawing.Point(404, 137);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(80, 28);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // DecimalButton
            // 
            this.DecimalButton.AutoSize = true;
            this.DecimalButton.Checked = true;
            this.DecimalButton.Location = new System.Drawing.Point(6, 19);
            this.DecimalButton.Name = "DecimalButton";
            this.DecimalButton.Size = new System.Drawing.Size(63, 17);
            this.DecimalButton.TabIndex = 4;
            this.DecimalButton.TabStop = true;
            this.DecimalButton.Text = "Decimal";
            this.DecimalButton.UseVisualStyleBackColor = true;
            this.DecimalButton.CheckedChanged += new System.EventHandler(this.DecimalButton_CheckedChanged);
            // 
            // HexadecimalButton
            // 
            this.HexadecimalButton.AutoSize = true;
            this.HexadecimalButton.Location = new System.Drawing.Point(6, 42);
            this.HexadecimalButton.Name = "HexadecimalButton";
            this.HexadecimalButton.Size = new System.Drawing.Size(86, 17);
            this.HexadecimalButton.TabIndex = 5;
            this.HexadecimalButton.Text = "Hexadecimal";
            this.HexadecimalButton.UseVisualStyleBackColor = true;
            this.HexadecimalButton.CheckedChanged += new System.EventHandler(this.HexadecimalButton_CheckedChanged);
            // 
            // AbsoluteButton
            // 
            this.AbsoluteButton.AutoSize = true;
            this.AbsoluteButton.Checked = true;
            this.AbsoluteButton.Location = new System.Drawing.Point(6, 19);
            this.AbsoluteButton.Name = "AbsoluteButton";
            this.AbsoluteButton.Size = new System.Drawing.Size(66, 17);
            this.AbsoluteButton.TabIndex = 6;
            this.AbsoluteButton.TabStop = true;
            this.AbsoluteButton.Text = "Absolute";
            this.AbsoluteButton.UseVisualStyleBackColor = true;
            this.AbsoluteButton.CheckedChanged += new System.EventHandler(this.AbsoluteButton_CheckedChanged);
            // 
            // UpButton
            // 
            this.UpButton.AutoSize = true;
            this.UpButton.Location = new System.Drawing.Point(6, 42);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(39, 17);
            this.UpButton.TabIndex = 7;
            this.UpButton.Text = "Up";
            this.UpButton.UseVisualStyleBackColor = true;
            this.UpButton.CheckedChanged += new System.EventHandler(this.UpButton_CheckedChanged);
            // 
            // DownButton
            // 
            this.DownButton.AutoSize = true;
            this.DownButton.Location = new System.Drawing.Point(6, 65);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(53, 17);
            this.DownButton.TabIndex = 8;
            this.DownButton.Text = "Down";
            this.DownButton.UseVisualStyleBackColor = true;
            this.DownButton.CheckedChanged += new System.EventHandler(this.DownButton_CheckedChanged);
            // 
            // GoToModeGroupBox
            // 
            this.GoToModeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GoToModeGroupBox.Controls.Add(this.AbsoluteButton);
            this.GoToModeGroupBox.Controls.Add(this.UpButton);
            this.GoToModeGroupBox.Controls.Add(this.DownButton);
            this.GoToModeGroupBox.Location = new System.Drawing.Point(330, 12);
            this.GoToModeGroupBox.Name = "GoToModeGroupBox";
            this.GoToModeGroupBox.Size = new System.Drawing.Size(154, 93);
            this.GoToModeGroupBox.TabIndex = 9;
            this.GoToModeGroupBox.TabStop = false;
            this.GoToModeGroupBox.Text = "Go To mode";
            // 
            // OffsetTypeGroupBox
            // 
            this.OffsetTypeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.OffsetTypeGroupBox.Controls.Add(this.DecimalButton);
            this.OffsetTypeGroupBox.Controls.Add(this.HexadecimalButton);
            this.OffsetTypeGroupBox.Location = new System.Drawing.Point(12, 12);
            this.OffsetTypeGroupBox.Name = "OffsetTypeGroupBox";
            this.OffsetTypeGroupBox.Size = new System.Drawing.Size(312, 93);
            this.OffsetTypeGroupBox.TabIndex = 10;
            this.OffsetTypeGroupBox.TabStop = false;
            this.OffsetTypeGroupBox.Text = "Offset type";
            // 
            // Address
            // 
            this.Address.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Address.Location = new System.Drawing.Point(12, 111);
            this.Address.Name = "Address";
            this.Address.NumberBase = HexEditor.NumberBase.Decimal;
            this.Address.Size = new System.Drawing.Size(472, 20);
            this.Address.TabIndex = 1;
            this.Address.Text = "0";
            this.Address.Value = ((long)(0));
            this.Address.ValueChanged += new HexEditor.NumericTextBox.ValueChangedHandler(this.Address_ValueChanged);
            this.Address.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Address_KeyDown);
            // 
            // GoToDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 177);
            this.Controls.Add(this.OffsetTypeGroupBox);
            this.Controls.Add(this.GoToModeGroupBox);
            this.Controls.Add(this.Address);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GoToDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Go To...";
            this.GoToModeGroupBox.ResumeLayout(false);
            this.GoToModeGroupBox.PerformLayout();
            this.OffsetTypeGroupBox.ResumeLayout(false);
            this.OffsetTypeGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.RadioButton DecimalButton;
        private System.Windows.Forms.RadioButton HexadecimalButton;
        private System.Windows.Forms.RadioButton AbsoluteButton;
        private System.Windows.Forms.RadioButton UpButton;
        private System.Windows.Forms.RadioButton DownButton;
        private NumericTextBox Address;
        private System.Windows.Forms.GroupBox GoToModeGroupBox;
        private System.Windows.Forms.GroupBox OffsetTypeGroupBox;
    }
}