using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HexEditor
{
    public class UInt64DataInterpreter : IDataInterpreter
    {
        public string Interpret(DataSource DataSource, ulong Offset)
        {
            return BitConverter.ToUInt64(DataSource.Read(Offset, 8), 0).ToString();
        }

        public string Name
        {
            get
            {
                return "uint64";
            }
        }
    }
}
