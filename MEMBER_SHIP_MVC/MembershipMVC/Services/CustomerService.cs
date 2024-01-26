using Microsoft.Data.SqlClient;
using NetTopologySuite.IO;
using NuGet.Protocol.Plugins;
using System.Data;
using System.Data.OleDb;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MembershipMVC.Services
{
    public class CustomerService : ICustomer
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CustomerService(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            _configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }
      public  DataTable CustomerDatable(string path)
        {
            var conString = _configuration.GetConnectionString("excelconnection");
            DataTable dt = new DataTable(); 
            conString = string.Format( conString,path);
            using (OleDbConnection excelconn = new OleDbConnection(conString))
            {
               using(OleDbCommand  command = new OleDbCommand())
                {
                   using(OleDbDataAdapter dataAdapter = new OleDbDataAdapter())
                    {
                        excelconn.Open();
                        command.Connection = excelconn;
                        DataTable excelSchema;
                        excelSchema = excelconn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        var sheetName = excelSchema.Rows[0]["TABLE_NAME"].ToString();
                        excelconn.Close();

                        excelconn.Open();
                        command.CommandText = "SELECT * From [" + sheetName + "]";
                        dataAdapter.SelectCommand = command;
                        dataAdapter.Fill(dt);
                        excelconn.Close();

                    }
                }
            }
            return dt;
        }

       public string DocumentUpload(IFormFile formFile)

        {
          
            string uploadPath = _webHostEnvironment.WebRootPath;
            string  dest_path = Path.Combine(uploadPath, "uploded_doc");
            if (!Directory.Exists(dest_path))
            {
                Directory.CreateDirectory(dest_path);
            }
            string sourceFile = Path.GetFileName(formFile.FileName);
            string filePath = Path.Combine(dest_path, sourceFile);
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }
            return filePath;
        }

      public  void ImportCustomer(DataTable customer)
        {
            var conn = _configuration.GetConnectionString("DefaultConnection");
            using(SqlConnection  sqlcon = new SqlConnection(conn))
            {
              using(SqlBulkCopy bulkcopy = new SqlBulkCopy(conn))
                {
                    bulkcopy.DestinationTableName = "Customers";
                    bulkcopy.ColumnMappings.Add("Id", "Id");
                    bulkcopy.ColumnMappings.Add("FirstName", "FirstName");
                    bulkcopy.ColumnMappings.Add("LastName", "LastName");
                    bulkcopy.ColumnMappings.Add("Job", "Job");
                    bulkcopy.ColumnMappings.Add("Amount", "Amount");
                    bulkcopy.ColumnMappings.Add("TDate", "Tdate");
                    sqlcon.Open();
                    bulkcopy.WriteToServer(customer);
                    sqlcon.Close();


                }

            }
        }
    }
}
