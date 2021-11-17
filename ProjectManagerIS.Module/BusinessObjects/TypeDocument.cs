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
    public class TypeDoc : BaseObject
    {
        public TypeDoc(Session session) : base(session) { }



        DocComptes compte;
        String typeName;
        string typeCode;

        public string TypeCode
        {
            get => typeCode;
            set => SetPropertyValue(nameof(TypeCode), ref typeCode, value);
        }


        public String TypeName
        {
            get => typeName;
            set => SetPropertyValue(nameof(TypeName), ref typeName, value);
        }


        [Association("DocTypes,DocComptes")]
        public DocComptes Compte
        {
            get => compte;
            set => SetPropertyValue(nameof(Compte), ref compte, value);
        }



    }
}