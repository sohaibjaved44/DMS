//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DCMNT_TBL
    {
        public long DCMT_ID { get; set; }
        public string PLCY_NUM { get; set; }
        public string SCAN_DTE { get; set; }
        public string FILE_NME { get; set; }
        public string FRST_NME { get; set; }
        public string LAST_NME { get; set; }
        public string STRG_LOC { get; set; }
        public string DCMT_NTE { get; set; }
        public Nullable<bool> DCMT_IsChk { get; set; }
        public Nullable<bool> DCMT_IsScan { get; set; }
        public string SCAN_TME { get; set; }
        public Nullable<int> USER_ID { get; set; }
        public Nullable<int> DCMT_TYPE_ID { get; set; }
        public Nullable<int> PLCY_ID { get; set; }
        public Nullable<int> PLAN_ID { get; set; }
        public Nullable<int> PRDCT_TYPE_ID { get; set; }
        public Nullable<int> EXTN_ID { get; set; }
        public Nullable<int> DEPT_ID { get; set; }
    }
}