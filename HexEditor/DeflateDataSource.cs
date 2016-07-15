using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.IO;

namespace HexEditor
{
    class DeflateDataSource : DataSource
    {
        protected byte[] Data = null;

        public DeflateDataSource(DataSource Source)
        {
            MemoryStream MemoryStream = new MemoryStream(Source.Read(0, Source.Size));
            DeflateStream DeflateStream = new DeflateStream(MemoryStream, CompressionMode.Decompress);

            List<byte> Decompressed = new List<byte>();
            try
            {
                int Byte = DeflateStream.ReadByte();
                while (Byte != -1)
                {
                    Decompressed.Add((byte)Byte);
                    Byte = DeflateStream.ReadByte();
                }
            }
            catch { }
            this.Data = Decompressed.ToArray();

            DeflateStream.Close();
        }

        public override byte[] Read(ulong Offset, ulong Size)
        {
            return this.Data.Skip((int)Offset).Take((int)Size).ToArray();
        }

        public override ulong Size
        {
            get
            {
                return (ulong)this.Data.Length;
            }
        }
    }
}
