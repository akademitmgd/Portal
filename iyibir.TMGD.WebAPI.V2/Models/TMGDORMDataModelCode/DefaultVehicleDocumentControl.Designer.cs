﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace iyibir.TMGD.WebAPI.V2.Models.iyibir_TMGD
{

    public partial class DefaultVehicleDocumentControl : XPCustomObject
    {
        Guid fOid;
        [Key(true)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>(nameof(Oid), ref fOid, value); }
        }
        int fVControlOption;
        public int VControlOption
        {
            get { return fVControlOption; }
            set { SetPropertyValue<int>(nameof(VControlOption), ref fVControlOption, value); }
        }
        string fQuestion;
        public string Question
        {
            get { return fQuestion; }
            set { SetPropertyValue<string>(nameof(Question), ref fQuestion, value); }
        }
    }

}
