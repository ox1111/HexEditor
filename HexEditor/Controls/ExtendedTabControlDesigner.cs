using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Reflection;

namespace HexEditor
{
    public class ExtendedTabControlDesigner : ParentControlDesigner
    {
        // Fields
        private bool addingOnInitialize;
        private bool disableDrawGrid;
        private bool forwardOnDrag;
        private int persistedSelectedIndex;
        private DesignerVerb removeVerb;
        private bool tabControlSelected;
        private DesignerVerbCollection verbs;

        // Methods
        public override bool CanParent(Control control)
        {
            return ((control is ExtendedTabPage) && !this.Control.Contains(control));
        }

        private void CheckVerbStatus()
        {
            if (this.removeVerb != null)
            {
                this.removeVerb.Enabled = this.Control.Controls.Count > 0;
            }
        }

        protected override IComponent[] CreateToolCore(ToolboxItem tool, int x, int y, int width, int height, bool hasLocation, bool hasSize)
        {
            ExtendedTabControl control = (ExtendedTabControl)this.Control;
            if (control.SelectedTab == null)
            {
                throw new ArgumentException("Only ExtendedTabPages can be placed in ExtendedTabControls.");
            }
            IDesignerHost service = (IDesignerHost)this.GetService(typeof(IDesignerHost));
            if (service != null)
            {
                ExtendedTabPageDesigner toInvoke = (ExtendedTabPageDesigner)service.GetDesigner(control.SelectedTab);
                ParentControlDesigner.InvokeCreateTool(toInvoke, tool);
            }
            return null;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ISelectionService service = (ISelectionService)this.GetService(typeof(ISelectionService));
                if (service != null)
                {
                    service.SelectionChanged -= new EventHandler(this.OnSelectionChanged);
                }
                IComponentChangeService service2 = (IComponentChangeService)this.GetService(typeof(IComponentChangeService));
                if (service2 != null)
                {
                    service2.ComponentChanged -= new ComponentChangedEventHandler(this.OnComponentChanged);
                }
                ExtendedTabControl control = this.Control as ExtendedTabControl;
                if (control != null)
                {
                    control.SelectedIndexChanged -= new EventHandler(this.OnTabSelectedIndexChanged);
                    control.GotFocus -= new EventHandler(this.OnGotFocus);
                    control.RightToLeftLayoutChanged -= new EventHandler(this.OnRightToLeftLayoutChanged);
                    control.ControlAdded -= new ControlEventHandler(this.OnControlAdded);
                }
            }
            base.Dispose(disposing);
        }

        protected override bool GetHitTest(Point point)
        {
            ExtendedTabControl control = (ExtendedTabControl)this.Control;
            if (this.tabControlSelected)
            {
                Point pt = this.Control.PointToClient(point);
                return !control.DisplayRectangle.Contains(pt);
            }
            return false;
        }

        private ExtendedTabPageDesigner GetSelectedTabPageDesigner()
        {
            ExtendedTabPageDesigner designer = null;
            ExtendedTabPage selectedTab = ((ExtendedTabControl)base.Component).SelectedTab;
            if (selectedTab != null)
            {
                IDesignerHost service = (IDesignerHost)this.GetService(typeof(IDesignerHost));
                if (service != null)
                {
                    designer = service.GetDesigner(selectedTab) as ExtendedTabPageDesigner;
                }
            }
            return designer;
        }

