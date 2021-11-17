using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.AuditTrail;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;

namespace ProjectManagerIS.Module.BusinessObjects
{
    //[Appearance("FontColorGreen", AppearanceItemType = "ViewItem", TargetItems = "*", Context = "ListView",
    //Criteria = "Status ='Completed'", FontColor = "Green")]

    [Appearance("FontColorRed", AppearanceItemType = "ViewItem", TargetItems = "Priority", Context = "ListView",
    Criteria = "costumTaskStatus ='Reception'", FontColor = "Red")]


    [DefaultClassOptions]
    [ModelDefault("Caption", "Task")]
    public class DemoTask : Task 
    {
        public DemoTask(Session session) : base(session) {


        }


        public override void AfterConstruction()
        {
            base.AfterConstruction();

            //DevExpress.Xpo.XpoDefault.DataLayer = new DevExpress.Xpo.SimpleDataLayer(new DevExpress.Xpo.DB.InMemoryDataStore());

            ApplicationUser Owner = Session.GetObjectByKey<ApplicationUser>(SecuritySystem.CurrentUserId);

            string poistionTitle = (string)Owner.Position.Title; 

            switch (poistionTitle)
            {
                case "Reception":
                    costumTaskStatus = (CostumTaskStatus)Session.FindObject(typeof(CostumTaskStatus), CriteriaOperator.Parse("Status='Reception'"), true);
                    TaskResolution = (CostumResolutions)Session.FindObject(typeof(CostumResolutions), CriteriaOperator.Parse("ResolutionName='Scanning  paper'"), true);

                    break;
                case "Comptable":
                    costumTaskStatus = (CostumTaskStatus)Session.FindObject(typeof(CostumTaskStatus), CriteriaOperator.Parse("Status='Comptabilisation'"), true);
                    TaskResolution = (CostumResolutions)Session.FindObject(typeof(CostumResolutions), CriteriaOperator.Parse("ResolutionName='En cour de la Comptabilisation'"), true);
                    break;

                default:
                    Console.WriteLine("Value ");
                    break;
            }

            CreatedOn = DateTime.Now;


        }

        Empolyees assigned;
        DateTime createdOn;
        CostumTaskStatus costumTaskStatus;
        [ImmediatePostData]
        [DevExpress.Xpo.DisplayName("Status")]

        public CostumTaskStatus CostumTaskStatus
        {
            get => costumTaskStatus;
            set
            {
                SetPropertyValue(nameof(CostumTaskStatus), ref costumTaskStatus, value);
                if (IsLoading)
                {
                    TaskResolution = null;
                }

            }

        }




        CostumResolutions taskResolution;
        [DataSourceProperty("CostumTaskStatus.Resolution", DataSourcePropertyIsNullMode.SelectNothing)]
        [DevExpress.Xpo.DisplayName("Resolution")]
        public CostumResolutions TaskResolution
        {
            get => taskResolution;
            set => SetPropertyValue(nameof(TaskResolution), ref taskResolution, value);

        }


        private Priority priority;

        public Priority Priority
        {
            get { return priority; }
            set
            {
                SetPropertyValue(nameof(Priority), ref priority, value);
            }
        }



        public DateTime CreatedOn
        {
            get => createdOn;
            set => SetPropertyValue(nameof(CreatedOn), ref createdOn, value);
        }





        [ImmediatePostData]
        [Association("DemoTask-Subtask"), DevExpress.Xpo.Aggregated]
        [DevExpress.Xpo.DisplayName("Subtask")]
        public XPCollection<Subtask> Subtask
        {
            get { return GetCollection<Subtask>(nameof(Subtask)); }
        }


        Project projectName;
        [Association("DemoTask-Project")]
        [System.ComponentModel.DisplayName("Project")]
        [RuleRequiredField("RuleRequiredField for Task.Project", DefaultContexts.Save,
      "A Project must be specified")]
        public Project ProjectName
        {
            get
            {
                return projectName;
            }
            set
            {
                SetPropertyValue<Project>(nameof(ProjectName), ref projectName, value);
            }
        }


        //[Size(4054)]
        //public String Subject
        //{
        //    get => subject;
        //    set => SetPropertyValue(nameof(Subject), ref subject, value);
        //}

        
        public Empolyees Assigned
        {
            get => assigned;
            set => SetPropertyValue(nameof(Assigned), ref assigned, value);
        }




        //private Resolution resolutions;
        //public Resolution Resolutions
        //{
        //    get { return resolutions; }
        //    set { SetPropertyValue(nameof(Resolutions), ref resolutions, value); }
        //}





        private XPCollection<AuditDataItemPersistent> changesHistpry;
        [CollectionOperationSet(AllowAdd = false, AllowRemove = false)]
        public XPCollection<AuditDataItemPersistent> AuditTrail
        {
            get
            {
                if (changesHistpry == null)
                {
                    changesHistpry = AuditedObjectWeakReference.GetAuditTrail(Session, this);
                }
                return changesHistpry;
            }
        }



        //[Action(Caption = "Postpone", TargetObjectsCriteria = "[TaskStatus] Is not [Completed]")]
        //public void Postpone(PostponeParametersObject parameters)
        //{
        //    if ((parameters.PostponeForDays > 0))
        //    {
        //        DueDate = DueDate + TimeSpan.FromDays(parameters.PostponeForDays);
        //        Description += String.Format("Postponed for {0} days, new deadline is {1:d}\r\n{2}\r\n",
        //        parameters.PostponeForDays, DueDate, parameters.Comment);

        //        Status = DevExpress.Persistent.Base.General.TaskStatus.Deferred;
        //    }
        //}
    }



    //public enum Resolution
    //{
    //    [XafDisplayName("Need more information")]
    //    Need_More_Info = 0,
    //    [XafDisplayName("Not resolved")]
    //    Need_More_Info2 = 1,
    //    [XafDisplayName("pending")]
    //    Need_More_Info3 = 2
    //}
    public enum Priority
    {
        [ImageName("State_Priority_Low")]
        Low = 0,
        [ImageName("State_Priority_Normal")]
        Normal = 1,
        [ImageName("State_Priority_High")]
        High = 2
    }
}