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
    
    public partial class tblPurchaseDetail
    {
        public int PurchaseDetailsID { get; set; }
        public Nullable<int> PurchaseID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public string Model { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> PurchasePrice { get; set; }
        public Nullable<int> SellPrice { get; set; }
        public Nullable<bool> IsNew { get; set; }
        public Nullable<bool> PTAApprove { get; set; }
    
        public virtual tblProduct tblProduct { get; set; }
        public virtual tblpurchase tblpurchase { get; set; }
    }
}