        internal static ExtendedTabPage GetTabPageOfComponent(object comp)
        {
            if (!(comp is Control))
            {
                return null;
            }
            Control parent = (Control)comp;
            while ((parent != null) && !(parent is ExtendedTabPage))
            {
                parent = parent.Parent;
            }
            return (ExtendedTabPage)parent;
        }

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            base.AutoResizeHandles = true;
            ExtendedTabControl control = component as ExtendedTabControl;
            ISelectionService service = (ISelectionService)this.GetService(typeof(ISelectionService));
            if (service != null)
            {
                service.SelectionChanged += new EventHandler(this.OnSelectionChanged);
            }
            IComponentChangeService service2 = (IComponentChangeService)this.GetService(typeof(IComponentChangeService));
            if (service2 != null)
            {
                service2.ComponentChanged += new ComponentChangedEventHandler(this.OnComponentChanged);
            }
            if (control != null)
            {
                control.SelectedIndexChanged += new EventHandler(this.OnTabSelectedIndexChanged);
                control.GotFocus += new EventHandler(this.OnGotFocus);
                control.RightToLeftLayoutChanged += new EventHandler(this.OnRightToLeftLayoutChanged);
                control.ControlAdded += new ControlEventHandler(this.OnControlAdded);
            }
        }

        public override void InitializeNewComponent(IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
            try
            {
                this.addingOnInitialize = true;
                this.OnAdd(this, EventArgs.Empty);
                this.OnAdd(this, EventArgs.Empty);
            }
            finally
            {
                this.addingOnInitialize = false;
            }
            MemberDescriptor member = TypeDescriptor.GetProperties(base.Component)["Controls"];
            base.RaiseComponentChanging(member);
            base.RaiseComponentChanged(member, null, null);
            ExtendedTabControl component = (ExtendedTabControl)base.Component;
            if (component != null)
            {
                component.SelectedIndex = 0;
            }
        }

        private void OnAdd(object sender, EventArgs eevent)
        {
            ExtendedTabControl component = (ExtendedTabControl)base.Component;
            IDesignerHost service = (IDesignerHost)this.GetService(typeof(IDesignerHost));
            if (service != null)
            {
                DesignerTransaction transaction = null;
                try
                {
                    try
                    {
                        transaction = service.CreateTransaction("TabControlAddTab");
                    }
                    catch (CheckoutException exception)
                    {
                        if (exception != CheckoutException.Canceled)
                        {
                            throw exception;
                        }
                        return;
                    }
                    MemberDescriptor member = TypeDescriptor.GetProperties(component)["Controls"];
                    ExtendedTabPage page = (ExtendedTabPage)service.CreateComponent(typeof(ExtendedTabPage));
                    if (!this.addingOnInitialize)
                    {
                        base.RaiseComponentChanging(member);
                    }
                    page.Padding = new Padding(3);
                    string str = null;
                    PropertyDescriptor descriptor2 = TypeDescriptor.GetProperties(page)["Name"];
                    if ((descriptor2 != null) && (descriptor2.PropertyType == typeof(string)))
                    {
                        str = (string)descriptor2.GetValue(page);
                    }
                    if (str != null)
                    {
                        PropertyDescriptor descriptor3 = TypeDescriptor.GetProperties(page)["Text"];
                        if (descriptor3 != null)
                        {
                            descriptor3.SetValue(page, str);
                        }
                    }
                    PropertyDescriptor descriptor4 = TypeDescriptor.GetProperties(page)["UseVisualStyleBackColor"];
                    if (((descriptor4 != null) && (descriptor4.PropertyType == typeof(bool))) && (!descriptor4.IsReadOnly && descriptor4.IsBrowsable))
                    {
                        descriptor4.SetValue(page, true);
                    }
                    component.Controls.Add(page);
                    component.SelectedIndex = component.TabCount - 1;
                    if (!this.addingOnInitialize)
                    {
                        base.RaiseComponentChanged(member, null, null);
                    }
                }
                finally
                {
                    if (transaction != null)
                    {
                        transaction.Commit();
                    }
                }
            }
        }

        private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
        {
            this.CheckVerbStatus();
        }

        private void OnControlAdded(object sender, ControlEventArgs e)
        {
            if ((e.Control != null) && !e.Control.IsHandleCreated)
            {
                IntPtr handle = e.Control.Handle;
            }
        }

        protected override void OnDragDrop(DragEventArgs de)
        {
            if (this.forwardOnDrag)
            {
                ExtendedTabPageDesigner selectedTabPageDesigner = this.GetSelectedTabPageDesigner();
                if (selectedTabPageDesigner != null)
                {
                    selectedTabPageDesigner.OnDragDropInternal(de);
                }
            }
            else
            {
                base.OnDragDrop(de);
            }
            this.forwardOnDrag = false;
        }

        protected override void OnDragEnter(DragEventArgs de)
        {
            this.forwardOnDrag = false;
            Type BehaviorDataObjectType = Type.GetType("System.Windows.Forms.Design.Behavior.DropSourceBehavior+BehaviorDataObject");
            object data = null;
            if (BehaviorDataObjectType.IsInstanceOfType(de.Data))
            {
                data = de.Data;
            }
            if (data != null)
            {
                int primaryControlIndex = -1;
                object[] arguments = {-1};
                ArrayList sortedDragControls = null;
                sortedDragControls = (ArrayList)BehaviorDataObjectType.InvokeMember("GetSortedDragControls", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, data, arguments);
                primaryControlIndex = (int)arguments[0];
                if (sortedDragControls != null)
                {
                    for (int i = 0; i < sortedDragControls.Count; i++)
                    {
                        if (!(sortedDragControls[i] is Control) || ((sortedDragControls[i] is Control) && !(sortedDragControls[i] is TabPage)))
                        {
                            this.forwardOnDrag = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                this.forwardOnDrag = true;
            }
            if (this.forwardOnDrag)
            {
                ExtendedTabPageDesigner selectedTabPageDesigner = this.GetSelectedTabPageDesigner();
                if (selectedTabPageDesigner != null)
                {
                    selectedTabPageDesigner.OnDragEnterInternal(de);
                }
            }
            else
            {
                base.OnDragEnter(de);
            }
        }

        protected override void OnDragLeave(EventArgs e)
        {
            if (this.forwardOnDrag)
            {
                ExtendedTabPageDesigner selectedTabPageDesigner = this.GetSelectedTabPageDesigner();
                if (selectedTabPageDesigner != null)
                {
                    selectedTabPageDesigner.OnDragLeaveInternal(e);
                }
            }
            else
            {
                base.OnDragLeave(e);
            }
            this.forwardOnDrag = false;
        }

        protected override void OnDragOver(DragEventArgs de)
        {
            if (this.forwardOnDrag)
            {
                ExtendedTabControl control = (ExtendedTabControl)this.Control;
                Point pt = this.Control.PointToClient(new Point(de.X, de.Y));
                if (!control.DisplayRectangle.Contains(pt))
                {
                    de.Effect = DragDropEffects.None;
                }
                else
                {
                    ExtendedTabPageDesigner selectedTabPageDesigner = this.GetSelectedTabPageDesigner();
                    if (selectedTabPageDesigner != null)
                    {
                        selectedTabPageDesigner.OnDragOverInternal(de);
                    }
                }
            }
            else
            {
                base.OnDragOver(de);
            }
        }

        protected override void OnGiveFeedback(GiveFeedbackEventArgs e)
        {
            if (this.forwardOnDrag)
            {
                ExtendedTabPageDesigner selectedTabPageDesigner = this.GetSelectedTabPageDesigner();
                if (selectedTabPageDesigner != null)
                {
                    selectedTabPageDesigner.OnGiveFeedbackInternal(e);
                }
            }
            else
            {
                base.OnGiveFeedback(e);
            }
        }

        private void OnGotFocus(object sender, EventArgs e)
        {
        }

        protected override void OnPaintAdornments(PaintEventArgs pe)
        {
            try
            {
                this.disableDrawGrid = true;
                base.OnPaintAdornments(pe);
            }
            finally
            {
                this.disableDrawGrid = false;
            }
        }

        private void OnRemove(object sender, EventArgs eevent)
        {
            ExtendedTabControl component = (ExtendedTabControl)base.Component;
            if ((component != null) && (component.TabPages.Count != 0))
            {
                MemberDescriptor member = TypeDescriptor.GetProperties(base.Component)["Controls"];
                ExtendedTabPage selectedTab = component.SelectedTab;
                IDesignerHost service = (IDesignerHost)this.GetService(typeof(IDesignerHost));
                if (service != null)
                {
                    DesignerTransaction transaction = null;
                    try
                    {
                        try
                        {
                            transaction = service.CreateTransaction("TabControlRemoveTab");
                            base.RaiseComponentChanging(member);
                        }
                        catch (CheckoutException exception)
                        {
                            if (exception != CheckoutException.Canceled)
                            {
                                throw exception;
                            }
                            return;
                        }
                        service.DestroyComponent(selectedTab);
                        base.RaiseComponentChanged(member, null, null);
                    }
                    finally
                    {
                        if (transaction != null)
                        {
                            transaction.Commit();
                        }
                    }
                }
            }
        }

        private void OnRightToLeftLayoutChanged(object sender, EventArgs e)
        {
            if (base.BehaviorService != null)
            {
                base.BehaviorService.SyncSelection();
            }
        }

        private void OnSelectionChanged(object sender, EventArgs e)
        {
            ISelectionService service = (ISelectionService)this.GetService(typeof(ISelectionService));
            this.tabControlSelected = false;
            if (service != null)
            {
                ICollection selectedComponents = service.GetSelectedComponents();
                ExtendedTabControl component = (ExtendedTabControl)base.Component;
                foreach (object obj2 in selectedComponents)
                {
                    if (obj2 == component)
                    {
                        this.tabControlSelected = true;
                    }
                    ExtendedTabPage tabPageOfComponent = GetTabPageOfComponent(obj2);
                    if ((tabPageOfComponent != null) && (tabPageOfComponent.Parent == component))
                    {
                        this.tabControlSelected = false;
                        component.SelectedTab = tabPageOfComponent;
                        break;
                    }
                }
            }
        }

        private void OnTabSelectedIndexChanged(object sender, EventArgs e)
        {
            ISelectionService service = (ISelectionService)this.GetService(typeof(ISelectionService));
            if (service != null)
            {
                ICollection selectedComponents = service.GetSelectedComponents();
                ExtendedTabControl component = (ExtendedTabControl)base.Component;
                bool flag = false;
                foreach (object obj2 in selectedComponents)
                {
                    ExtendedTabPage tabPageOfComponent = GetTabPageOfComponent(obj2);
                    if (((tabPageOfComponent != null) && (tabPageOfComponent.Parent == component)) && (tabPageOfComponent == component.SelectedTab))
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    service.SetSelectedComponents(new object[] { base.Component });
                }
            }
        }

        protected override void PreFilterProperties(IDictionary properties)
        {
            base.PreFilterProperties(properties);
            string[] strArray = new string[] { "SelectedIndex" };
            Attribute[] attributes = new Attribute[0];
            for (int i = 0; i < strArray.Length; i++)
            {
                PropertyDescriptor oldPropertyDescriptor = (PropertyDescriptor)properties[strArray[i]];
                if (oldPropertyDescriptor != null)
                {
                    properties[strArray[i]] = TypeDescriptor.CreateProperty(typeof(ExtendedTabControlDesigner), oldPropertyDescriptor, attributes);
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x114:
                case 0x115:
                    base.BehaviorService.Invalidate(base.BehaviorService.ControlRectInAdornerWindow(this.Control));
                    base.WndProc(ref m);
                    return;

                case 0x84:
                    base.WndProc(ref m);
                    if (((int)m.Result) != -1)
                    {
                        break;
                    }
                    m.Result = (IntPtr)1;
                    return;

                case 0x7b:
                    {
                        int x = (int)(((uint)m.LParam) & 0x0000FFFF);
                        int y = (int)((((uint)m.LParam) & 0xFFFF0000) >> 16);
                        if ((x == -1) && (y == -1))
                        {
                            Point position = Cursor.Position;
                            x = position.X;
                            y = position.Y;
                        }
                        this.OnContextMenu(x, y);
                        return;
                    }
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        // Properties
        protected override bool AllowControlLasso
        {
            get
            {
                return false;
            }
        }

        protected override bool DrawGrid
        {
            get
            {
                if (this.disableDrawGrid)
                {
                    return false;
                }
                return base.DrawGrid;
            }
        }

        public override bool ParticipatesWithSnapLines
        {
            get
            {
                if (!this.forwardOnDrag)
                {
                    return false;
                }
                ExtendedTabPageDesigner selectedTabPageDesigner = this.GetSelectedTabPageDesigner();
                if (selectedTabPageDesigner != null)
                {
                    return selectedTabPageDesigner.ParticipatesWithSnapLines;
                }
                return true;
            }
        }

        private int SelectedIndex
        {
            get
            {
                return this.persistedSelectedIndex;
            }
            set
            {
                this.persistedSelectedIndex = value;
            }
        }

        public override DesignerVerbCollection Verbs
        {
            get
            {
                if (this.verbs == null)
                {
                    this.removeVerb = new DesignerVerb("Remove Tab", new EventHandler(this.OnRemove));
                    this.verbs = new DesignerVerbCollection();
                    this.verbs.Add(new DesignerVerb("Add Tab", new EventHandler(this.OnAdd)));
                    this.verbs.Add(this.removeVerb);
                }
                if (this.Control != null)
                {
                    this.removeVerb.Enabled = this.Control.Controls.Count > 0;
                }
                return this.verbs;
            }
        }
    }
}
