using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToolsCommercial.Models;

namespace ToolsCommercial.Data
{
    public class Transaksi
    {
        public int Id { get; set; }
        public string? Area { get; set; }
        public string? Location { get; set; }
        public string? Customer_No { get; set; }
        public string? Customer_Name { get; set; }
        public string? Sales_Person { get; set; }
        public string? Dscription { get; set; }
        public string? Product { get; set; }
        public float? ACT_MT { get; set; }
        public float? ACT_Gross_Sales { get; set; }
        public float? ACT_Freight_Local { get; set; }
        public float? ACT_Whs_Trf { get; set; }
        public float? ACT_Freight_Export { get; set; }
        public float? ACT_Loco_Sales { get; set; }
        public float? ACT_DM_Utility_Cost { get; set; }
        public float? ACT_CM_Excl { get; set; }
        public float? ACT_FX { get; set; }
        public float? ACT_Interest { get; set; }
        public float? ACTual_CM_Incl { get; set; }
        public float? OPEX { get; set; }
        public string? Remark { get; set; }
        public string? Month { get; set; }
        public string? Period { get; set; }
        public int? Year { get; set; }
        public float? Capacity { get; set; }
        public float? BGT_MT { get; set; }
        public float? BGT_Sales { get; set; }
        public float? BGT_VC { get; set; }
        public float? BGT_CM { get; set; }
        public float? BGT_FX { get; set; }
        public float? BGT_Interest { get; set; }
        public float? BGT_CM_Excl { get; set; }
        public float? FCT_MT { get; set; }
        public float? FCT_Sales { get; set; }
        public float? FCT_VC { get; set; }
        public float? FCT_CM { get; set; }
        public string? PLANT { get; set; }
        public string? UOM { get; set; }
        public string? Category_1_8 { get; set; }
        public string? Flour_Bran_Category { get; set; }
        public string? MPBP_Category { get; set; }
        public string? Series_Category { get; set; }
        public string? Sales_Mix { get; set; }
        public string? CONCATENATE1 { get; set; }
        public string? Customer_by_Channel { get; set; }
        public string? Customer_by_Area { get; set; }
        public string? GT_Industrial { get; set; }
        public string? Customer_Business_Size { get; set; }
        public string? Customers_Consumption { get; set; }
        public string? Product_Purpose { get; set; }
        public string? Area_Only { get; set; }
        public string? Channel_by_Product { get; set; }
        public string? Biz_Type { get; set; }
        public string? Biz_Size { get; set; }
        public DateTime UploadTime { get; set; }
        public bool IsActive { get; set; }
    }

    public class AppDbContext : IdentityDbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			   : base(options)
		{
		}

        #region Master
        public DbSet<Transaksi> Transaksis { get; set; }
        #endregion

    }


}