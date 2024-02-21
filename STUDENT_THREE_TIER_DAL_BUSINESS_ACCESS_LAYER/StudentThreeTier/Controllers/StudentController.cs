using BusinessLogicLayer;
using DataAccessLayer;
//using CommonLayer.Models;
//using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
//using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Http.Features;
using System.Text.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Xml;
using Twilio.TwiML;
using Microsoft.AspNetCore.Http.Connections;

using System.Net;
using Newtonsoft.Json.Linq;
using System.Data;
//using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Collections.Immutable;
using System.Text.RegularExpressions;
using Twilio.Converters;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;
//using DataAccessLayer.Entities;
//using DataAccessLayer.Interfaces;

using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using System.Drawing;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.WebUtilities;
using System.Security.Cryptography;
using Twilio.Jwt.AccessToken;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using CommonLayer.Models;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography.Xml;
using static System.Collections.Specialized.BitVector32;
using Microsoft.Extensions.Caching.Memory;
using System.ServiceModel;

//using Microsoft.AspNetCore.DataProtection;

namespace StudentThreeTier.Controllers
{
 //  [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repo;
        private readonly IConfiguration _configuration;
        private readonly IStudentyService _studentService;
        private readonly IOptions<ConnectionStrings> _config;
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private readonly IHttpContextAccessor _context;
        private readonly IMemoryCache _memoryCache;
        private readonly List<User> _users;

        public StudentController(
            IStudentRepository repo,
            IConfiguration configuration,
            IStudentyService studentService,
             IOptions<ConnectionStrings> config,
             IDataProtectionProvider dataProtectionProvider,
             IHttpContextAccessor context,
             IMemoryCache memoryCache,
              List<User> users



            )
        {
            _repo = repo;
           _configuration = configuration;
           _studentService = studentService;
            _config = config;
           
            _dataProtectionProvider = dataProtectionProvider;
            _context = context;
            _memoryCache = memoryCache;
            _users = users;
        }
        // create student recordd
        [HttpPost]
        [Route("CreateStudent")]
        [Produces("application/json")]
        public Response CreateStudent(Student student)
        {

            var result = _studentService.AddStudent(student);
            return result;
        }


