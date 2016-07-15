using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HexEditor
{
    public class Int32DataInterpreter : IDataInterpreter
    {
        public string Interpret(DataSource DataSource, ulong Offset)
        {
            return BitConverter.ToInt32(DataSource.Read(Offset, 4), 0).ToString();
        }

        public string Name
        {
            get
            {
                return "int32";
            }
        }
    }
}
