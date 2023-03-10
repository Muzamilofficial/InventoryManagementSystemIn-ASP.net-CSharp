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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class DbMobileInventoryEntities2 : DbContext
    {
        public DbMobileInventoryEntities2()
            : base("name=DbMobileInventoryEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<tblCompany> tblCompanies { get; set; }
        public DbSet<tblProduct> tblProducts { get; set; }
        public DbSet<tblProductCategory> tblProductCategories { get; set; }
        public DbSet<tblpurchase> tblpurchases { get; set; }
        public DbSet<tblPurchaseDetail> tblPurchaseDetails { get; set; }
        public DbSet<tblPurchaseDetailtempory> tblPurchaseDetailtempories { get; set; }
        public DbSet<tblStock> tblStocks { get; set; }
        public DbSet<tblVendor> tblVendors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<tblCustomer> tblCustomers { get; set; }
        public DbSet<tblSell> tblSells { get; set; }
        public DbSet<tblStockDetail> tblStockDetails { get; set; }
        public DbSet<tblSellDetail> tblSellDetails { get; set; }
        public DbSet<tblSellDetailtempory> tblSellDetailtempories { get; set; }
        public DbSet<tblBilling> tblBillings { get; set; }
        public DbSet<tblPatient> tblPatients { get; set; }
        public DbSet<tblInvoiceDetail> tblInvoiceDetails { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<Nullable<int>> spAddnewPurchase(Nullable<int> vendorID, Nullable<System.DateTime> purchaseDate, Nullable<int> productID, Nullable<int> qty, Nullable<int> purchasePrice, Nullable<int> saleprice, Nullable<int> isNew, Nullable<int> ptaApprove, Nullable<int> previousPurchaseID)
        {
            var vendorIDParameter = vendorID.HasValue ?
                new ObjectParameter("VendorID", vendorID) :
                new ObjectParameter("VendorID", typeof(int));
    
            var purchaseDateParameter = purchaseDate.HasValue ?
                new ObjectParameter("PurchaseDate", purchaseDate) :
                new ObjectParameter("PurchaseDate", typeof(System.DateTime));
    
            var productIDParameter = productID.HasValue ?
                new ObjectParameter("ProductID", productID) :
                new ObjectParameter("ProductID", typeof(int));
    
            var qtyParameter = qty.HasValue ?
                new ObjectParameter("Qty", qty) :
                new ObjectParameter("Qty", typeof(int));
    
            var purchasePriceParameter = purchasePrice.HasValue ?
                new ObjectParameter("PurchasePrice", purchasePrice) :
                new ObjectParameter("PurchasePrice", typeof(int));
    
            var salepriceParameter = saleprice.HasValue ?
                new ObjectParameter("Saleprice", saleprice) :
                new ObjectParameter("Saleprice", typeof(int));
    
            var isNewParameter = isNew.HasValue ?
                new ObjectParameter("IsNew", isNew) :
                new ObjectParameter("IsNew", typeof(int));
    
            var ptaApproveParameter = ptaApprove.HasValue ?
                new ObjectParameter("PtaApprove", ptaApprove) :
                new ObjectParameter("PtaApprove", typeof(int));
    
            var previousPurchaseIDParameter = previousPurchaseID.HasValue ?
                new ObjectParameter("PreviousPurchaseID", previousPurchaseID) :
                new ObjectParameter("PreviousPurchaseID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spAddnewPurchase", vendorIDParameter, purchaseDateParameter, productIDParameter, qtyParameter, purchasePriceParameter, salepriceParameter, isNewParameter, ptaApproveParameter, previousPurchaseIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> spAddnewSellRecord(Nullable<int> customerID, Nullable<System.DateTime> sellDate, Nullable<int> productID, Nullable<int> qty, Nullable<int> saleprice, Nullable<int> isNew, Nullable<int> ptaApprove, Nullable<int> previousSellID)
        {
            var customerIDParameter = customerID.HasValue ?
                new ObjectParameter("CustomerID", customerID) :
                new ObjectParameter("CustomerID", typeof(int));
    
            var sellDateParameter = sellDate.HasValue ?
                new ObjectParameter("SellDate", sellDate) :
                new ObjectParameter("SellDate", typeof(System.DateTime));
    
            var productIDParameter = productID.HasValue ?
                new ObjectParameter("ProductID", productID) :
                new ObjectParameter("ProductID", typeof(int));
    
            var qtyParameter = qty.HasValue ?
                new ObjectParameter("Qty", qty) :
                new ObjectParameter("Qty", typeof(int));
    
            var salepriceParameter = saleprice.HasValue ?
                new ObjectParameter("Saleprice", saleprice) :
                new ObjectParameter("Saleprice", typeof(int));
    
            var isNewParameter = isNew.HasValue ?
                new ObjectParameter("IsNew", isNew) :
                new ObjectParameter("IsNew", typeof(int));
    
            var ptaApproveParameter = ptaApprove.HasValue ?
                new ObjectParameter("PtaApprove", ptaApprove) :
                new ObjectParameter("PtaApprove", typeof(int));
    
            var previousSellIDParameter = previousSellID.HasValue ?
                new ObjectParameter("PreviousSellID", previousSellID) :
                new ObjectParameter("PreviousSellID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spAddnewSellRecord", customerIDParameter, sellDateParameter, productIDParameter, qtyParameter, salepriceParameter, isNewParameter, ptaApproveParameter, previousSellIDParameter);
        }
    
        public virtual ObjectResult<spAutoInsertSellPrices_Result1> spAutoInsertSellPrices(string productName)
        {
            var productNameParameter = productName != null ?
                new ObjectParameter("ProductName", productName) :
                new ObjectParameter("ProductName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spAutoInsertSellPrices_Result1>("spAutoInsertSellPrices", productNameParameter);
        }
    
        public virtual ObjectResult<spcustomerupdate_Result1> spcustomerupdate(string firstname, string lastname)
        {
            var firstnameParameter = firstname != null ?
                new ObjectParameter("firstname", firstname) :
                new ObjectParameter("firstname", typeof(string));
    
            var lastnameParameter = lastname != null ?
                new ObjectParameter("lastname", lastname) :
                new ObjectParameter("lastname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spcustomerupdate_Result1>("spcustomerupdate", firstnameParameter, lastnameParameter);
        }
    
        public virtual ObjectResult<SpfilldataSale_Result1> SpfilldataSale(Nullable<int> customerid, Nullable<System.DateTime> selldate, Nullable<int> amountpaid, Nullable<bool> isNew, Nullable<bool> pTAApprove)
        {
            var customeridParameter = customerid.HasValue ?
                new ObjectParameter("Customerid", customerid) :
                new ObjectParameter("Customerid", typeof(int));
    
            var selldateParameter = selldate.HasValue ?
                new ObjectParameter("selldate", selldate) :
                new ObjectParameter("selldate", typeof(System.DateTime));
    
            var amountpaidParameter = amountpaid.HasValue ?
                new ObjectParameter("amountpaid", amountpaid) :
                new ObjectParameter("amountpaid", typeof(int));
    
            var isNewParameter = isNew.HasValue ?
                new ObjectParameter("IsNew", isNew) :
                new ObjectParameter("IsNew", typeof(bool));
    
            var pTAApproveParameter = pTAApprove.HasValue ?
                new ObjectParameter("PTAApprove", pTAApprove) :
                new ObjectParameter("PTAApprove", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SpfilldataSale_Result1>("SpfilldataSale", customeridParameter, selldateParameter, amountpaidParameter, isNewParameter, pTAApproveParameter);
        }
    
        public virtual ObjectResult<Spsearchproduct_Result1> Spsearchproduct(string pName)
        {
            var pNameParameter = pName != null ?
                new ObjectParameter("PName", pName) :
                new ObjectParameter("PName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Spsearchproduct_Result1>("Spsearchproduct", pNameParameter);
        }
    
        public virtual ObjectResult<SpsearchProductInStock2_Result1> SpsearchProductInStock2(string pName)
        {
            var pNameParameter = pName != null ?
                new ObjectParameter("PName", pName) :
                new ObjectParameter("PName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SpsearchProductInStock2_Result1>("SpsearchProductInStock2", pNameParameter);
        }
    
        public virtual ObjectResult<SpsearchProductInStockFirst_Result1> SpsearchProductInStockFirst(string cName)
        {
            var cNameParameter = cName != null ?
                new ObjectParameter("CName", cName) :
                new ObjectParameter("CName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SpsearchProductInStockFirst_Result1>("SpsearchProductInStockFirst", cNameParameter);
        }
    
        public virtual ObjectResult<Spsearchstockproduct_Result1> Spsearchstockproduct()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Spsearchstockproduct_Result1>("Spsearchstockproduct");
        }
    
        public virtual ObjectResult<spViewInvoiceDetails2_Result1> spViewInvoiceDetails2()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spViewInvoiceDetails2_Result1>("spViewInvoiceDetails2");
        }
    
        public virtual ObjectResult<spViewReapeaterDataOnTextChangedNew3_Result1> spViewReapeaterDataOnTextChangedNew3(string productname)
        {
            var productnameParameter = productname != null ?
                new ObjectParameter("productname", productname) :
                new ObjectParameter("productname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spViewReapeaterDataOnTextChangedNew3_Result1>("spViewReapeaterDataOnTextChangedNew3", productnameParameter);
        }
    
        public virtual ObjectResult<spViewRepeaterDataOfformSell_Result1> spViewRepeaterDataOfformSell()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spViewRepeaterDataOfformSell_Result1>("spViewRepeaterDataOfformSell");
        }
    
        public virtual ObjectResult<spViewRepeaterDataOfPurchaseForm2_Result1> spViewRepeaterDataOfPurchaseForm2()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spViewRepeaterDataOfPurchaseForm2_Result1>("spViewRepeaterDataOfPurchaseForm2");
        }
    
        public virtual int Validate_User(string username, string password)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Validate_User", usernameParameter, passwordParameter);
        }
    }
}
