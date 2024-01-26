using LoginDemo.Data;
using LoginDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Newtonsoft.Json;

namespace LoginDemo.Controllers
{
    public class UsersController : Controller
    {
    
        private readonly ApplicationDBContext _context;

        public UsersController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpGet]
      public IActionResult Getredemption()
        {
            return View();  
        }

        [HttpGet]

        public JsonResult GenerateStoreUsersReport()

        {
            var ShopperList = _context.ShopperInfos.ToList();
            List<ShopperInfo> listShopper = new List<ShopperInfo>();
            foreach (var item in ShopperList)
            {
                listShopper.Add(item);
            }
            System.Text.StringBuilder sbFormat = new System.Text.StringBuilder();
            string allRecords = JsonConvert.SerializeObject(listShopper);
            List<PROC_CUSTOM_GET_SHOPPERS> lstBrands = JsonConvert.DeserializeObject<List<PROC_CUSTOM_GET_SHOPPERS>>(allRecords);
           if(lstBrands != null)
            {
                var lst = lstBrands;
                if(lst.Count > 0)
                {

                    // cleint name
                    sbFormat.AppendLine("<table border='0' width='100%' style='font-family:Arial;'><tr><td colspan=5 align='center' style='font-size:22px;font-color:#FF0000;'> <b>" + "Akins Food" + "</b></table><br/>");

                    // Header 
                    // table start
                    sbFormat.AppendLine("<table border='1' width='100%' style='font-family:Arial;font-size:9px;'>");

                    // table header
                    sbFormat.AppendLine("<tr><th align=center>First Name</th><th align=center>Last Name</th><th align=center>User Name</th><th align=center>Member Number</th><th align=center>Store Name</th></tr>");
                    for (int i = 0; i < lst.Count; i++)
                    {
                        sbFormat.AppendLine("<tr>");
                        sbFormat.AppendLine(string.Format("<td align=left>{0}</td>", lst[i].FirstName.ToString()));
                        // Fisrt Name
                        //if ( lst[i].FirstName !="")
                        //{

                        //}
                        sbFormat.AppendLine(string.Format("<td align=left>{0}</td>", lst[i].LastName.ToString()));

                        //if (lst[i].LastName != "")
                        //{
                        //}
                        sbFormat.AppendLine(string.Format("<td align=left>{0}</td>", lst[i].UserName.ToString()));

                        //if (lst[i].UserName != "")
                        //{
                        //}
                        sbFormat.AppendLine(string.Format("<td align=left>{0}</td>", lst[i].MemberNumber.ToString()));
                        sbFormat.AppendLine(string.Format("<td align=left>{0}</td>", lst[i].PREFERREDSTORE.ToString()));
                        //if (lst[i].MemberNumber != "")
                        //{
                        //}

                        // zip code
                        //   sbFormat.AppendLine(string.Format("<td align=left>{0}</td>", lst[i].Zipcode.ToString()));

                        //if (lst[i].Zipcode != "")
                        //{
                        //}

                        // storeName
                        // sbFormat.AppendLine(string.Format("<td align=left>{0}</td>", lst[i].StoreName.ToString()));

                        //if (lst[i].StoreName != "")
                        //{
                        //}
                        sbFormat.AppendLine("</tr>");
                    }
                }
                else
                {
                    sbFormat.AppendLine("No Records Found");
                }
               



            }


            Response.Clear();
           
           

            Response.Headers.Add("content-disposition", "attachment;filename=" + string.Format("Akinsfood"+"_Users_Repost_{0}.xls",DateTime.Now.ToString("yyyyMMddHHmmsss")));
           
            Response.ContentType = "application/ms-excel";
            //Response.Charset = "";
            StringWriter sw = new StringWriter();
            sw.Write(sbFormat.ToString());
             Response.WriteAsync(sw.ToString());
           // Response.Output.Write(sw.ToString());
          Response.CompleteAsync();
           // Response.Flush();
            //Response.End();


            return Json(new { ok = 1 });
      
        }
       
    }
}
