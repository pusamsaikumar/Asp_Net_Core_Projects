using JWTRoleAuthentication.CommonLayer.Models;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace JWTRoleAuthentication.JWTDAL
{
    public class FileRepo : IFileRepo
    {
        private readonly List<RSAClient> _rSAClients;
        private readonly IAuthRepo _authRepo;
        private readonly Helpers _helpers;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly List<Coupon> _coupons;

        public FileRepo(
            List<RSAClient> rSAClients,
            IAuthRepo authRepo,
            Helpers helpers,
            IHttpContextAccessor httpContextAccessor,
            List<Coupon> coupons
            )

        {
            _rSAClients = rSAClients;
            _authRepo = authRepo;
            _helpers = helpers;
           _httpContextAccessor = httpContextAccessor;
            _coupons = coupons;
        }
        public async Task<CustomerResponse> AddCustomerWithJsonfile(string sharedKey, string secretKey, CustomerModel model)
        {
            CustomerResponse customerResponse = null;
              customerResponse = new CustomerResponse();
            try
            {
                var jsonData = await ReadJsonFile(sharedKey,secretKey);

                model.UserName = jsonData.RSAClient.UserName;
                model.Email = jsonData.RSAClient.Email ;
                model.MobileNumber = jsonData.RSAClient.MobileNumber;
                model.Address = jsonData.RSAClient.Address;

                Console.WriteLine(model);

                //var authCon = new AuthDBCon();
                //if(jsonData?.RSAClient != null)
                //{
                //    authCon.DataSource = jsonData.RSAClient.ServerName;
                //    authCon.InitialCatalog = jsonData.RSAClient.DatabaseName;
                //    authCon.UserID = jsonData.RSAClient.UserId;
                //    authCon.Password = jsonData.RSAClient.Password;
                //}
                //string connectionString = authCon.BuildConnectionString();

                string connectionString = await _helpers.BuildConnectionString(jsonData?.AuthDBCon);
                Console.WriteLine(connectionString);
                SqlHelpers sqlHelpers = new SqlHelpers(connectionString);
                var storedProcName = "InsertCustomer";

                // USING SQL COMMANDS:

                var parameters = new SqlParameter[]
                {
                            new SqlParameter("@UserName",model.UserName),
                            new SqlParameter("@Email",model.Email),
                            new SqlParameter("@MobileNumber",model.MobileNumber),
                            new SqlParameter("@Address",model.Address),
                };

                int rowsAffected = await sqlHelpers.InsertTable(storedProcName, parameters);
                if(rowsAffected > 0)
                {
                    customerResponse.StatusCode = 200;
                    customerResponse.StatusMessage = "Customer record inserted successfully";
                    customerResponse.Customer = model;
                    
                    return customerResponse;
                }
                customerResponse.StatusCode = 400;
                customerResponse.StatusMessage = "failed";
              //  customerResponse.Customer = model;
            }
            catch (Exception ex)
            {
                customerResponse.StatusCode = 500;
                customerResponse.StatusMessage = "Something went wrong. Please try again.";
            }
            return customerResponse;
        }

        //public async Task<CouponResponse> GetCouponsData()
        //{
        //    CouponResponse response = new CouponResponse();

        //    try
        //    {
        //        var json = await File.ReadAllTextAsync("D:\\csharpprojects\\JWTRoleAuthentication\\JWTRoleAuthentication\\JSONFiles\\Applied.json");
        //        var dataResult = JsonConvert.DeserializeObject<AppliedData>(json);
        //       if(dataResult?.Applied == null)
        //        {

        //            response.ErrorCode = "";
        //            response.ErrorDesc = "No data found.";
        //            response.Status = "Failed";
        //            return response;
        //        }

        //        // Group items by CouponId, TotalDiscount, and a hash of Items
        //        var groupedItems = dataResult?.Applied
        //            .GroupBy(item => new
        //            {
        //                item.CouponId,
        //                item.TotalDiscount,
        //                ItemHash = string.Join(",", item.Items.Select(i => i.GetHashCode()))
        //            });

        //        // Find matching Items:
        //         var matchingItems = groupedItems?
        //            .Where(group => group.Count() >1)
        //            .SelectMany(group => group)
        //            .ToList();

        //        // Find non-matching items: 
        //        var nonMatchingItems = groupedItems?
        //            .Where(group => group.Count() == 1)
        //            .SelectMany(group => group)
        //            .ToList();

        //        // Group non-matching items by couponId and totalDiscount:
        //        var groupedNonMatchingItems = nonMatchingItems?.GroupBy(item => new { item.CouponId, item.TotalDiscount });

        //        // Max items for each couponId and totalDiscount:
        //        var maxItemsPerGroup = groupedNonMatchingItems?.ToDictionary(g => new { g.Key.CouponId, g.Key.TotalDiscount }, g => g.Max(Item => Item.Items.Count()));

        //        // filtering non matched items:
        //        var filteredNonMatchingItems = nonMatchingItems?.Where(item => maxItemsPerGroup != null &&
        //          maxItemsPerGroup.TryGetValue(new { item.CouponId, item.TotalDiscount }, out var maxItemCount) &&
        //          item.Items.Count == maxItemCount
        //        ).ToList();
        //        if(filteredNonMatchingItems != null)
        //        {
        //            response.Applied = filteredNonMatchingItems;
        //            response.ErrorCode = "";
        //            response.ErrorDesc = "";
        //            response.Status = "Successful";
        //            return response;
        //        }




        //    }
        //    catch (Exception ex)
        //    {
        //       // response.Applied = null;
        //        response.ErrorCode = "500";
        //        response.ErrorDesc = "";
        //        response.Status = "Something went wrong. Please try again later.";
        //    }
        //    return response;
        //}

        public async Task<CouponResponse> GetCouponsData()
        {
            CouponResponse response = new CouponResponse();

            try
            {
             


                var json = await File.ReadAllTextAsync("D:\\csharpprojects\\JWTRoleAuthentication\\JWTRoleAuthentication\\JSONFiles\\Applied.json");
                var dataResult = JsonConvert.DeserializeObject<AppliedData>(json);
                var newAppliedList = dataResult?.NewApplied.ToList();
                var oldAppliedList = dataResult?.OldApplied.ToList();
                if(newAppliedList != null && oldAppliedList != null && dataResult != null)
                {
                   // var nonMatchedItemForNewApplied = newAppliedList.Except(oldAppliedList).ToList();
                   // var nonMatchedItemsForOldApplied = oldAppliedList.Except(newAppliedList).ToList();

                   //var nonMatchedItemForNewApplied = newAppliedList.Where(newItem => !oldAppliedList.Any(oldItem =>  newItem.CouponId == oldItem.CouponId && newItem.TotalDiscount == oldItem.TotalDiscount && newItem.Items.SequenceEqual(oldItem.Items))).ToList();
                     //var nonMatchedItemsForOldApplied  = oldAppliedList.Where(oldItem => !newAppliedList.Any(newItem => oldItem.CouponId == newItem.CouponId &&  oldItem.TotalDiscount ==  newItem.TotalDiscount && oldItem.Items.SequenceEqual(newItem.Items))).ToList(); 


                   //    find non-matched items for NewApplied:
                  var nonMatchedItemForNewApplied = newAppliedList.Except(oldAppliedList, comparer: new AppliedCouponComparer()).ToList();

                    //    find non-matched items for OldApplied:
                   var nonMatchedItemsForOldApplied = oldAppliedList.Except(newAppliedList,comparer: new AppliedCouponComparer()).ToList();
                    var updateOldAppliedListWithTotalDiscount = nonMatchedItemsForOldApplied.Select(x =>
                    {
                        x.TotalDiscount = -x.TotalDiscount;
                        return x;
                    }).ToList();

                    // combined together:
                    var finalResultList = nonMatchedItemForNewApplied.Concat(nonMatchedItemsForOldApplied).ToList();


                    //// find out max Items objects  for each couponId and TotalDiscount.
                    //var maxItemForNonMatchedItems = finalResultList
                    //    .GroupBy(x => new {x.CouponId, x.TotalDiscount,x.Items})
                    //    .SelectMany(g => g.Where(x => x.Items.Count == g.Max(y => y.Items.Count)))
                    //    .ToList();

                    //// Add - sign for oldApplied TotalDiscount:
                    //var updateOldAppliedListWithTotalDiscount = nonMatchedItemsForOldApplied.Select(x =>
                    //{
                    //    x.TotalDiscount = -x.TotalDiscount;
                    //    return x;
                    //}).ToList();

                    //// Update final result with oldApplied list with - sign:
                    //var finalResultList = maxItemForNonMatchedItems.Select(item =>
                    //{
                    //    var matchedOldItem = updateOldAppliedListWithTotalDiscount
                    //    .FirstOrDefault(oldItem => oldItem.CouponId == item.CouponId && oldItem.TotalDiscount == -item.TotalDiscount);
                    //    if(matchedOldItem != null)
                    //    {
                    //        item.TotalDiscount = -matchedOldItem.TotalDiscount;
                    //    }
                    //    return item;
                    //}).ToList();

                    // select final NewApplied list array from final result:
                   // var maxItemsForNewApplied = nonMatchedItemForNewApplied.Where(item => finalResultList.Any(newItem => newItem.CouponId == item.CouponId && newItem.TotalDiscount == item.TotalDiscount && newItem.Items.SequenceEqual(item.Items) )).ToList() ;

                    // select final oldApplied list array from final result:
                   // var maxItemsForOldApplied = nonMatchedItemsForOldApplied.Where(item => finalResultList.Any(oldItem => oldItem.CouponId == item.CouponId && oldItem.TotalDiscount ==  item.TotalDiscount && oldItem.Items.SequenceEqual(item.Items))).ToList();


                   // finalResultList = maxItemsForNewApplied.Concat(maxItemsForOldApplied).ToList();

                    response.Applied = finalResultList;
                    response.ErrorCode = "";
                    response.ErrorDesc = "";
                    response.Status = "Successful";
                    return response;
                }


                response.Applied = null;
                response.ErrorDesc = "";
                response.ErrorCode = "";
                response.Status = "Failed.";

            }
            catch (Exception ex)
            {
                // response.Applied = null;
                response.ErrorCode = "500";
                response.ErrorDesc = "";
                response.Status = "Something went wrong. Please try again later.";
            }
            return response;
        }
        public async Task<LoginResponse> LoginWithJSONFile(string sharedKey, string secretKey, LoginModel model)
        {
            LoginResponse response = null;
            response = new LoginResponse();
            try
            {
                var jsonData = await ReadJsonFile(sharedKey,secretKey);
                string connectionString = await _helpers.BuildConnectionString(jsonData?.AuthDBCon);
                SqlHelpers sqlHelpers = new SqlHelpers(connectionString);
                var stroedProcName = "Check_UserName_Password";
                int existedUserNamePassword = 0;
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@UserName",model.UserName),
                    new SqlParameter("@Password",_helpers.EncryptedPassword(model.Password))
                };

                existedUserNamePassword = await sqlHelpers.ExecuteIntScalar(stroedProcName,parameters);
                if(existedUserNamePassword > 0)
                {
                    var getUser = await _authRepo.GetUserDetails(model.UserName);
                    var user = await _authRepo.GetTokensFromDB(model.UserName);

                    response.TokenModel = new TokenModel();

                    if (_helpers.IsRefreshTokenExpired(user.Register.RefreshToken.ToString()))
                    {
                        response.TokenModel.RefreshToken = _helpers.GenerateRefreshToken();
                        response.TokenModel.Token = _helpers.GenerateJwtToken(getUser.Register.UserName, getUser.Register.Email, getUser.Register.StoreID, getUser.Register.DateOfBirth, getUser.Register.Role);


                        await _authRepo.UpdateTokenToDB(response.TokenModel, getUser.Register.UserID.ToString().ToUpper());


                        _httpContextAccessor?.HttpContext?.Response.Headers.Add("AccessToken", response.TokenModel.Token);


                        response.StatusCode = 200;
                        response.StatusMessage = "User loggedin successfully.";

                        return response;
                    }

                    response.TokenModel.Token = user.Register.Token.ToString();

                    response.StatusCode = 200;
                    response.StatusMessage = "User loggedin successfully.";

                    _httpContextAccessor?.HttpContext?.Response.Headers.Add("AccessToken", response.TokenModel.Token);
                }
                else
                {
                    response.StatusCode = 400;
                    response.StatusMessage = "User login has been failed.";
                }

            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.StatusMessage = "Something went wrong. Please try again.";
            }
            return response;
        }

        public async Task<RSAClinetResponse> ReadJsonFile(string sharedKey, string secretKey)
        {
            RSAClinetResponse response = null;
            response = new RSAClinetResponse();
            try
            {

                // Read from local folder json file:
                var fileName = @"RSAClientData.json";
                var currentDirectory =  Directory.GetCurrentDirectory();  
                string[] fullFilePath = Directory.GetFiles(currentDirectory, fileName,SearchOption.AllDirectories);

               
                 if(fullFilePath.Length > 0)
                {
                    using(StreamReader reader = new StreamReader(fullFilePath[0]))
                    {
                      string  jsonStringData = reader.ReadToEnd();
                       var  dataResult = JsonConvert.DeserializeObject<RSAClientDataWrapper>(jsonStringData);
                        Console.WriteLine(dataResult?.RSAClientData);
                    }
                }


                var json = await File.ReadAllTextAsync("D:\\csharpprojects\\JWTRoleAuthentication\\JWTRoleAuthentication\\JSONFiles\\RSAClientData.json");
                var jsonData = JsonConvert.DeserializeObject<RSAClientDataWrapper>(json);
                var data = jsonData?.RSAClientData.FirstOrDefault(item => item.SharedKey == sharedKey && item.SecretKey == secretKey);
                if (data != null)
                {
                    response.RSAClient = new RSAClient
                    {
                        RSAClientId = data.RSAClientId,
                        RSAClientName = data.RSAClientName,
                        Stores = data.Stores,
                        UserName = data.UserName,
                        Email = data.Email,
                        MobileNumber = data.MobileNumber,
                        Address = data.Address,
                        SharedKey = data.SharedKey,
                        SecretKey = data.SecretKey,
                        ServerName = data.ServerName,
                        DatabaseName = data.DatabaseName,
                        UserId = data.UserId,
                        Password = data.Password,                       
                    };
                    response.AuthDBCon = new AuthDBCon
                    {
                       DataSource = data.ServerName,
                        InitialCatalog = data.DatabaseName,
                        UserID = data.UserId,
                        Password = data.Password,
                    };
                    response.StatusCode = 200;
                    response.StatusMessage = "OK";
                    return response;
                }
                response.StatusCode = 404;
                
                response.StatusMessage = "Json file data not found.";

            }
            catch (Exception ex)
            {
                response.StatusCode = 500;

                response.StatusMessage = "Something went wrong. Please try again.";
            }
            return response;
        }


    }
}

