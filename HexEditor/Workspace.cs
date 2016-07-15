using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace HexEditor
{
    public class Workspace : Component
    {
        public delegate void DocumentEventHandler(Workspace Workspace, Document Document);
        public event DocumentEventHandler DocumentAdded;
        public event DocumentEventHandler DocumentRemoved;

        private List<Document> Documents = new List<Document>();

        public Workspace()
        {
        }

        public Document OpenDocument(string Name, DataSource DataSource)
        {
            Document Document = new Document(this, Name, DataSource);
            this.Documents.Add(Document);
            if (this.DocumentAdded != null)
            {
                this.DocumentAdded(this, Document);
            }
            return Document;
        }

        public Document OpenFile(string Path)
        {
            Path = Path.Replace('\\', '/');
            FileStream FileStream = null;
            try
            {
                FileStream = File.Open(Path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            }
            catch (IOException)
            {
                FileStream = File.Open(Path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            }
            Document Document = new Document(this, Path.Substring(Path.LastIndexOf('/') + 1), new FileDataSource(FileStream));
            this.Documents.Add(Document);
            if (this.DocumentAdded != null)
            {
                this.DocumentAdded(this, Document);
            }
            return Document;
        }

        public Document OpenNewDocument()
        {
            Document Document = new Document(this, "new");
            this.Documents.Add(Document);
            if (this.DocumentAdded != null)
            {
                this.DocumentAdded(this, Document);
            }
            return Document;
        }
    }
}
