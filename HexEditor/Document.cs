using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HexEditor
{
    public class Document
    {
        public readonly Workspace Workspace;
        public string Name = "unnamed";
        private DataSource _DataSource = null;

        public Document(Workspace Workspace, string Name)
        {
            this.Workspace = Workspace;
            this.Name = Name;
            this.DataSource = new EditableDataSource();
        }

        public Document(Workspace Workspace, string Name, DataSource DataSource)
        {
            this.Workspace = Workspace;
            this.Name = Name;
            this.DataSource = new EditableDataSource(DataSource);
        }

        public DataSource DataSource
        {
            get
            {
                return this._DataSource;
            }
            protected set
            {
                this._DataSource = value;
            }
        }
    }
}
