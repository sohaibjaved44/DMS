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
    
    public partial class PLAN_TBL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PLAN_TBL()
        {
            this.PRDCT_TYPE = new HashSet<PRDCT_TYPE>();
        }
    
        public int Plan_id { get; set; }
        public string Plan_Name { get; set; }
        public Nullable<int> product_type { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRDCT_TYPE> PRDCT_TYPE { get; set; }
    }
}
