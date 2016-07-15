using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HexEditor
{
    public class Int64DataInterpreter : IDataInterpreter
    {
        public string Interpret(DataSource DataSource, ulong Offset)
        {
            return BitConverter.ToInt64(DataSource.Read(Offset, 8), 0).ToString();
        }

        public string Name
        {
            get
            {
                return "int64";
            }
        }
    }
}
