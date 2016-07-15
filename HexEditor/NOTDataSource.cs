using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HexEditor
{
    public class NOTDataSource : DataSource
    {
        protected DataSource DataSource = null;

        public NOTDataSource(DataSource DataSource)
        {
            this.DataSource = DataSource;
        }

        public override byte[] Read(ulong Offset, ulong Size)
        {
            byte[] Buffer = this.DataSource.Read(Offset, Size);
            for (int i = 0; i < Buffer.Length; i++)
            {
                Buffer[i] = (byte)~Buffer[i];
            }
            return Buffer;
        }

        public override ulong Size
        {
            get
            {
                return this.DataSource.Size;
            }
        }
    }
}
