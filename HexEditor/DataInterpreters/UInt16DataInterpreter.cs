using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HexEditor
{
    public class UInt16DataInterpreter : IDataInterpreter
    {
        public string Interpret(DataSource DataSource, ulong Offset)
        {
            return BitConverter.ToUInt16(DataSource.Read(Offset, 2), 0).ToString();
        }

        public string Name
        {
            get
            {
                return "uint16";
            }
        }
    }
}
