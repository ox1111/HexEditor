using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HexEditor
{
    public class FileDataSource : DataSource
    {
        protected FileStream File = null;

        public FileDataSource(FileStream File)
        {
            this.File = File;
        }

        public override byte[] Read(ulong Offset, ulong Size)
        {
            if ((ulong)this.File.Length - Offset < Size)
            {
                Size = (ulong)this.File.Length - Offset;
            }
            byte[] Buffer = new byte[Size];
            this.File.Seek((long)Offset, SeekOrigin.Begin);
            this.File.Read(Buffer, 0, (int)Size);
            return Buffer;
        }

        public override ulong Size
        {
            get
            {
                return (ulong)this.File.Length;
            }
        }
    }
}
