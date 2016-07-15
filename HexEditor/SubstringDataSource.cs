using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HexEditor
{
    public class SubstringDataSource : DataSource
    {
        protected DataSource DataSource;
        protected long Offset;

        public SubstringDataSource(DataSource DataSource, long Offset)
        {
            this.DataSource = DataSource;
            this.Offset = Offset;
        }

        public override byte[] Read(ulong Offset, ulong Size)
        {
            return this.DataSource.Read(Offset + (ulong)this.Offset, Size);
        }

        public override ulong Size
        {
            get
            {
                return DataSource.Size - (ulong)this.Offset;
            }
        }
    }
}
