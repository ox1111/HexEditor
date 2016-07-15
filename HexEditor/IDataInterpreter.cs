using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HexEditor
{
    public interface IDataInterpreter
    {
        string Interpret(DataSource DataSource, ulong Offset);

        string Name
        {
            get;
        }
    }
}
