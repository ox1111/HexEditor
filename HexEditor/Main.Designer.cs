namespace HexEditor
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.TabMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CloseCurrentTabMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseAllButCurrentTabMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DockingContainer = new System.Windows.Forms.ToolStripContainer();
            this.Status = new System.Windows.Forms.StatusStrip();
            this.AddressStatusPanel = new System.Windows.Forms.ToolStripStatusLabel();
            this.VerticalSplitter = new HexEditor.ExtendedSplitContainer();
            this.Tabs = new HexEditor.ExtendedTabControl();
            this.RightToolsTab = new HexEditor.ExtendedTabControl();
            this.DataInterpreterTab = new HexEditor.ExtendedTabPage();
            this.DataInterpreterView = new VirtualLan.ExtendedListView();
            this.DataInterpreterTypeColumn = new System.Windows.Forms.ColumnHeader();
            this.DataInterpreterValueColumn = new System.Windows.Forms.ColumnHeader();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.NewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.GoToMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.TransformMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NOTMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SubstringMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeflateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StandardToolbar = new System.Windows.Forms.ToolStrip();
            this.NewToolbarItem = new System.Windows.Forms.ToolStripButton();
            this.OpenToolbarItem = new System.Windows.Forms.ToolStripButton();
            this.SaveToolbarItem = new System.Windows.Forms.ToolStripButton();
            this.SaveAllToolbarItem = new System.Windows.Forms.ToolStripButton();
            this.Workspace = new HexEditor.Workspace();
            this.TabMenu.SuspendLayout();
            this.DockingContainer.BottomToolStripPanel.SuspendLayout();
            this.DockingContainer.ContentPanel.SuspendLayout();
            this.DockingContainer.TopToolStripPanel.SuspendLayout();
            this.DockingContainer.SuspendLayout();
            this.Status.SuspendLayout();
            this.VerticalSplitter.Panel1.SuspendLayout();
            this.VerticalSplitter.Panel2.SuspendLayout();
            this.VerticalSplitter.SuspendLayout();
            this.RightToolsTab.SuspendLayout();
            this.DataInterpreterTab.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.StandardToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabMenu
            // 
            this.TabMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CloseCurrentTabMenuItem,
            this.CloseAllButCurrentTabMenuItem});
            this.TabMenu.Name = "TabMenu";
            this.TabMenu.Size = new System.Drawing.Size(162, 48);
            this.TabMenu.Opening += new System.ComponentModel.CancelEventHandler(this.TabMenu_Opening);
            // 
            // CloseCurrentTabMenuItem
            // 
            this.CloseCurrentTabMenuItem.Name = "CloseCurrentTabMenuItem";
            this.CloseCurrentTabMenuItem.Size = new System.Drawing.Size(161, 22);
            this.CloseCurrentTabMenuItem.Text = "Close";
            this.CloseCurrentTabMenuItem.Click += new System.EventHandler(this.CloseCurrentTabMenuItem_Click);
            // 
            // CloseAllButCurrentTabMenuItem
            // 
            this.CloseAllButCurrentTabMenuItem.Name = "CloseAllButCurrentTabMenuItem";
            this.CloseAllButCurrentTabMenuItem.Size = new System.Drawing.Size(161, 22);
            this.CloseAllButCurrentTabMenuItem.Text = "Close all but this";
            // 
            // DockingContainer
            // 
            this.DockingContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // DockingContainer.BottomToolStripPanel
            // 
            this.DockingContainer.BottomToolStripPanel.Controls.Add(this.Status);
            // 
            // DockingContainer.ContentPanel
            // 
            this.DockingContainer.ContentPanel.Controls.Add(this.VerticalSplitter);
            this.DockingContainer.ContentPanel.Size = new System.Drawing.Size(884, 593);
            this.DockingContainer.Location = new System.Drawing.Point(0, 0);
            this.DockingContainer.Name = "DockingContainer";
            this.DockingContainer.Size = new System.Drawing.Size(884, 664);
            this.DockingContainer.TabIndex = 7;
            this.DockingContainer.Text = "toolStripContainer1";
            // 
            // DockingContainer.TopToolStripPanel
            // 
            this.DockingContainer.TopToolStripPanel.Controls.Add(this.MainMenu);
            this.DockingContainer.TopToolStripPanel.Controls.Add(this.StandardToolbar);
            // 
            // Status
            // 
            this.Status.Dock = System.Windows.Forms.DockStyle.None;
            this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddressStatusPanel});
            this.Status.Location = new System.Drawing.Point(0, 0);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(884, 22);
            this.Status.TabIndex = 6;
            this.Status.Text = "statusStrip1";
            // 
            // AddressStatusPanel
            // 
            this.AddressStatusPanel.Name = "AddressStatusPanel";
            this.AddressStatusPanel.Size = new System.Drawing.Size(52, 17);
            this.AddressStatusPanel.Text = "Address:";
            // 
            // VerticalSplitter
            // 
            this.VerticalSplitter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.VerticalSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.VerticalSplitter.Location = new System.Drawing.Point(3, 3);
            this.VerticalSplitter.Name = "VerticalSplitter";
            // 
            // VerticalSplitter.Panel1
            // 
            this.VerticalSplitter.Panel1.Controls.Add(this.Tabs);
            // 
            // VerticalSplitter.Panel2
            // 
            this.VerticalSplitter.Panel2.Controls.Add(this.RightToolsTab);
            this.VerticalSplitter.Size = new System.Drawing.Size(878, 587);
            this.VerticalSplitter.SplitterDistance = 676;
            this.VerticalSplitter.TabIndex = 1;
            // 
            // Tabs
            // 
            this.Tabs.AllowDrop = true;
            this.Tabs.ContextMenuStrip = this.TabMenu;
            this.Tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tabs.Location = new System.Drawing.Point(0, 0);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.SelectedTab = null;
            this.Tabs.Size = new System.Drawing.Size(676, 587);
            this.Tabs.TabIndex = 0;
            // 
            // RightToolsTab
            // 
            this.RightToolsTab.AllowDrop = true;
            this.RightToolsTab.Controls.Add(this.DataInterpreterTab);
            this.RightToolsTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightToolsTab.Location = new System.Drawing.Point(0, 0);
            this.RightToolsTab.Name = "RightToolsTab";
            this.RightToolsTab.SelectedIndex = 0;
            this.RightToolsTab.SelectedTab = this.DataInterpreterTab;
            this.RightToolsTab.Size = new System.Drawing.Size(198, 587);
            this.RightToolsTab.TabIndex = 0;
            // 
            // DataInterpreterTab
            // 
            this.DataInterpreterTab.CanClose = false;
            this.DataInterpreterTab.Controls.Add(this.DataInterpreterView);
            this.DataInterpreterTab.Image = ((System.Drawing.Image)(resources.GetObject("DataInterpreterTab.Image")));
            this.DataInterpreterTab.ImageKey = "Tab";
            this.DataInterpreterTab.Location = new System.Drawing.Point(4, 25);
            this.DataInterpreterTab.Name = "DataInterpreterTab";
            this.DataInterpreterTab.Padding = new System.Windows.Forms.Padding(3);
            this.DataInterpreterTab.Size = new System.Drawing.Size(190, 558);
            this.DataInterpreterTab.TabIndex = 0;
            this.DataInterpreterTab.Text = "Data Interpreter";
            this.DataInterpreterTab.UseVisualStyleBackColor = true;
            // 
            // DataInterpreterView
            // 
            this.DataInterpreterView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DataInterpreterTypeColumn,
            this.DataInterpreterValueColumn});
            this.DataInterpreterView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataInterpreterView.Location = new System.Drawing.Point(3, 3);
            this.DataInterpreterView.Name = "DataInterpreterView";
            this.DataInterpreterView.Size = new System.Drawing.Size(184, 552);
            this.DataInterpreterView.TabIndex = 0;
            this.DataInterpreterView.UseCompatibleStateImageBehavior = false;
            this.DataInterpreterView.View = System.Windows.Forms.View.Details;
            // 
            // DataInterpreterTypeColumn
            // 
            this.DataInterpreterTypeColumn.Text = "Type";
            this.DataInterpreterTypeColumn.Width = 78;
            // 
            // DataInterpreterValueColumn
            // 
            this.DataInterpreterValueColumn.Text = "Value";
            this.DataInterpreterValueColumn.Width = 96;
            // 
            // MainMenu
            // 
            this.MainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.MainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.EditMenu,
            this.ToolsMenu});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(884, 24);
            this.MainMenu.TabIndex = 9;
            this.MainMenu.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewMenuItem,
            this.OpenMenuItem,
            this.toolStripMenuItem1,
            this.ExitMenuItem});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMenu.Text = "&File";
            // 
            // NewMenuItem
            // 
            this.NewMenuItem.Name = "NewMenuItem";
            this.NewMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewMenuItem.Size = new System.Drawing.Size(146, 22);
            this.NewMenuItem.Text = "&New";
            this.NewMenuItem.Click += new System.EventHandler(this.New_Click);
            // 
            // OpenMenuItem
            // 
            this.OpenMenuItem.Name = "OpenMenuItem";
            this.OpenMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenMenuItem.Size = new System.Drawing.Size(146, 22);
            this.OpenMenuItem.Text = "&Open";
            this.OpenMenuItem.Click += new System.EventHandler(this.Open_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(143, 6);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(146, 22);
            this.ExitMenuItem.Text = "E&xit";
            // 
            // EditMenu
            // 
            this.EditMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GoToMenuItem});
            this.EditMenu.Name = "EditMenu";
            this.EditMenu.Size = new System.Drawing.Size(39, 20);
            this.EditMenu.Text = "&Edit";
            // 
            // GoToMenuItem
            // 
            this.GoToMenuItem.Name = "GoToMenuItem";
            this.GoToMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.GoToMenuItem.Size = new System.Drawing.Size(157, 22);
            this.GoToMenuItem.Text = "Go To...";
            this.GoToMenuItem.Click += new System.EventHandler(this.GoToMenuItem_Click);
            // 
            // ToolsMenu
            // 
            this.ToolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TransformMenuItem});
            this.ToolsMenu.Name = "ToolsMenu";
            this.ToolsMenu.Size = new System.Drawing.Size(48, 20);
            this.ToolsMenu.Text = "&Tools";
            // 
            // TransformMenuItem
            // 
            this.TransformMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NOTMenuItem,
            this.SubstringMenuItem,
            this.DeflateMenuItem});
            this.TransformMenuItem.Name = "TransformMenuItem";
            this.TransformMenuItem.Size = new System.Drawing.Size(152, 22);
            this.TransformMenuItem.Text = "Transform";
            // 
            // NOTMenuItem
            // 
            this.NOTMenuItem.Name = "NOTMenuItem";
            this.NOTMenuItem.Size = new System.Drawing.Size(152, 22);
            this.NOTMenuItem.Text = "NOT";
            this.NOTMenuItem.Click += new System.EventHandler(this.NOTMenuItem_Click);
            // 
            // SubstringMenuItem
            // 
            this.SubstringMenuItem.Name = "SubstringMenuItem";
            this.SubstringMenuItem.Size = new System.Drawing.Size(152, 22);
            this.SubstringMenuItem.Text = "Substring";
            this.SubstringMenuItem.Click += new System.EventHandler(this.SubstringMenuItem_Click);
            // 
            // DeflateMenuItem
            // 
            this.DeflateMenuItem.Name = "DeflateMenuItem";
            this.DeflateMenuItem.Size = new System.Drawing.Size(152, 22);
            this.DeflateMenuItem.Text = "Deflate";
            this.DeflateMenuItem.Click += new System.EventHandler(this.DeflateMenuItem_Click);
            // 
            // StandardToolbar
            // 
            this.StandardToolbar.Dock = System.Windows.Forms.DockStyle.None;
            this.StandardToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolbarItem,
            this.OpenToolbarItem,
            this.SaveToolbarItem,
            this.SaveAllToolbarItem});
            this.StandardToolbar.Location = new System.Drawing.Point(3, 24);
            this.StandardToolbar.Name = "StandardToolbar";
            this.StandardToolbar.Size = new System.Drawing.Size(104, 25);
            this.StandardToolbar.TabIndex = 5;
            this.StandardToolbar.Text = "toolStrip1";
            // 
            // NewToolbarItem
            // 
            this.NewToolbarItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NewToolbarItem.Image = ((System.Drawing.Image)(resources.GetObject("NewToolbarItem.Image")));
            this.NewToolbarItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewToolbarItem.Name = "NewToolbarItem";
            this.NewToolbarItem.Size = new System.Drawing.Size(23, 22);
            this.NewToolbarItem.Text = "New";
            this.NewToolbarItem.Click += new System.EventHandler(this.New_Click);
            // 
            // OpenToolbarItem
            // 
            this.OpenToolbarItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenToolbarItem.Image = ((System.Drawing.Image)(resources.GetObject("OpenToolbarItem.Image")));
            this.OpenToolbarItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenToolbarItem.Name = "OpenToolbarItem";
            this.OpenToolbarItem.Size = new System.Drawing.Size(23, 22);
            this.OpenToolbarItem.Text = "Open";
            this.OpenToolbarItem.Click += new System.EventHandler(this.Open_Click);
            // 
            // SaveToolbarItem
            // 
            this.SaveToolbarItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveToolbarItem.Image = ((System.Drawing.Image)(resources.GetObject("SaveToolbarItem.Image")));
            this.SaveToolbarItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToolbarItem.Name = "SaveToolbarItem";
            this.SaveToolbarItem.Size = new System.Drawing.Size(23, 22);
            this.SaveToolbarItem.Text = "Save";
            // 
            // SaveAllToolbarItem
            // 
            this.SaveAllToolbarItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveAllToolbarItem.Image = ((System.Drawing.Image)(resources.GetObject("SaveAllToolbarItem.Image")));
            this.SaveAllToolbarItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveAllToolbarItem.Name = "SaveAllToolbarItem";
            this.SaveAllToolbarItem.Size = new System.Drawing.Size(23, 22);
            this.SaveAllToolbarItem.Text = "Save All";
            // 
            // Workspace
            // 
            this.Workspace.DocumentAdded += new HexEditor.Workspace.DocumentEventHandler(this.Workspace_DocumentAdded);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 664);
            this.Controls.Add(this.DockingContainer);
            this.Name = "Main";
            this.Text = "Hex Editor";
            this.TabMenu.ResumeLayout(false);
            this.DockingContainer.BottomToolStripPanel.ResumeLayout(false);
            this.DockingContainer.BottomToolStripPanel.PerformLayout();
            this.DockingContainer.ContentPanel.ResumeLayout(false);
            this.DockingContainer.TopToolStripPanel.ResumeLayout(false);
            this.DockingContainer.TopToolStripPanel.PerformLayout();
            this.DockingContainer.ResumeLayout(false);
            this.DockingContainer.PerformLayout();
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.VerticalSplitter.Panel1.ResumeLayout(false);
            this.VerticalSplitter.Panel2.ResumeLayout(false);
            this.VerticalSplitter.ResumeLayout(false);
            this.RightToolsTab.ResumeLayout(false);
            this.DataInterpreterTab.ResumeLayout(false);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.StandardToolbar.ResumeLayout(false);
            this.StandardToolbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer DockingContainer;
        private System.Windows.Forms.ToolStrip StandardToolbar;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditMenu;
        private System.Windows.Forms.ToolStripMenuItem ToolsMenu;
        private System.Windows.Forms.StatusStrip Status;
        private System.Windows.Forms.ToolStripMenuItem NewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenMenuItem;
        private Workspace Workspace;
        private System.Windows.Forms.ToolStripButton NewToolbarItem;
        private System.Windows.Forms.ToolStripButton OpenToolbarItem;
        private System.Windows.Forms.ContextMenuStrip TabMenu;
        private System.Windows.Forms.ToolStripMenuItem CloseCurrentTabMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseAllButCurrentTabMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TransformMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeflateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NOTMenuItem;
        private System.Windows.Forms.ToolStripMenuItem GoToMenuItem;
        private ExtendedSplitContainer VerticalSplitter;
        private ExtendedTabControl Tabs;
        private ExtendedTabControl RightToolsTab;
        private ExtendedTabPage DataInterpreterTab;
        private VirtualLan.ExtendedListView DataInterpreterView;
        private System.Windows.Forms.ColumnHeader DataInterpreterTypeColumn;
        private System.Windows.Forms.ColumnHeader DataInterpreterValueColumn;
        private System.Windows.Forms.ToolStripButton SaveToolbarItem;
        private System.Windows.Forms.ToolStripButton SaveAllToolbarItem;
        private System.Windows.Forms.ToolStripMenuItem SubstringMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel AddressStatusPanel;
    }
}

