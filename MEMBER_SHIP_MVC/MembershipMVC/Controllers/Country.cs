using Humanizer;
using MembershipMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace MembershipMVC.Controllers
{
    [Authorize]
    public class Country : Controller
    {
      //  [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {

            // with custom jsonfile:
            var webClient = new WebClient();
            var json = webClient.DownloadString(@"\csharpprojects\MembershipMVC\MembershipMVC\Content\Countryjson.json");
            var countries = JsonConvert.DeserializeObject<Countries>(json);
            return View(countries);

            //var json = "{\r\n  \"countries\": [\r\n    {\r\n      \"country\": \"afghanistan\",\r\n      \"states\": [ \"Ghanzi\", \"Farah\", \"Bamian\" ]\r\n    },\r\n    {\r\n      \"country\": \"India\",\r\n      \"states\": [\r\n        \"Andhrapradesh\",\r\n        \"Telangana\",\r\n        \"UtharPradesh\"\r\n      ]\r\n    }\r\n  ]\r\n}";
            //var countries = JsonConvert.DeserializeObject<Countries>(json);

            //return View(countries);
        }
    }
}