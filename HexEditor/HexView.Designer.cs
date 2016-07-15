namespace HexEditor
{
    partial class HexView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Scrollbar = new System.Windows.Forms.VScrollBar();
            this.Splitter = new HexEditor.ExtendedSplitContainer();
            this.HexGrid = new HexEditor.DataGrid();
            this.TextGrid = new HexEditor.DataGrid();
            this.Splitter.Panel1.SuspendLayout();
            this.Splitter.Panel2.SuspendLayout();
            this.Splitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // Scrollbar
            // 
            this.Scrollbar.Dock = System.Windows.Forms.DockStyle.Right;
            this.Scrollbar.Location = new System.Drawing.Point(778, 0);
            this.Scrollbar.Name = "Scrollbar";
            this.Scrollbar.Size = new System.Drawing.Size(16, 493);
            this.Scrollbar.TabIndex = 0;
            this.Scrollbar.ValueChanged += new System.EventHandler(this.Scrollbar_ValueChanged);
            // 
            // Splitter
            // 
            this.Splitter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Splitter.Location = new System.Drawing.Point(81, 1);
            this.Splitter.Margin = new System.Windows.Forms.Padding(0, 1, 1, 3);
            this.Splitter.Name = "Splitter";
            // 
            // Splitter.Panel1
            // 
            this.Splitter.Panel1.Controls.Add(this.HexGrid);
            // 
            // Splitter.Panel2
            // 
            this.Splitter.Panel2.Controls.Add(this.TextGrid);
            this.Splitter.Size = new System.Drawing.Size(696, 489);
            this.Splitter.SplitterDistance = 403;
            this.Splitter.SplitterWidth = 6;
            this.Splitter.TabIndex = 1;
            // 
            // HexGrid
            // 
            this.HexGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HexGrid.ColumnCount = 32;
            this.HexGrid.ColumnWidth = 16;
            this.HexGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HexGrid.Location = new System.Drawing.Point(0, 0);
            this.HexGrid.Margin = new System.Windows.Forms.Padding(0);
            this.HexGrid.Name = "HexGrid";
            this.HexGrid.RowCount = 32;
            this.HexGrid.SelectionEnd = new System.Drawing.Point(0, 0);
            this.HexGrid.SelectionEndX = 0;
            this.HexGrid.SelectionEndY = 0;
            this.HexGrid.SelectionStart = new System.Drawing.Point(0, 0);
            this.HexGrid.SelectionStartX = 0;
            this.HexGrid.SelectionStartY = 0;
            this.HexGrid.Size = new System.Drawing.Size(403, 489);
            this.HexGrid.TabIndex = 2;
            this.HexGrid.RowCountChanged += new HexEditor.DataGrid.RowCountChangedHandler(this.HexGrid_RowCountChanged);
            this.HexGrid.SelectionChanged += new HexEditor.DataGrid.SelectionChangedHandler(this.HexGrid_SelectionChanged);
            this.HexGrid.ColumnCountChanged += new HexEditor.DataGrid.ColumnCountChangedHandler(this.HexGrid_ColumnCountChanged);
            this.HexGrid.Resize += new System.EventHandler(this.HexGrid_Resize);
            this.HexGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grid_KeyDown);
            // 
            // TextGrid
            // 
            this.TextGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextGrid.ColumnCount = 32;
            this.TextGrid.ColumnWidth = 16;
            this.TextGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextGrid.Location = new System.Drawing.Point(0, 0);
            this.TextGrid.Margin = new System.Windows.Forms.Padding(0);
            this.TextGrid.Name = "TextGrid";
            this.TextGrid.RowCount = 32;
            this.TextGrid.SelectionEnd = new System.Drawing.Point(0, 0);
            this.TextGrid.SelectionEndX = 0;
            this.TextGrid.SelectionEndY = 0;
            this.TextGrid.SelectionStart = new System.Drawing.Point(0, 0);
            this.TextGrid.SelectionStartX = 0;
            this.TextGrid.SelectionStartY = 0;
            this.TextGrid.Size = new System.Drawing.Size(287, 489);
            this.TextGrid.TabIndex = 3;
            this.TextGrid.SelectionChanged += new HexEditor.DataGrid.SelectionChangedHandler(this.TextGrid_SelectionChanged);
            this.TextGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grid_KeyDown);
            // 
            // HexView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Splitter);
            this.Controls.Add(this.Scrollbar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "HexView";
            this.Size = new System.Drawing.Size(794, 493);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.HexView_Paint);
            this.Splitter.Panel1.ResumeLayout(false);
            this.Splitter.Panel2.ResumeLayout(false);
            this.Splitter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar Scrollbar;
        private ExtendedSplitContainer Splitter;
        private DataGrid HexGrid;
        private DataGrid TextGrid;
    }
}
