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
    public class Empolyees : ApplicationUser
    {
        public Empolyees(Session session) : base(session) { }


        string personName;

        public string PersonName
        {
            get => personName;
            set => SetPropertyValue(nameof(PersonName), ref personName, value);
        }


    }
}