using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HexEditor
{
    public class Int16DataInterpreter : IDataInterpreter
    {
        public string Interpret(DataSource DataSource, ulong Offset)
        {
            return BitConverter.ToInt16(DataSource.Read(Offset, 2), 0).ToString();
        }

        public string Name
        {
            get
            {
                return "int16";
            }
        }
    }
}