        // get all studentlIST
       // [Authorize(Roles = "User")]
        [HttpGet]
        [Route("GetAll")]
        [Produces("application/json")]
        public IActionResult GetAll()
        {



   

            var result = _studentService.GetAllStudent();
          
            if (result.Count == 0)
            {
                return NotFound("Students records not found.");
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("GetJsonFromConfigureService")]
        public IActionResult GetJsonFromConfigureService()
        {
            try
            {
                var usersData = _users;
                if (usersData == null)
                {
                    return NotFound("No json file data here...");
                }


                return Ok(new { data = usersData });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [HttpGet]
        [Route("GetByStudentId")]
        [Produces("application/json")]
        public IActionResult GetByStudentId(int id)
        {
            if (id == 0)
            {
                return BadRequest("Invalid student id."); ;
            }


            var result = _studentService.GetStudentDetails(id);

            if(result.Id == 0)
            {
              return NotFound("Student details are not found.");
               
            }
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateStudent")]
        [Produces("application/json")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            if (id == student.Id)
            {
                return BadRequest("Invalid stuedent id."); ;
            }
         
           var result=_studentService.UpdateStudent(id,student);
            if (result.Student == null)
            {
                return NotFound("Student already available with this rollnumber  or  enable to update student details or Invalid Id");
            }
            return Ok(result);
        }
        [HttpDelete]
        [Route("DeleteStudent")]
        [Produces("application/json")]
        //public Response DeleteStudent(int id)
        //{
        //   var result = _studentService.DeleteStudent(id);
        //    return result;
        //}

        public IActionResult DeleteStudent(int id) 
        { 
            if (id == 0)
            {
                return BadRequest();
            }
            var result = _studentService.DeleteStudent(id);
           
            if(result.StatusCode != 200)
            {
                return NotFound("Student Record Not Found.");
            }
            return Ok(result);
        }

        // Dataset
        [HttpGet]
        [Route("GetEmployeeAndStudentDetails")]
        [Produces("application/json")]
        //[Produces("application/json")]
        public IActionResult GetEmployeeAndStudentDetails()
        {
           //var result = _studentService.GetEmployeeAndStudentDetails();
           // return result;  
           var result = _studentService.GetStudentsAndEmployeesList();
          if(result == null)
            {
                return NotFound("Records not found.");
            }

           return Ok(result);
        }


        // using mutiple methods: dataset

        [HttpGet]
        [Route("GetStudentAndEmpTableslist")]
        [Produces("application/json")]

        public IActionResult GetStudentAndEmpTableslist()
        {
            //var result = _studentService.GetEmployeeAndStudentDetails();
            // return result;  
            var result = _studentService.GetStudentAndEmpTableList();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }




        // XML data Read and Send to API request
        //[AcceptVerbs("POST", "PUT")]
        //[Route("CreateAndEditXml")]
        //[Consumes("application/xml")]
        //public Response CreateAndEditXml([FromBody] XmlDocument xmlDoc)
        //{
        //    Response response = new Response();
        //    Student student = new Student();


        //    var xmldata = xmlDoc.OuterXml;
        //    xmlDoc.LoadXml(xmldata);
        //    var itemslist = xmlDoc.SelectSingleNode("Student");
        //    Console.WriteLine("item", itemslist);

        //    string json = JsonConvert.SerializeXmlNode(xmlDoc);

        //    // xmlDoc = JsonConvert.DeserializeXmlNode(json);

        //    dynamic obj = JsonConvert.DeserializeObject(json);
        //    //  Console.WriteLine(obj.Student.Id);

        //    if (obj.Student.Id != null)
        //    {
        //        student.Id = obj.Student.Id;
        //    }
        //    student.FirstName = obj.Student.FirstName;
        //    student.LastName = obj.Student.LastName;
        //    student.RollNumber = obj.Student.RollNumber;
        //    student.DateofBirth = obj.Student.DateofBirth;
        //    student.Address = obj.Student.Address;
        //    student.Marks = obj.Student.Marks;
        //    student.Grades = obj.Student.Grades;

           
        //    // string reader:

        //    var method = HttpContext.Request.Method;
        //    if (method == "POST")
        //    {

        //        var result = _studentService.AddStudent(student);
        //        return result;
        //    } else if (method == "PUT")
        //    {


        //        var result = _studentService.UpdateStudent(student.Id, student);
        //        return result;
        //    }



        //    return response;
        //}


        [AcceptVerbs("POST", "PUT")]
        [Route("PostAndUpdateXml")]
        public IActionResult PostAndUpdateXml([FromBody] XmlDocument xml)
        {
            Response response = new Response();
            Student student = new Student();


            string xmldata = xml.OuterXml.ToString();
            XmlSerializer serializer = new XmlSerializer(typeof(Student));
            using (StringReader reader = new StringReader(xmldata))
            {
                Student studentObj = (Student)serializer.Deserialize(reader);

                if (studentObj.Id != 0)
                {
                    student.Id = studentObj.Id;
                }
                 
                student.FirstName = studentObj.FirstName;
                student.LastName = studentObj.LastName;
                student.DateofBirth = studentObj.DateofBirth;
                student.RollNumber = studentObj.RollNumber;
                student.Address = studentObj.Address;
                student.Marks = studentObj.Marks;
                student.Grades = studentObj.Grades;

            }
            var Method = HttpContext.Request.Method;
            if (Method == "POST")
            {
                var result = _studentService.AddStudent(student);
                if (result.Student == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            else if (Method == "PUT")
            { 
                var result = _studentService.UpdateStudent(student.Id, student);
                if (result.Student == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }


            return Ok(response);

        }



        // XML POST 
        //[HttpPost]
        //[Route("AddXmlData")]

        //public Task AddXmlData([FromBody] Student student)
        //{
        //    var model = new Student();
        //    //model.Id = student.Id;
        //    model.FirstName = student.FirstName;
        //    model.LastName = student.LastName;
        //    model.DateofBirth = student.DateofBirth;
        //    model.RollNumber = student.RollNumber;
        //    model.Address = student.Address;
        //    model.Marks = student.Marks;
        //    model.Grades = student.Grades;


        //    HttpContext.Features.Get<IHttpBodyControlFeature>().AllowSynchronousIO = true;

        //    XmlSerializer serializer = new XmlSerializer(typeof(Student));
        //    HttpContext.Request.ContentType = "application/xml";
        //     serializer.Serialize(HttpContext.Response.Body,model );


        //    return Task.CompletedTask;
        //}

        // xmladdorUpdate
        //[AcceptVerbs("POST","PUT")]
        //[Route("AddOrUpdatexml")]
        //[Consumes("application/xml")]
        //// public Response AddOrUpdatexml([FromBody] XmlDocument xml)
        //public Response AddOrUpdatexml([FromBody]  Student student)
        //{
        //    Response response = new Response();
        //    // xml to  
        //  var method= HttpContext.Request.Method;
        //    if(method == "POST")
        //    {
        //        var model = new Student();
        //        //model.Id = student.Id;
        //        model.FirstName = student.FirstName;
        //        model.LastName = student.LastName;
        //        model.DateofBirth = student.DateofBirth;
        //        model.RollNumber = student.RollNumber;
        //        model.Address = student.Address;
        //        model.Marks = student.Marks;
        //        model.Grades = student.Grades;
        //        var result = _studentService.AddStudent(model);
        //    if(result != null)
        //        {
        //            response.Student = result.Student;
        //            response.StatusCode = result.StatusCode;
        //            response.StatusMessage = result.StatusMessage;
        //        }              
        //    }
        //    else if(method == "PUT")
        //    {
        //      var result =  _studentService.UpdateStudent(student.Id,student);
        //        if(result != null)
        //        {
        //            response.Student = result.Student;
        //            response.StatusCode = result.StatusCode;
        //            response.StatusMessage = result.StatusMessage;
        //        }
        //    }


        //    return response;
        //}

        //// xml data
        //[HttpGet]
        //[Route("GetStudentxml")]
        //public Task GetStudentxml()
        //{
        //    Response response= new Response();
        //    var acceptType = HttpContext.Request.Headers.Accept;

        //    HttpContext.Features.Get<IHttpBodyControlFeature>().AllowSynchronousIO = true;


        //    var student = new Student();
        //   var result = _studentService.GetAllStudent();
        //    if(result .Count > 0)
        //    {
        //        response.ListStudent= result;
        //    }
        //   if(acceptType == "application/xml")
        //    {
        //        XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
        //        HttpContext.Request.ContentType = "application/xml";
        //      //  serializer.Serialize(HttpContext.Response.Body, response.ListStudent);

        //        using MemoryStream stream = new MemoryStream();
        //        serializer.Serialize(stream, response.ListStudent);

        //        stream.Seek(0, SeekOrigin.Begin);
        //        HttpContext.Response.Body.WriteAsync(stream.ToArray(), new CancellationToken());
        //    }else
        //    {
        //        HttpContext.Request.ContentType = "application/json";
        //        using MemoryStream stream = new MemoryStream();
        //        JsonSerializer.Serialize(stream, response.ListStudent);

        //        stream.Seek(0, SeekOrigin.Begin);
        //        HttpContext.Response.Body.WriteAsync(stream.ToArray(), new CancellationToken());
        //        // JsonSerializer.Serialize(HttpContext.Response.Body, response.ListStudent);
        //    }




        //    return Task.CompletedTask;
        //}




        /// xml documents
        //[HttpPost]
        //[Route("XMLDocumentCreate")]
        //public IActionResult XMLDocumentCreate([FromBody] XmlDocument doc)
        //{
        //    //XmlDocument doc = new XmlDocument();
        //    XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
        //    doc.AppendChild(docNode);

        //    XmlElement studentDataNode = doc.CreateElement("Student");

        //    studentDataNode.SetAttribute("xmlns:i", "http://www.w3.org/2001/XMLSchema-instance");
        //    doc.AppendChild(studentDataNode);


        //    XmlNode headerNode = doc.CreateElement("Header");
        //    studentDataNode.AppendChild(headerNode);


        //    XmlNode contentNode = doc.CreateElement("FirstName");
        //    contentNode.AppendChild(doc.CreateTextNode("saikumar"));
        //    headerNode.AppendChild(contentNode);



        //    var basepath = Path.Combine(Environment.CurrentDirectory, @"XMLFiles\");
        //    if (!Directory.Exists(basepath))
        //    {
        //        Directory.CreateDirectory(basepath);

        //    }
        //    //var fileName = Path.GetFileName(basepath);

        //    var fileName = String.Format("{0}{1}", Guid.NewGuid().ToString("N"), ".xml");
        //    doc.Save(basepath + fileName);

        //    Console.WriteLine(doc);
        //    //return Task.CompletedTask;
        //    return Content(doc.OuterXml, "application/xml");
        //}

        //    [HttpPost]
        //    [Consumes("application/xml")]
        //    [Route("CreateXmlDocument")]
        //    public IActionResult CreateXmlDocument([FromBody] XmlDocument xmlDoc)
        //  //  public IActionResult ReturnXmlDocument([FromBody] XmlDocument xmlDoc)
        //    {
        //        Student student = new Student();


        //        var result = xmlDoc.OuterXml;
        //        xmlDoc.LoadXml(result);

        //        string json = JsonConvert.SerializeXmlNode(xmlDoc);

        //       // xmlDoc = JsonConvert.DeserializeXmlNode(json);

        //        dynamic obj = JsonConvert.DeserializeObject(json);
        //        Console.WriteLine(obj);
        //        student.Id = obj.Student.Id;
        //        student.FirstName = obj.Student.FirstName;
        //        student.LastName = obj.Student.LastName;
        //        student.RollNumber = obj.Student.RollNumber;
        //        student.DateofBirth = obj.Student.DateofBirth;
        //        student.Address = obj.Student.Address;
        //        student.Marks = obj.Student.Marks;
        //        student.Grades = obj.Student.Grades;


        //var res =  _studentService.UpdateStudent(student.Id,student);
        //            Console.WriteLine(res);
        //   Console.WriteLine(result);
        //        return Content(xmlDoc.OuterXml,"application/xml");
        //    }



        [HttpGet]
        [Route("Name")]

        public IActionResult Name (string name)
        {
          
            return Ok("Hello, my name is " + name);
        }

        // get secret Manager keys:
        [HttpGet]
        [Route("SercretKey")]
        public async Task<IActionResult> GetSecrets()
        {
            //string SecretName = "example/dev/key";
            //string region = "ap-south-1";
            //IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));
            //GetSecretValueRequest request = new GetSecretValueRequest
            //{
            //    SecretId = SecretName,
            //  //  VersionStage = "AWSCURRENT", // VersionStage defaults to AWSCURRENT if unspecified.
            //};



            //// for key 3


            //// for  key 2
            //string SecretProdName = "example/prod/key";
            //string region1 = "ap-south-1";
            //IAmazonSecretsManager client2 = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region1));
            //GetSecretValueRequest request2 = new GetSecretValueRequest
            //{
            //    SecretId = SecretProdName,
            //   // VersionStage = "AWSCURRENT", // VersionStage defaults to AWSCURRENT if unspecified.
            //};


            // string SecretName3= "prod/test/key";
            //  string SecretName3 = "test/Api/keys";
            // string SecretName3= "sai/test/key";

            //string region3 = "ap-south-1";
            //IAmazonSecretsManager client3 = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region3));
            //GetSecretValueRequest request3 = new GetSecretValueRequest
            //{
            //    SecretId = SecretName3,
            //    // VersionStage = "AWSCURRENT", // VersionStage defaults to AWSCURRENT if unspecified.


            //};
            // GetSecretValueResponse response;
            //GetSecretValueResponse response2;
            //GetSecretValueResponse response3;



            // for sai test api keys:

            string secretName4 = "sai/test/key";
            string region4 = "ap-south-1";

            IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region4));

            GetSecretValueRequest request4 = new GetSecretValueRequest
            {
                SecretId = secretName4,
                VersionStage = "AWSCURRENT", // VersionStage defaults to AWSCURRENT if unspecified.
            };

            GetSecretValueResponse response4;



            try
            {
                //response = await client.GetSecretValueAsync(request);   
                //response2 = await client2.GetSecretValueAsync(request2);
                //response3 = await client3.GetSecretValueAsync(request3);


                response4 = await client.GetSecretValueAsync(request4);

            }
            catch (Exception ex)
            {
                throw ex;
            }
         
           // // for secret 1 Encrypted data 
           // var secret = response.SecretString.ToString();
           // var userSecretProvider = _dataProtectionProvider.CreateProtector(SecretName);
           // byte[] secretEncoding = userSecretProvider.Protect(System.Text.Encoding.UTF8.GetBytes(secret));
           //var encryptedData1 =  Convert.ToBase64String(secretEncoding);
           
           // // for encrypt dat for secret2

           // var secret2 = response2.SecretString.ToString();


           // var userSecretProtector2 = _dataProtectionProvider.CreateProtector(SecretProdName);
           // byte[] secret2ByteInfo = userSecretProtector2.Protect(System.Text.Encoding.UTF8.GetBytes((secret2)));
           // var encryptedData2 = Convert.ToBase64String(secret2ByteInfo);

            // for encrypt data for secret3:

           var secret4 = response4.SecretString.ToString();
            var  userSecretProtector4 = _dataProtectionProvider.CreateProtector(secretName4);
            byte[] secret4ByteInfo = userSecretProtector4.Protect(System.Text.Encoding.UTF8.GetBytes((secret4)));
            var encryptedData3 = Convert.ToBase64String(secret4ByteInfo);


            // decrypt:
            byte[] encryptDataByte = Convert.FromBase64String(encryptedData3);
            var decrept1Base64= userSecretProtector4.Unprotect(encryptDataByte);
            string decrept4 = System.Text.Encoding.UTF8.GetString(decrept1Base64);
           
            SecretModel member = JsonSerializer.Deserialize<SecretModel>(decrept4.ToString());
            // SecretModel model = new SecretModel();
            //  string json = JsonSerializer.Serialize(decrept3);

            SecretModel model = JsonConvert.DeserializeObject<SecretModel>(decrept4);
            Console.WriteLine(model);


            
            //var obj = new { 
            //    secret, 
            //    secret2, 
            //    secret3
            //};


           // return Ok( encryptedData3);
           return Ok(new {model,encryptedData3});
            // return Ok(secret3);
          //  return Ok(new { secret, secret2, secret3 });
        }

        //[HttpGet]
        //[Route("EncryptData")]
        //public IActionResult EncrptyData()
        //{

        //      string plaintext  = "arn:aws:secretsmanager:ap-south-1:242909465937:secret:test/Api/keys-2oZZ1J";
        //    //   // encrypt
        //    //  var protection = _dataProtectionProvider.CreateProtector("user-data-encryption-key");
        //    //   byte[] Encryptdata =  protection.Protect(System.Text.Encoding.UTF8.GetBytes(userData)); 
        //    //   var data = Convert.ToBase64String(Encryptdata);
        //    //   Console.WriteLine(data);
        //    //   // decrypt:
        //    //   byte[] userInfo = Convert.FromBase64String(data);
        //    //  var  decrypted = protection.Unprotect(userInfo);
        //    //string decrypteddata = System.Text.Encoding.UTF8.GetString(decrypted);
        //    //   Console.WriteLine(decrypteddata);


        //    //   return Ok(new {data,decrypteddata});    



        //    // Symmetric encryption :

        //    string base64key = string.Empty;

        //    using (Aes aes = Aes.Create())
        //    {
        //        aes.KeySize = 256;
        //        aes.GenerateKey();
        //        base64key = Convert.ToBase64String(aes.Key);

        //        // 
        //        aes.Padding = PaddingMode.Zeros;
        //        aes.Key = Convert.FromBase64String(base64key);
        //        aes.GenerateIV();
        //        var IVkey = Convert.ToBase64String(aes.IV);
        //        ICryptoTransform cryptoTransform = aes.CreateEncryptor();
        //        byte[] encryptedData;
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write))
        //            {
        //                using (StreamWriter sw = new StreamWriter(cs))
        //                {

        //                    sw.Write(plaintext);
        //                }
        //                encryptedData = ms.ToArray();

        //            };
        //        }

        //        string EncryptedData = Convert.ToBase64String(encryptedData);
        //        string PlainText = "";
        //        if (EncryptedData == plaintext)
        //        {
        //            ICryptoTransform decrypt = aes.CreateDecryptor();

        //            byte[] chiper = Convert.FromBase64String(EncryptedData);
        //            using (MemoryStream ms = new MemoryStream(chiper))
        //            {
        //                using (CryptoStream cs = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write))
        //                {
        //                    using (StreamReader sw = new StreamReader(cs))
        //                    {

        //                        PlainText = sw.ReadToEnd();  
        //                    }


        //                };
        //            }


        //        }
        //        return Ok( new { EncryptedData, plaintext });

        //       // return Ok( new { EncryptedData } );
        //    }


        //     // SYMMETRIC DECRYPTION:

        //}


        //// test encryption:
        //[HttpGet]
        //[Route("GetGenerateKey")]
        //public string GenerateKey()
        //{
        //    string base64key = string.Empty;
        //    using (Aes aes = Aes.Create())
        //    {
        //        aes.KeySize = 256;
        //        aes.GenerateKey();
        //        base64key = Convert.ToBase64String(aes.Key);


        //    }
        //    return base64key;
        //}
        //[HttpPost]
        //[Route("Encrypt")]
        //public  string Encrypt(string key, string plaintext, out string IVkey)
        //{
        //    using (Aes aes = Aes.Create())
        //    {
        //        aes.Padding = PaddingMode.Zeros;
        //        aes.Key = Convert.FromBase64String(key);
        //        aes.GenerateIV();
        //        IVkey = Convert.ToBase64String(aes.IV);
        //        ICryptoTransform cryptoTransform = aes.CreateEncryptor();
        //        byte[] encryptedData;
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write))
        //            {
        //                using (StreamWriter sw = new StreamWriter(cs))
        //                {

        //                    sw.Write(plaintext);
        //                }
        //                encryptedData = ms.ToArray();

        //            };
        //        }
        //        return Convert.ToBase64String(encryptedData);
        //    }
        //}

        //// decrypter:

        //public static string Decrypt(string CipherText, string key, string IVkey)
        //{
        //    using (Aes aes = Aes.Create())
        //    {
        //        aes.Padding = PaddingMode.Zeros;
        //        aes.Key = Convert.FromBase64String(key);
        //        aes.IV = Convert.FromBase64String(IVkey);
        //        IVkey = Convert.ToBase64String(aes.IV);

        //        ICryptoTransform cryptoTransform = aes.CreateDecryptor();
        //        string PlainText = "";
        //        byte[] chiper = Convert.FromBase64String(CipherText);
        //        using (MemoryStream ms = new MemoryStream(chiper))
        //        {
        //            using (CryptoStream cs = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write))
        //            {
        //                using (StreamReader dr = new StreamReader(cs))
        //                {

        //                    PlainText = dr.ReadToEnd();
        //                }

        //            };
        //        }
        //        return PlainText;
        //    }
        //}

        [HttpGet]
        [Route("Secret")]
       public  async Task<IActionResult> GetSecret()
        {
            string secretName = "sai/test/key";
            string region = "ap-south-1";

            IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));

