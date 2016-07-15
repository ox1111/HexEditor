using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace HexEditor
{
    public class DataInterpreterCollection : Component, IEnumerable<IDataInterpreter>
    {
        public delegate void DataInterpreterEventHandler(DataInterpreterCollection Collection, IDataInterpreter Interpreter);
        public event DataInterpreterEventHandler DataInterpreterAdded;
        public event DataInterpreterEventHandler DataInterpreterRemoved;

        protected List<IDataInterpreter> DataInterpreters = new List<IDataInterpreter>();

        public DataInterpreterCollection()
        {
        }

        public void Add(IDataInterpreter DataInterpreter)
        {
            this.DataInterpreters.Add(DataInterpreter);

            if (this.DataInterpreterAdded != null)
            {
                this.DataInterpreterAdded(this, DataInterpreter);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.DataInterpreters.GetEnumerator();
        }

        IEnumerator<IDataInterpreter> IEnumerable<IDataInterpreter>.GetEnumerator()
        {
            return this.DataInterpreters.GetEnumerator();
        }

        public void Remove(IDataInterpreter DataInterpreter)
        {
            this.DataInterpreters.Remove(DataInterpreter);

            if (this.DataInterpreterRemoved != null)
            {
                this.DataInterpreterRemoved(this, DataInterpreter);
            }
        }
    }
}
