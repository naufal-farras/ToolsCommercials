using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OfficeOpenXml;
using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Security.Principal;
using Dapper;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using ToolsCommercial.Data;
using ToolsCommercial.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;

namespace ToolsCommercial.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly IDbConnection _dbConnection;
        public HomeController(ILogger<HomeController> logger, AppDbContext context, IDbConnection dbConnection)
        {
            _logger = logger;
            _context = context;
            _dbConnection = dbConnection;
        }
        public class UpdateRequest
        {
            public int Id { get; set; }
            public int Column { get; set; }
            public string Value { get; set; }
        }

        // Action to get distinct values based on the selected header

        public IActionResult GetDistinctValues(string header)
        {
            List<string> distinctValues = new List<string>();

            switch (header)
            {
                case "Area":
                    distinctValues = _context.Transaksis.Select(t => t.Area).Distinct().ToList();
                    break;
                case "Location":
                    distinctValues = _context.Transaksis.Select(t => t.Location).Distinct().ToList();
                    break;
                case "Customer_No":
                    distinctValues = _context.Transaksis.Select(t => t.Customer_No).Distinct().ToList();
                    break;
                case "Customer_Name":
                    distinctValues = _context.Transaksis.Select(t => t.Customer_Name).Distinct().ToList();
                    break;
                case "Sales_Person":
                    distinctValues = _context.Transaksis.Select(t => t.Sales_Person).Distinct().ToList();
                    break;
                case "Dscription":
                    distinctValues = _context.Transaksis.Select(t => t.Dscription).Distinct().ToList();
                    break;
                case "Product":
                    distinctValues = _context.Transaksis.Select(t => t.Product).Distinct().ToList();
                    break;
                case "ACT_MT":
                    distinctValues = _context.Transaksis.Select(t => t.ACT_MT.ToString()).Distinct().ToList();
                    break;
                case "ACT_Gross_Sales":
                    distinctValues = _context.Transaksis.Select(t => t.ACT_Gross_Sales.ToString()).Distinct().ToList();
                    break;
                case "ACT_Freight_Local":
                    distinctValues = _context.Transaksis.Select(t => t.ACT_Freight_Local.ToString()).Distinct().ToList();
                    break;
                case "ACT_Whs_Trf":
                    distinctValues = _context.Transaksis.Select(t => t.ACT_Whs_Trf.ToString()).Distinct().ToList();
                    break;
                case "ACT_Freight_Export":
                    distinctValues = _context.Transaksis.Select(t => t.ACT_Freight_Export.ToString()).Distinct().ToList();
                    break;
                case "ACT_Loco_Sales":
                    distinctValues = _context.Transaksis.Select(t => t.ACT_Loco_Sales.ToString()).Distinct().ToList();
                    break;
                case "ACT_DM_Utility_Cost":
                    distinctValues = _context.Transaksis.Select(t => t.ACT_DM_Utility_Cost.ToString()).Distinct().ToList();
                    break;
                case "ACT_CM_Excl":
                    distinctValues = _context.Transaksis.Select(t => t.ACT_CM_Excl.ToString()).Distinct().ToList();
                    break;
                case "ACT_FX":
                    distinctValues = _context.Transaksis.Select(t => t.ACT_FX.ToString()).Distinct().ToList();
                    break;
                case "ACT_Interest":
                    distinctValues = _context.Transaksis.Select(t => t.ACT_Interest.ToString()).Distinct().ToList();
                    break;
                case "ACTual_CM_Incl":
                    distinctValues = _context.Transaksis.Select(t => t.ACTual_CM_Incl.ToString()).Distinct().ToList();
                    break;
                case "OPEX":
                    distinctValues = _context.Transaksis.Select(t => t.OPEX.ToString()).Distinct().ToList();
                    break;
                case "Remark":
                    distinctValues = _context.Transaksis.Select(t => t.Remark).Distinct().ToList();
                    break;
                case "Month":
                    distinctValues = _context.Transaksis.Select(t => t.Month.ToString()).Distinct().ToList();
                    break;
                case "Period":
                    distinctValues = _context.Transaksis.Select(t => t.Period.ToString()).Distinct().ToList();
                    break;
                case "Year":
                    distinctValues = _context.Transaksis.Select(t => t.Year.ToString()).Distinct().ToList();
                    break;
                case "Capacity":
                    distinctValues = _context.Transaksis.Select(t => t.Capacity.ToString()).Distinct().ToList();
                    break;
                case "BGT_MT":
                    distinctValues = _context.Transaksis.Select(t => t.BGT_MT.ToString()).Distinct().ToList();
                    break;
                case "BGT_Sales":
                    distinctValues = _context.Transaksis.Select(t => t.BGT_Sales.ToString()).Distinct().ToList();
                    break;
                case "BGT_VC":
                    distinctValues = _context.Transaksis.Select(t => t.BGT_VC.ToString()).Distinct().ToList();
                    break;
                case "BGT_CM":
                    distinctValues = _context.Transaksis.Select(t => t.BGT_CM.ToString()).Distinct().ToList();
                    break;
                case "BGT_FX":
                    distinctValues = _context.Transaksis.Select(t => t.BGT_FX.ToString()).Distinct().ToList();
                    break;
                case "BGT_Interest":
                    distinctValues = _context.Transaksis.Select(t => t.BGT_Interest.ToString()).Distinct().ToList();
                    break;
                case "BGT_CM_Excl":
                    distinctValues = _context.Transaksis.Select(t => t.BGT_CM_Excl.ToString()).Distinct().ToList();
                    break;
                case "FCT_MT":
                    distinctValues = _context.Transaksis.Select(t => t.FCT_MT.ToString()).Distinct().ToList();
                    break;
                case "FCT_Sales":
                    distinctValues = _context.Transaksis.Select(t => t.FCT_Sales.ToString()).Distinct().ToList();
                    break;
                case "FCT_VC":
                    distinctValues = _context.Transaksis.Select(t => t.FCT_VC.ToString()).Distinct().ToList();
                    break;
                case "FCT_CM":
                    distinctValues = _context.Transaksis.Select(t => t.FCT_CM.ToString()).Distinct().ToList();
                    break;
                case "PLANT":
                    distinctValues = _context.Transaksis.Select(t => t.PLANT).Distinct().ToList();
                    break;
                case "UOM":
                    distinctValues = _context.Transaksis.Select(t => t.UOM).Distinct().ToList();
                    break;
                case "Category_1_8":
                    distinctValues = _context.Transaksis.Select(t => t.Category_1_8).Distinct().ToList();
                    break;
                case "Flour_Bran_Category":
                    distinctValues = _context.Transaksis.Select(t => t.Flour_Bran_Category).Distinct().ToList();
                    break;
                case "MPBP_Category":
                    distinctValues = _context.Transaksis.Select(t => t.MPBP_Category).Distinct().ToList();
                    break;
                case "Series_Category":
                    distinctValues = _context.Transaksis.Select(t => t.Series_Category).Distinct().ToList();
                    break;
                case "Sales_Mix":
                    distinctValues = _context.Transaksis.Select(t => t.Sales_Mix).Distinct().ToList();
                    break;
                case "CONCATENATE1":
                    distinctValues = _context.Transaksis.Select(t => t.CONCATENATE1).Distinct().ToList();
                    break;
                case "Customer_by_Channel":
                    distinctValues = _context.Transaksis.Select(t => t.Customer_by_Channel).Distinct().ToList();
                    break;
                case "Customer_by_Area":
                    distinctValues = _context.Transaksis.Select(t => t.Customer_by_Area).Distinct().ToList();
                    break;
                case "GT_Industrial":
                    distinctValues = _context.Transaksis.Select(t => t.GT_Industrial).Distinct().ToList();
                    break;
                case "Customer_Business_Size":
                    distinctValues = _context.Transaksis.Select(t => t.Customer_Business_Size).Distinct().ToList();
                    break;
                case "Customers_Consumption":
                    distinctValues = _context.Transaksis.Select(t => t.Customers_Consumption).Distinct().ToList();
                    break;
                case "Product_Purpose":
                    distinctValues = _context.Transaksis.Select(t => t.Product_Purpose).Distinct().ToList();
                    break;
                case "Area_Only":
                    distinctValues = _context.Transaksis.Select(t => t.Area_Only).Distinct().ToList();
                    break;
                case "Channel_by_Product":
                    distinctValues = _context.Transaksis.Select(t => t.Channel_by_Product).Distinct().ToList();
                    break;
                case "Biz_Type":
                    distinctValues = _context.Transaksis.Select(t => t.Biz_Type).Distinct().ToList();
                    break;
                case "Biz_Size":
                    distinctValues = _context.Transaksis.Select(t => t.Biz_Size).Distinct().ToList();
                    break;
            }

            return Json(distinctValues);
        }
        public IActionResult GetDistinctValues2(string selectedHeader1, string distinctValue, string selectedHeader2)
        {
            List<string> distinctValues = new List<string>();

            // Ensure all parameters are provided
            if (string.IsNullOrEmpty(selectedHeader1) || string.IsNullOrEmpty(distinctValue) || string.IsNullOrEmpty(selectedHeader2))
            {
                return Json(distinctValues);
            }

            // Build the query dynamically based on the selected headers
            var query = _context.Transaksis.AsQueryable();

            // Filter by the first header and distinct value
            switch (selectedHeader1)
            {
                case "Area":
                    query = query.Where(t => t.Area == distinctValue);
                    break;
                case "Location":
                    query = query.Where(t => t.Location == distinctValue);
                    break;
                case "Customer_No":
                    query = query.Where(t => t.Customer_No == distinctValue);
                    break;
                case "Customer_Name":
                    query = query.Where(t => t.Customer_Name == distinctValue);
                    break;
                case "Sales_Person":
                    query = query.Where(t => t.Sales_Person == distinctValue);
                    break;

                case "Dscription":
                    query = query.Where(t => t.Dscription == distinctValue);
                    break;
                case "Product":
                    query = query.Where(t => t.Product == distinctValue);
                    break;
                case "ACT_MT":
                    query = query.Where(t => t.ACT_MT.ToString() == distinctValue);
                    break;
                case "ACT_Gross_Sales":
                    query = query.Where(t => t.ACT_Gross_Sales.ToString() == distinctValue);
                    break;
            }

            // Get distinct values based on the second header
            switch (selectedHeader2)
            {
                case "Sales_Person":
                    distinctValues = query.Select(t => t.Sales_Person).Distinct().ToList();
                    break;
                case "Product":
                    distinctValues = query.Select(t => t.Product).Distinct().ToList();
                    break;
                case "Month":
                    distinctValues = query.Select(t => t.Month).Distinct().ToList();
                    break;
                case "Customer_Name":
                    distinctValues = query.Select(t => t.Customer_Name).Distinct().ToList();
                    break;
                case "Customer_No":
                    distinctValues = query.Select(t => t.Customer_No).Distinct().ToList();
                    break;
                case "Location":
                    distinctValues = query.Select(t => t.Location).Distinct().ToList();
                    break;
                case "Area":
                    distinctValues = query.Select(t => t.Area).Distinct().ToList();
                    break;
            }

            return Json(distinctValues);
        }

        public IActionResult SubmitData([FromBody] SubmitDataRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Header1) || string.IsNullOrEmpty(request.DistinctValue) || string.IsNullOrEmpty(request.InputText))
            {
                return BadRequest("Invalid data.");
            }

            // Build the SQL update query dynamically
            string sql = $"UPDATE Transaksis SET {request.Header2} = REPLACE({request.Header2}, @OldValue, @NewValue) WHERE {request.Header1} = @DistinctValue";

            // Create parameters
            var parameters = new
            {
                OldValue = request.DistinctValue2, // This should be the value to replace
                NewValue = request.InputText,      // This is the new value to set
                DistinctValue = request.DistinctValue // This is the value to filter by
            };

            // Execute the SQL command using Dapper
            var affectedRows = _dbConnection.Execute(sql, parameters);

            if (affectedRows > 0)
            {
                return Ok("Data updated successfully.");
            }
            else
            {
                return NotFound("No records found to update.");
            }
        }

        public class UpdateParameters
        {
            public string OldValue { get; set; }
            public string NewValue { get; set; }
            public string DistinctValue { get; set; }
        }
        // Model for the submitted data
        public class SubmitDataRequest
        {
            public string Header1 { get; set; }
            public string DistinctValue { get; set; }
            public string Header2 { get; set; }
            public string DistinctValue2 { get; set; }
            public string InputText { get; set; }
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");
            if (file.FileName.EndsWith("xlsx") || file.FileName.EndsWith("XLSX"))
            {
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Use 

                    using (var package = new ExcelPackage(stream))
                    {

                        var worksheet = package.Workbook.Worksheets[0];
                        var cekcolom1 = worksheet.Cells[1, 1].Text;
                        var cekcolom2 = worksheet.Cells[1, 53].Text;
                        var rowCount = worksheet.Dimension.Rows;
                        if (cekcolom1 == "Area" && cekcolom2 == "Biz Size")
                        {
                            for (int row = 2; row <= rowCount; row++)
                            {
                                var Remark = worksheet.Cells[row, 20].Text;
                                if (Remark == "" || Remark == null)
                                {
                                    continue;
                                }
                                var transaksi = new Transaksi
                                {
                                    Area = worksheet.Cells[row, 1].Text,
                                    Location = worksheet.Cells[row, 2].Text,
                                    Customer_No = worksheet.Cells[row, 3].Text,
                                    Customer_Name = worksheet.Cells[row, 4].Text,
                                    Sales_Person = worksheet.Cells[row, 5].Text,
                                    Dscription = worksheet.Cells[row, 6].Text,
                                    Product = worksheet.Cells[row, 7].Text,
                                    ACT_MT = TryParseFloat(worksheet.Cells[row, 8].Text),
                                    ACT_Gross_Sales = TryParseFloat(worksheet.Cells[row, 9].Text),
                                    ACT_Freight_Local = TryParseFloat(worksheet.Cells[row, 10].Text),
                                    ACT_Whs_Trf = TryParseFloat(worksheet.Cells[row, 11].Text),
                                    ACT_Freight_Export = TryParseFloat(worksheet.Cells[row, 12].Text),
                                    ACT_Loco_Sales = TryParseFloat(worksheet.Cells[row, 13].Text),
                                    ACT_DM_Utility_Cost = TryParseFloat(worksheet.Cells[row, 14].Text),
                                    ACT_CM_Excl = TryParseFloat(worksheet.Cells[row, 15].Text),
                                    ACT_FX = TryParseFloat(worksheet.Cells[row, 16].Text),
                                    ACT_Interest = TryParseFloat(worksheet.Cells[row, 17].Text),
                                    ACTual_CM_Incl = TryParseFloat(worksheet.Cells[row, 18].Text),
                                    OPEX = TryParseFloat(worksheet.Cells[row, 19].Text),
                                    Remark = worksheet.Cells[row, 20].Text,
                                    Month = worksheet.Cells[row, 21].Text,
                                    Period = worksheet.Cells[row, 22].Text,
                                    Year = int.TryParse(worksheet.Cells[row, 23].Text, out var year) ? year : 0,
                                    Capacity = TryParseFloat(worksheet.Cells[row, 24].Text),
                                    BGT_MT = TryParseFloat(worksheet.Cells[row, 25].Text),
                                    BGT_Sales = TryParseFloat(worksheet.Cells[row, 26].Text),
                                    BGT_VC = TryParseFloat(worksheet.Cells[row, 27].Text),
                                    BGT_CM = TryParseFloat(worksheet.Cells[row, 28].Text),
                                    BGT_FX = TryParseFloat(worksheet.Cells[row, 29].Text),
                                    BGT_Interest = TryParseFloat(worksheet.Cells[row, 30].Text),
                                    BGT_CM_Excl = TryParseFloat(worksheet.Cells[row, 31].Text),
                                    FCT_MT = TryParseFloat(worksheet.Cells[row, 32].Text),
                                    FCT_Sales = TryParseFloat(worksheet.Cells[row, 33].Text),
                                    FCT_VC = TryParseFloat(worksheet.Cells[row, 34].Text),
                                    FCT_CM = TryParseFloat(worksheet.Cells[row, 35].Text),
                                    PLANT = worksheet.Cells[row, 36].Text,
                                    UOM = worksheet.Cells[row, 37].Text,
                                    Category_1_8 = worksheet.Cells[row, 38].Text,
                                    Flour_Bran_Category = worksheet.Cells[row, 39].Text,
                                    MPBP_Category = worksheet.Cells[row, 40].Text,
                                    Series_Category = worksheet.Cells[row, 41].Text,
                                    Sales_Mix = worksheet.Cells[row, 42].Text,
                                    CONCATENATE1 = worksheet.Cells[row, 43].Text,
                                    Customer_by_Channel = worksheet.Cells[row, 44].Text,
                                    Customer_by_Area = worksheet.Cells[row, 45].Text,
                                    GT_Industrial = worksheet.Cells[row, 46].Text,
                                    Customer_Business_Size = worksheet.Cells[row, 47].Text,
                                    Customers_Consumption = worksheet.Cells[row, 48].Text,
                                    Product_Purpose = worksheet.Cells[row, 49].Text,
                                    Area_Only = worksheet.Cells[row, 50].Text,
                                    Channel_by_Product = worksheet.Cells[row, 51].Text,
                                    Biz_Type = worksheet.Cells[row, 52].Text,
                                    Biz_Size = worksheet.Cells[row, 53].Text,
                                    UploadTime = DateTime.Now,
                                    IsActive = true
                                };

                                _context.Transaksis.Add(transaksi);
                            }

                            _context.SaveChanges();
                        }
                        else
                        {

                            return BadRequest("Format Header Salah !");

                        }

                    }
                }

                return Ok("File uploaded and data inserted successfully.");

            }
            else
            {
                return BadRequest("Format Salah harus XLSX.");
            }


        }
        public IActionResult Update([FromBody] Transaksi request)
        {

            if (request == null || request.Id <= 0)
            {
                return BadRequest("Invalid request.");
            }

            // Find the existing record in the database
            var transaksi = _context.Transaksis.Find(request.Id);
            if (transaksi == null)
            {
                return NotFound("Record not found.");
            }

            // Update the properties based on the request data
            if (request.IsActive != null && request.IsActive != transaksi.IsActive)
            {
                transaksi.IsActive = request.IsActive;
                _context.SaveChanges();

                return Ok("Update successful.");
            }

            transaksi.Area = request.Area;
            transaksi.Location = request.Location;
            transaksi.Customer_No = request.Customer_No;
            transaksi.Customer_Name = request.Customer_Name;
            transaksi.Sales_Person = request.Sales_Person;
            transaksi.Dscription = request.Dscription;
            transaksi.Product = request.Product;
            if (request.ACT_MT.HasValue) transaksi.ACT_MT = request.ACT_MT.Value;
            if (request.ACT_Gross_Sales.HasValue) transaksi.ACT_Gross_Sales = request.ACT_Gross_Sales.Value;
            if (request.ACT_Freight_Local.HasValue) transaksi.ACT_Freight_Local = request.ACT_Freight_Local.Value;
            if (request.ACT_Whs_Trf.HasValue) transaksi.ACT_Whs_Trf = request.ACT_Whs_Trf.Value;
            if (request.ACT_Freight_Export.HasValue) transaksi.ACT_Freight_Export = request.ACT_Freight_Export.Value;
            if (request.ACT_Loco_Sales.HasValue) transaksi.ACT_Loco_Sales = request.ACT_Loco_Sales.Value;
            if (request.ACT_DM_Utility_Cost.HasValue) transaksi.ACT_DM_Utility_Cost = request.ACT_DM_Utility_Cost.Value;
            if (request.ACT_CM_Excl.HasValue) transaksi.ACT_CM_Excl = request.ACT_CM_Excl.Value;
            if (request.ACT_FX.HasValue) transaksi.ACT_FX = request.ACT_FX.Value;
            if (request.ACT_Interest.HasValue) transaksi.ACT_Interest = request.ACT_Interest.Value;
            if (request.ACTual_CM_Incl.HasValue) transaksi.ACTual_CM_Incl = request.ACTual_CM_Incl.Value;
            if (request.OPEX.HasValue) transaksi.OPEX = request.OPEX.Value;
            transaksi.Remark = request.Remark;
            transaksi.Month = request.Month;
            transaksi.Period = request.Period;
            if (request.Year.HasValue) transaksi.Year = request.Year.Value;
            if (request.Capacity.HasValue) transaksi.Capacity = request.Capacity.Value;
            if (request.BGT_MT.HasValue) transaksi.BGT_MT = request.BGT_MT.Value;
            if (request.BGT_Sales.HasValue) transaksi.BGT_Sales = request.BGT_Sales.Value;
            if (request.BGT_VC.HasValue) transaksi.BGT_VC = request.BGT_VC.Value;
            if (request.BGT_CM.HasValue) transaksi.BGT_CM = request.BGT_CM.Value;
            if (request.BGT_FX.HasValue) transaksi.BGT_FX = request.BGT_FX.Value;
            if (request.BGT_Interest.HasValue) transaksi.BGT_Interest = request.BGT_Interest.Value;
            if (request.BGT_CM_Excl.HasValue) transaksi.BGT_CM_Excl = request.BGT_CM_Excl.Value;
            if (request.FCT_MT.HasValue) transaksi.FCT_MT = request.FCT_MT.Value;
            if (request.FCT_Sales.HasValue) transaksi.FCT_Sales = request.FCT_Sales.Value;
            if (request.FCT_VC.HasValue) transaksi.FCT_VC = request.FCT_VC.Value;
            if (request.FCT_CM.HasValue) transaksi.FCT_CM = request.FCT_CM.Value;
            transaksi.PLANT = request.PLANT;
            transaksi.UOM = request.UOM;
            transaksi.Category_1_8 = request.Category_1_8;
            transaksi.Flour_Bran_Category = request.Flour_Bran_Category;
            transaksi.MPBP_Category = request.MPBP_Category;
            transaksi.Series_Category = request.Series_Category;
            transaksi.Sales_Mix = request.Sales_Mix;
            transaksi.CONCATENATE1 = request.CONCATENATE1;
            transaksi.Customer_by_Channel = request.Customer_by_Channel;
            transaksi.Customer_by_Area = request.Customer_by_Area;
            transaksi.GT_Industrial = request.GT_Industrial;
            transaksi.Customer_Business_Size = request.Customer_Business_Size;
            transaksi.Customers_Consumption = request.Customers_Consumption;
            transaksi.Product_Purpose = request.Product_Purpose;
            transaksi.Area_Only = request.Area_Only;
            transaksi.Channel_by_Product = request.Channel_by_Product;
            transaksi.Biz_Type = request.Biz_Type;
            transaksi.Biz_Size = request.Biz_Size;
            // Save changes to the database
            _context.SaveChanges();

            return Ok("Update successful.");
        }
        private float TryParseFloat(string value)
        {
            if (float.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out float result))
            {
                return result;
            }
            return 0; // or handle as needed (e.g., log the error, throw an exception, etc.)
        }
        #region gett all dropdown
        // Endpoint untuk mendapatkan distinct Area
        [HttpGet("api/transaksi/distinct/area")]
        public ActionResult<IEnumerable<string>> GetDistinctArea()
        {
            var distinctAreas = _context.Transaksis
                .Select(t => t.Area)
                .Distinct()
                .ToList();

            return Ok(distinctAreas);
        }

        // Endpoint untuk mendapatkan distinct Customer_Name
        [HttpGet("api/transaksi/distinct/customer-name")]
        public ActionResult<IEnumerable<string>> GetDistinctCustomerName()
        {
            var distinctCustomerNames = _context.Transaksis
                .Select(t => t.Customer_Name)
                .Distinct()
                .ToList();

            return Ok(distinctCustomerNames);
        }

        // Endpoint untuk mendapatkan distinct Product
        [HttpGet("api/transaksi/distinct/product")]
        public ActionResult<IEnumerable<string>> GetDistinctProduct()
        {
            var distinctProducts = _context.Transaksis
                .Select(t => t.Product)
                .Distinct()
                .ToList();

            return Ok(distinctProducts);
        }

        // Endpoint untuk mendapatkan distinct Remark
        [HttpGet("api/transaksi/distinct/remark")]
        public ActionResult<IEnumerable<string>> GetDistinctRemark()
        {
            var distinctRemarks = _context.Transaksis
                .Select(t => t.Remark)
                .Distinct()
                .ToList();

            return Ok(distinctRemarks);
        }

        // Endpoint untuk mendapatkan distinct Month
        [HttpGet("api/transaksi/distinct/month")]
        public ActionResult<IEnumerable<string>> GetDistinctMonth()
        {
            var distinctMonths = _context.Transaksis
                .Select(t => t.Month)
                .Distinct()
                .ToList();

            return Ok(distinctMonths);
        }

        // Endpoint untuk mendapatkan distinct Period
        [HttpGet("api/transaksi/distinct/period")]
        public ActionResult<IEnumerable<string>> GetDistinctPeriod()
        {
            var distinctPeriods = _context.Transaksis
                .Select(t => t.Period)
                .Distinct()
                .ToList();

            return Ok(distinctPeriods);
        }

        // Endpoint untuk mendapatkan distinct Year 
        public ActionResult<IEnumerable<int>> GetDistinctYear()
        {
            var distinctYears = _context.Transaksis
                .Select(t => t.Year)
                .Distinct()
                .ToList();

            return Ok(distinctYears);
        }

        // Endpoint untuk mendapatkan distinct PLANT 
        public ActionResult<IEnumerable<string>> GetDistinctPlant()
        {
            var distinctPlants = _context.Transaksis
                .Select(t => t.PLANT)
                .Distinct()
                .ToList();

            return Ok(distinctPlants);
        }

        // Endpoint untuk mendapatkan distinct Category_1_8 
        public ActionResult<IEnumerable<string>> GetDistinctCategory1_8()
        {
            var distinctCategories1_8 = _context.Transaksis
                .Select(t => t.Category_1_8)
                .Distinct()
                .ToList();

            return Ok(distinctCategories1_8);
        }

        // Endpoint untuk mendapatkan distinct Flour_Bran_Category 
        public ActionResult<IEnumerable<string>> GetDistinctFlourBranCategory()
        {
            var distinctFlourBranCategories = _context.Transaksis
                .Select(t => t.Flour_Bran_Category)
                .Distinct()
                .ToList();

            return Ok(distinctFlourBranCategories);
        }

        // Endpoint untuk mendapatkan distinct MPBP_Category 
        public ActionResult<IEnumerable<string>> GetDistinctMPBP_Category()
        {
            var distinctMPBPCategories = _context.Transaksis
                .Select(t => t.MPBP_Category)
                .Distinct()
                .ToList();

            return Ok(distinctMPBPCategories);
        }

        // Endpoint untuk mendapatkan distinct Series_Category 
        public ActionResult<IEnumerable<string>> GetDistinctSeriesCategory()
        {
            var distinctSeriesCategories = _context.Transaksis
                .Select(t => t.Series_Category)
                .Distinct()
                .ToList();

            return Ok(distinctSeriesCategories);
        }

        // Endpoint untuk mendapatkan distinct Customer_by_Channel 
        public ActionResult<IEnumerable<string>> GetDistinctCustomerByChannel()
        {
            var distinctCustomerByChannels = _context.Transaksis
                .Select(t => t.Customer_by_Channel)
                .Distinct()
                .ToList();

            return Ok(distinctCustomerByChannels);
        }

        // Endpoint untuk mendapatkan distinct Customer_by_Area 
        public ActionResult<IEnumerable<string>> GetDistinctCustomerByArea()
        {
            var distinctCustomerByAreas = _context.Transaksis
                .Select(t => t.Customer_by_Area)
                .Distinct()
                .ToList();

            return Ok(distinctCustomerByAreas);
        }

        // Endpoint untuk mendapatkan distinct GT_Industrial
        public ActionResult<IEnumerable<string>> GetDistinctGT_Industrial()
        {
            var distinctGTIndustrials = _context.Transaksis
                .Select(t => t.GT_Industrial)
                .Distinct()
                .ToList();

            return Ok(distinctGTIndustrials);
        }

        // Endpoint untuk mendapatkan distinct Product_Purpose 
        public ActionResult<IEnumerable<string>> GetDistinctProductPurpose()
        {
            var distinctProductPurposes = _context.Transaksis
                .Select(t => t.Product_Purpose)
                .Distinct()
                .ToList();

            return Ok(distinctProductPurposes);
        }
        #endregion


        public ActionResult<IEnumerable<Transaksi>> GetAll()
        {
            var data = _context.Transaksis.ToList();
            return Ok(new { data = data });
        }



        public IActionResult GetFilteredTransaksi(
        string area,
        string customerName,
        string product,
        string remark,
        string month,
        string period,
        int? year,
        string plant,
        string category1_8,
        string flour_bran_category,
        string mpbp_category,
        string series_category,
        string customer_by_channel,
        string customer_by_area,
        string gt_industrial,
        string product_purpose)
        {
            var query = _context.Transaksis.AsQueryable();

            // Create a list of expressions to apply filters
            var filters = new List<Expression<Func<Transaksi, bool>>>();

            if (!string.IsNullOrEmpty(area))
                filters.Add(t => t.Area == area);
            if (!string.IsNullOrEmpty(customerName))
                filters.Add(t => t.Customer_Name == customerName);
            if (!string.IsNullOrEmpty(product))
                filters.Add(t => t.Product == product);
            if (!string.IsNullOrEmpty(remark))
                filters.Add(t => t.Remark == remark);
            if (!string.IsNullOrEmpty(month))
                filters.Add(t => t.Month == month);
            if (!string.IsNullOrEmpty(period))
                filters.Add(t => t.Period == period);
            if (year.HasValue)
                filters.Add(t => t.Year == year.Value);
            if (!string.IsNullOrEmpty(plant))
                filters.Add(t => t.PLANT == plant);
            if (!string.IsNullOrEmpty(category1_8))
                filters.Add(t => t.Category_1_8 == category1_8);
            if (!string.IsNullOrEmpty(flour_bran_category))
                filters.Add(t => t.Flour_Bran_Category == flour_bran_category);
            if (!string.IsNullOrEmpty(mpbp_category))
                filters.Add(t => t.MPBP_Category == mpbp_category);
            if (!string.IsNullOrEmpty(series_category))
                filters.Add(t => t.Series_Category == series_category);
            if (!string.IsNullOrEmpty(customer_by_channel))
                filters.Add(t => t.Customer_by_Channel == customer_by_channel);
            if (!string.IsNullOrEmpty(customer_by_area))
                filters.Add(t => t.Customer_by_Area == customer_by_area);
            if (!string.IsNullOrEmpty(gt_industrial))
                filters.Add(t => t.GT_Industrial == gt_industrial);
            if (!string.IsNullOrEmpty(product_purpose))
                filters.Add(t => t.Product_Purpose == product_purpose);

            // Combine all filters into a single expression
            if (filters.Count > 0)
            {
                var combinedFilter = filters.Aggregate((current, next) => current.AndAlso(next));
                query = query.Where(combinedFilter);
            }

            // Execute the query and get the results
            var result = query.ToList();

            // Return the results as JSON
            return Ok(new { data = result });
        }
        // Extension method to combine expressions

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var parameter = Expression.Parameter(typeof(T));

            var combined = new ReplaceParameterVisitor(expr1.Parameters[0], parameter).Visit(expr1.Body);
            var second = new ReplaceParameterVisitor(expr2.Parameters[0], parameter).Visit(expr2.Body);

            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(combined, second), parameter);
        }

        private class ReplaceParameterVisitor : ExpressionVisitor
        {
            private readonly Expression _oldValue;
            private readonly Expression _newValue;

            public ReplaceParameterVisitor(Expression oldValue, Expression newValue)
            {
                _oldValue = oldValue;
                _newValue = newValue;
            }

            public override Expression Visit(Expression node)
            {
                return node == _oldValue ? _newValue : base.Visit(node);
            }
        }
    }
}