            GetSecretValueRequest request = new GetSecretValueRequest
            {
                SecretId = secretName,
                VersionStage = "AWSCURRENT", // VersionStage defaults to AWSCURRENT if unspecified.
            };

            GetSecretValueResponse response;

            try
            {
                response = await client.GetSecretValueAsync(request);
            }
            catch (Exception e)
            {
                // For a list of the exceptions thrown, see
                // https://docs.aws.amazon.com/secretsmanager/latest/apireference/API_GetSecretValue.html
                throw e;
            }

            string secret = response.SecretString.ToString();

           // SecretModel member = JsonSerializer.Deserialize<SecretModel>(secret.ToString());
            // SecretModel model = new SecretModel();
            //  string json = JsonSerializer.Serialize(decrept3);

           // SecretModel model = JsonConvert.DeserializeObject<SecretModel>(secret.ToString());

          
            var userSecretProtector = _dataProtectionProvider.CreateProtector(secretName);
            byte[] secret4ByteInfo = userSecretProtector.Protect(System.Text.Encoding.UTF8.GetBytes((secret)));
            var encryptedData = Convert.ToBase64String(secret4ByteInfo);


            // decrypt:
            byte[] encryptDataByte = Convert.FromBase64String(encryptedData);
            var decrept1Base64 = userSecretProtector.Unprotect(encryptDataByte);
            string decrept = System.Text.Encoding.UTF8.GetString(decrept1Base64);

