//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication5
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblVendor
    {
        public tblVendor()
        {
            this.tblpurchases = new HashSet<tblpurchase>();
        }
    
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string VendorAddress { get; set; }
        public string CNIC { get; set; }
    
        public virtual ICollection<tblpurchase> tblpurchases { get; set; }
    }
}
