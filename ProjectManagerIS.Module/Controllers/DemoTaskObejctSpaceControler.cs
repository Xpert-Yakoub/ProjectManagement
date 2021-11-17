using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using ProjectManagerIS.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ProjectManagerIS.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class DemoTaskObejctSpaceControler : ObjectViewController<ObjectView, DemoTask>
    {
        public IMemberInfo IsAggregated { get; private set; }

        public DemoTaskObejctSpaceControler()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.


        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            ObjectSpace.ObjectChanged += ObjectSpace_ObjectChanged;
            ObjectSpace.Committing += ObjectSpace_Objectcom;
            ObjectSpace.ObjectSaving += ObjectSpace_ObjectSaving;

        }

        private void ObjectSpace_ObjectSaving(object sender, ObjectManipulatingEventArgs e)
        {
            //throw new NotImplementedException();



        }





        private void ObjectSpace_Objectcom(object sender, CancelEventArgs e)
        {
            //throw new NotImplementedException();
        }


        

        void ObjectSpace_ObjectCommiting(object sender, ObjectChangedEventArgs e)
        {
            if (View.CurrentObject == e.Object && ObjectSpace.IsCommitting)
            {

            }
        }

        



        void ObjectSpace_ObjectChanged(object sender , ObjectChangedEventArgs e)
        {


            if (View.CurrentObject == e.Object &&
                e.PropertyName == "CostumTaskStatus" &&
                ObjectSpace.IsModified &&
                e.OldValue != e.NewValue){
                DemoTask TaskChanged = (DemoTask)e.Object;
                    if (TaskChanged.CostumTaskStatus != null)
                        {
                            TaskChanged.TaskResolution = null; 
                        }
            
                }
                
                
        }


        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
            ObjectSpace.ObjectChanged += ObjectSpace_ObjectChanged;
        }

        

        
    }
}
