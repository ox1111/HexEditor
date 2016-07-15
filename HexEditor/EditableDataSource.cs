using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HexEditor
{
    public class EditableDataSource : DataSource
    {
        protected DataSource DataSource = null;

        public EditableDataSource()
        {
        }

        public EditableDataSource(DataSource DataSource)
        {
            this.DataSource = DataSource;
        }

        public override byte[] Read(ulong Offset, ulong Size)
        {
            if (this.DataSource != null)
            {
                return this.DataSource.Read(Offset, Size);
            }
            return base.Read(Offset, Size);
        }

        public override ulong Size
        {
            get
            {
                if (this.DataSource != null)
                {
                    return this.DataSource.Size;
                }
                return base.Size;
            }
        }
    }
}
