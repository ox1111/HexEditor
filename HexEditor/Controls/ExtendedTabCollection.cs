using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HexEditor
{
    [Designer(typeof(ExtendedTabControlDesigner))]
    public class ExtendedTabCollection : TabControl.TabPageCollection
    {
        public ExtendedTabCollection(TabControl Owner)
            : base(Owner)
        {
        }

        public new ExtendedTabPage this[int Index]
        {
            get
            {
                return (ExtendedTabPage)base[Index];
            }
            set
            {
                base[Index] = value;
            }
        }

        public new ExtendedTabPage this[string Key]
        {
            get
            {
                return (ExtendedTabPage)base[Key];
            }
        }

        public new void Add(string Text)
        {
            ExtendedTabPage Tab = new ExtendedTabPage(Text);
            base.Add(Tab);
        }

        public new void Add(string Key, string Text)
        {
            ExtendedTabPage Tab = new ExtendedTabPage(Text);
            Tab.Name = Key;
            base.Add(Tab);
        }

        public new void Add(string Key, string Text, int ImageIndex)
        {
            ExtendedTabPage Tab = new ExtendedTabPage(Text);
            Tab.Name = Key;
            Tab.ImageIndex = ImageIndex;
            base.Add(Tab);
        }

        public new void Add(string Key, string Text, string ImageKey)
        {
            ExtendedTabPage Tab = new ExtendedTabPage(Text);
            Tab.Name = Key;
            Tab.ImageKey = ImageKey;
            base.Add(Tab);
        }

        public void Add(ExtendedTabPage Tab)
        {
            base.Add(Tab);
        }

        private new void Add(TabPage Tab)
        {
            throw new Exception("Only ExtendedTabPages can be added to ExtendedTabControls.");
        }
    }
}
