using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HexEditor
{
    public class UInt8DataInterpreter: IDataInterpreter
    {
        public string Interpret(DataSource DataSource, ulong Offset)
        {
            return ((byte)DataSource.Read(Offset, 1)[0]).ToString();
        }

        public string Name
        {
            get
            {
                return "uint8";
            }
        }
    }
}
