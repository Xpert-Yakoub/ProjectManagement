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
    [System.ComponentModel.DefaultProperty(nameof(CostumResolutions))]
    [System.ComponentModel.DisplayName("Resolution")]

    public class CostumResolutions : BaseObject
    {
        public CostumResolutions(Session session) : base(session) { }




        private string resolutionName;
        [DevExpress.Xpo.DisplayName("Resolution")]
        public string ResolutionName
        {
            get { return resolutionName; }
            set { SetPropertyValue(nameof(ResolutionName), ref resolutionName, value); }
        }




        [Association("TaskStatus,Resolution")]
        [DevExpress.Xpo.DisplayName("Status")]
        public XPCollection<CostumTaskStatus> TaskStatus
        {
            get { return GetCollection<CostumTaskStatus>(nameof(TaskStatus)); }
        }

    }
}