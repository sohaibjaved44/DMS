//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel;

namespace DMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRDCT_TYPE
    {
        [DisplayName("Product Type Id")]
        public int Product_type_id { get; set; }
        [DisplayName("Product Name")]
        public string Product_name { get; set; }
        [DisplayName("Plan Id")]
        public Nullable<int> Plan_id { get; set; }
    
        public virtual PLAN_TBL PLAN_TBL { get; set; }
    }
}