           // SecretModel member = JsonSerializer.Deserialize<SecretModel>(decrept);
            // SecretModel model = new SecretModel();
            //  string json = JsonSerializer.Serialize(decrept3);

            SecretModel model = JsonConvert.DeserializeObject<SecretModel>(decrept);
            Console.WriteLine(model);


            return Ok(new {model,encryptedData});
            // Your code goes here
        }
       // [Authorize(Roles = "User")]
        [HttpGet]
        [Route("StoreInsession")]
        public IActionResult StoreInsession()
        {

            // global
            var studentData = _studentService.GetAllStudent();
             HttpContext.Session.SetString("Student",JsonConvert.SerializeObject(studentData));
           
           
           
            // var name = HttpContext.Session.GetString("Student");
          return   Ok();
        }

       // [Authorize(Roles ="User")]

        [HttpGet]
        [Route("GetSessionData")]
        public IActionResult GetSessionData()
        {


            //if (HttpContext.Session != null)
            //{
            //    var data = HttpContext.Session.GetString("Student");
            //    return Ok(data);
            //}
            //else
            //{
            //    return BadRequest();
            //}
              var data = HttpContext.Session.GetString("Student");
            if(string.IsNullOrEmpty(data))
            {
               // return BadRequest("Expired session");

                var studentlist = _studentService.GetAllStudent();
                return Ok(studentlist);
            }
               return Ok(data);

        }

        // individual:

        [HttpGet]
        [Route("SetSession")]
        public IActionResult SetSessionn()
        {

            // individual:

            var studentData = _studentService.GetAllStudent();

            //session
             HttpContext.Session.SetString("Student", JsonConvert.SerializeObject(studentData));

             // memory cache
            _memoryCache.Set("Student", JsonConvert.SerializeObject(studentData), TimeSpan.FromSeconds(80));
            return Ok(studentData);

        }



          
        }


     
    
}
