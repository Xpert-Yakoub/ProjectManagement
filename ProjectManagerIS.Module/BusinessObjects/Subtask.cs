using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
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

namespace ProjectManagerIS.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Resume")]

    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class Subtask : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Subtask(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }






        string tierName;
        DocComptes comptes;
        TypeDoc typeCompte;
        decimal amount6;
        decimal amount5;
        decimal amount4;
        decimal amount3;
        decimal amount1;
        decimal amount2;
        string reference;
        DemoTask task;
        FileData file;
        string tVA;
        DateTime endDate;
        DateTime createdON;
        CostumResolutions resolution;
        CostumTaskStatus status;



        [DevExpress.Xpo.DisplayName("Status")]
        public CostumTaskStatus Status
        {
            get => status;
            set => SetPropertyValue(nameof(Status), ref status, value);
        }



        [DevExpress.Xpo.DisplayName("Resolution")]
        [DataSourceProperty("Status.Resolution", DataSourcePropertyIsNullMode.SelectNothing)]

        public CostumResolutions Resolution
        {
            get => resolution;
            set => SetPropertyValue(nameof(Resolution), ref resolution, value);
        }

        public DateTime CreatedOn
        {
            get => createdON;
            set => SetPropertyValue(nameof(CreatedOn), ref createdON, value);
        }

        public DateTime EndDate
        {
            get => endDate;
            set => SetPropertyValue(nameof(EndDate), ref endDate, value);
        }

        public FileData File
        {
            get => file;
            set => SetPropertyValue(nameof(File), ref file, value);
        }

        public string Reference
        {
            get => reference;
            set => SetPropertyValue(nameof(Reference), ref reference, value);
        }

        
        public string TierName
        {
            get => tierName;
            set => SetPropertyValue(nameof(TierName), ref tierName, value);
        }


        
        public decimal Amount1
        {
            get => amount1;
            set => SetPropertyValue(nameof(Amount1), ref amount1, value);
        }


        public decimal Amount2
        {
            get => amount2;
            set => SetPropertyValue(nameof(Amount2), ref amount2, value);
        }


        public decimal Amount3
        {
            get => amount3;
            set => SetPropertyValue(nameof(Amount3), ref amount3, value);
        }



        public decimal Amount4
        {
            get => amount4;
            set => SetPropertyValue(nameof(Amount4), ref amount4, value);
        }


        public decimal Amount5
        {
            get => amount5;
            set => SetPropertyValue(nameof(Amount5), ref amount5, value);
        }


        public decimal Amount6
        {
            get => amount6;
            set => SetPropertyValue(nameof(Amount6), ref amount6, value);
        }




        
        public DocComptes Comptes
        {
            get => comptes;
            set => SetPropertyValue(nameof(Comptes), ref comptes, value);
        }



        [DataSourceProperty("Comptes.TypeDoc",DataSourcePropertyIsNullMode.SelectAll)]
        public TypeDoc TypeCompte
        {
            get => typeCompte;
            set => SetPropertyValue(nameof(TypeCompte), ref typeCompte, value);
        }





        [VisibleInListView(false),VisibleInDetailView(false)]

        [Association("DemoTask-Subtask")]
        public DemoTask Task
        {
            get => task;
            set => SetPropertyValue(nameof(Task), ref task, value);
        }





    }






}