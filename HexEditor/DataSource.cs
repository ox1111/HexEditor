using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HexEditor
{
    public class DataSource
    {
        public virtual byte[] Read(ulong Offset, ulong Size)
        {
            return new byte[0];
        }

        public virtual ulong Size
        {
            get
            {
                return 0;
            }
        }
    }
}
