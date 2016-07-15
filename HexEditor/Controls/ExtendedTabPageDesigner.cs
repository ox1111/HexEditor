using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Design;
using System.Windows.Forms.Design.Behavior;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Drawing;

namespace HexEditor
{
    public class ExtendedTabPageDesigner : PanelDesigner
    {
        // Methods
        public override bool CanBeParentedTo(IDesigner parentDesigner)
        {
            return ((parentDesigner != null) && (parentDesigner.Component is ExtendedTabControl));
        }

        protected override ControlBodyGlyph GetControlGlyph(GlyphSelectionType selectionType)
        {
            this.OnSetCursor();
            return new ControlBodyGlyph(Rectangle.Empty, Cursor.Current, this.Control, this);
        }

        internal void OnDragDropInternal(DragEventArgs de)
        {
            this.OnDragDrop(de);
        }

        internal void OnDragEnterInternal(DragEventArgs de)
        {
            this.OnDragEnter(de);
        }

        internal void OnDragLeaveInternal(EventArgs e)
        {
            this.OnDragLeave(e);
        }

        internal void OnDragOverInternal(DragEventArgs e)
        {
            this.OnDragOver(e);
        }

        internal void OnGiveFeedbackInternal(GiveFeedbackEventArgs e)
        {
            this.OnGiveFeedback(e);
        }

        // Properties
        public override SelectionRules SelectionRules
        {
            get
            {
                SelectionRules selectionRules = base.SelectionRules;
                if (this.Control.Parent is ExtendedTabControl)
                {
                    selectionRules &= ~SelectionRules.AllSizeable;
                }
                return selectionRules;
            }
        }
    }
}
