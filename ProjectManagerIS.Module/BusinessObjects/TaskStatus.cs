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

namespace ProjectManagerIS.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Status")]
    [XafDefaultProperty(nameof(Status))]

    public class CostumTaskStatus : BaseObject
    {
        public CostumTaskStatus(Session session) : base(session) { }

        private string status;
        public string Status
        {
            get { return status; }
            set { SetPropertyValue(nameof(Status), ref status, value); }
        }


        [Association("TaskStatus,Resolution")]
        [DevExpress.Xpo.DisplayName("Resolution")]
        public XPCollection<CostumResolutions> Resolution
        {
            get { return GetCollection<CostumResolutions>(nameof(Resolution)); }
        }




    }
}