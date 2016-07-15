using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;
using System.Globalization;

namespace HexEditor
{
    public partial class Main : Form
    {
        private DataInterpreterCollection DataInterpreters = new DataInterpreterCollection();

        public Main()
        {
            InitializeComponent();
            this.Workspace.OpenFile(Application.ExecutablePath);

            DataInterpreters.Add(new Int8DataInterpreter());
            DataInterpreters.Add(new UInt8DataInterpreter());
            DataInterpreters.Add(new Int16DataInterpreter());
            DataInterpreters.Add(new UInt16DataInterpreter());
            DataInterpreters.Add(new Int32DataInterpreter());
            DataInterpreters.Add(new UInt32DataInterpreter());
            DataInterpreters.Add(new Int64DataInterpreter());
            DataInterpreters.Add(new UInt64DataInterpreter());
        }

        public HexView CurrentView
        {
            get
            {
                return (HexView)this.Tabs.SelectedTab.Tag;
            }
        }

        private void New_Click(object sender, EventArgs e)
        {
            this.Workspace.OpenNewDocument();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                this.Workspace.OpenFile(Dialog.FileName);
            }
        }

        private void GoToMenuItem_Click(object sender, EventArgs e)
        {
            GoToDialog Dialog = new GoToDialog();
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                long Offset = this.CurrentView.SelectionEnd;
                switch (Dialog.SeekMode)
                {
                    case SeekMode.Absolute:
                        Offset = Dialog.Offset;
                        break;
                    case SeekMode.Up:
                        Offset -= Dialog.Offset;
                        break;
                    case SeekMode.Down:
                        Offset += Dialog.Offset;
                        break;
                }
                this.CurrentView.SelectionEnd = Offset;
                this.CurrentView.SelectionStart = Offset;
            }
        }

        private void Workspace_DocumentAdded(Workspace Workspace, Document Document)
        {
            this.Tabs.TabPages.Add(Document.Name);
            this.Tabs.SelectedIndex = this.Tabs.TabCount - 1;

            TabPage Tab = this.Tabs.TabPages[this.Tabs.TabCount - 1];
            HexView View = new HexView(Document);
            View.Visible = false;
            View.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            View.Dock = DockStyle.Fill;
            View.Parent = Tab;
            View.Visible = true;
            Tab.Tag = View;

            View.SelectionChanged += delegate(HexView HexView)
            {
                this.DataInterpreterView.Items.Clear();
                foreach (IDataInterpreter DataInterpreter in this.DataInterpreters)
                {
                    try
                    {
                        this.DataInterpreterView.Items.Add(DataInterpreter.Name).SubItems.Add(DataInterpreter.Interpret(HexView.Document.DataSource, (ulong)HexView.SelectionEnd));
                    }
                    catch
                    {
                        this.DataInterpreterView.Items.Add(DataInterpreter.Name).SubItems.Add("<error>");
                    }
                }

                long Address = HexView.SelectionEnd;
                this.AddressStatusPanel.Text = "Address: " + Address.ToString("x") + " (" + Address.ToString() + ")";
            };
        }

        private void TabMenu_Opening(object sender, CancelEventArgs e)
        {
            this.CloseCurrentTabMenuItem.Text = "Close " + ((HexView)this.Tabs.SelectedTab.Tag).Document.Name;
        }

        private void CloseCurrentTabMenuItem_Click(object sender, EventArgs e)
        {
            this.Tabs.CloseTab(this.Tabs.SelectedIndex);
        }

        private void DeflateMenuItem_Click(object sender, EventArgs e)
        {
            HexView Current = (HexView)this.Tabs.SelectedTab.Tag;
            Document Document = Current.Document;
            this.Workspace.OpenDocument(Document.Name + " > deflate", new DeflateDataSource(Document.DataSource));
        }

        private void SubstringMenuItem_Click(object sender, EventArgs e)
        {
            HexView Current = (HexView)this.Tabs.SelectedTab.Tag;
            Document Document = Current.Document;
            this.Workspace.OpenDocument(Document.Name + " > sub", new SubstringDataSource(Document.DataSource, Current.SelectionEnd));
        }

        private void NOTMenuItem_Click(object sender, EventArgs e)
        {
            HexView Current = (HexView)this.Tabs.SelectedTab.Tag;
            Document Document = Current.Document;
            this.Workspace.OpenDocument(Document.Name + " >  NOT", new NOTDataSource(Document.DataSource));
        }
    }
}
