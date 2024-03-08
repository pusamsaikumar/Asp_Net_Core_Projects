using Microsoft.Data.SqlClient;
using RSAMobileAPI.RSARepositories.Services;
using System.Data;
using System.Security.Cryptography.Xml;
using static RSAMobileAPI.RSAEntities.GetClientStoreForAppResponse;

namespace RSAMobileAPI.RSAServices
{
    public class MultipleResultSets
    {
        private readonly IConfiguration _configuration;
        private readonly ConfigurationHelper _configurationHelper;

        public MultipleResultSets(
            IConfiguration configuration,
            ConfigurationHelper configurationHelper
            )
        {
            _configuration = configuration;
            _configurationHelper = configurationHelper;
        }
        public FinalUserCouponsandGroups GetUserCouponsandGroups(int UserId)
        {
            FinalUserCouponsandGroups finalList = new FinalUserCouponsandGroups();
            List<UserCouponsandGroups> redeemedCouponsList = new List<UserCouponsandGroups>();
            List<UserOptInCoupons> OptInCouponsList = new List<UserOptInCoupons>(); 
            List<UserGroups> groupsList = new List<UserGroups>();

            //string connectionName = "";
            //connectionName = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;

            string connectionName = "RSADBCon";
          string connection  = _configuration.GetConnectionString(connectionName);
           SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            cmd = new SqlCommand("Mobile_GetUserCouponsandGroups", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@UserID",UserId));
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Close();
            DataTable dtRedeemedCoupons = ds.Tables[0];  
            DataTable dtOptInCoupons = ds.Tables[1]; 
            DataTable dtUserGroups = ds.Tables[2];
            redeemedCouponsList =(from DataRow dr in dtRedeemedCoupons.Rows
                                  select new UserCouponsandGroups
                                  {
                                        NewsID = Convert.ToInt32(dr["NewsID"]),
                                        UserID = Convert.ToInt32(dr["UserID"])
                                  }
                                  ).ToList();
            OptInCouponsList = (from DataRow dr in dtOptInCoupons.Rows
                                select new UserOptInCoupons
                                {
                                    SSNewsID = Convert.ToInt32(dr["SSNewsID"]),
                                    UserID = Convert.ToInt32(dr["UserID"])
                                }
                                ).ToList();
            groupsList = (from DataRow dr in dtUserGroups.Rows
                          select new UserGroups
                          {
                            ClubID = Convert.ToInt32(dr["ClubID"]),
                            UserID = Convert.ToInt32(dr["UserID"])
                          }
                          ).ToList();
            finalList.UserRedeemedCoupons = redeemedCouponsList;
            finalList.UserOptionCoupons = OptInCouponsList;
            finalList.UserGroups = groupsList;
            return finalList;   
        }
        public ClientGeneralInfoResponse GetClientGeneralInfo()
        {
            ClientGeneralInfoResponse finalList = new ClientGeneralInfoResponse();  
            ClientGeneralInfo companySettingsList = new ClientGeneralInfo();
            List<SocialMediaSettings> socialMediaSettingsList = new List<SocialMediaSettings>();
            //string connectionName = "";
            //connectionName = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
            string connectionName = "";
            connectionName = _configuration.GetConnectionString("RSADBCon").ToString();
            SqlConnection con = new SqlConnection(connectionName);
            try
            {
               con.Open();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet(); 
                cmd = new SqlCommand("getclientgeneralinfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StoreId", 0);
                cmd.Parameters.AddWithValue("@ClientId", 0);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                DataTable dtCompanySettings = ds.Tables[0];
                DataTable dtSocialMediaSettings = ds.Tables[1];
                if(dtCompanySettings.Rows.Count > 0)
                {
                    DataRow dRow = dtCompanySettings.Rows[0];
                    companySettingsList.ClientStoreName = dRow["ClientStoreName"].ToString();
                    companySettingsList.City = dRow["City"].ToString();
                    companySettingsList.State = dRow["State"].ToString();
                    companySettingsList.ZipCode = dRow["ZipCode"].ToString();
                    companySettingsList.StorePhoneNumber = dRow["StorePhoneNumber"].ToString();
                    companySettingsList.WebSiteURL = dRow["WebSiteURL"].ToString();
                    companySettingsList.ClientStoreId = Convert.ToInt32(dRow["ClientStoreId"].ToString());
                    companySettingsList.AddressLine1 = dRow["AddressLine1"].ToString();
                    companySettingsList.AddressLine2 = dRow["AddressLine2"].ToString();
                    companySettingsList.StoreEmail = dRow["StoreEmail"].ToString();
                    companySettingsList.SupportEmail = dRow["SupportEmail"].ToString();
                    companySettingsList.AllowLinkCardRegistration = Convert.ToBoolean(dRow["AllowLinkCardRegistration"]);
                    companySettingsList.AllowNewRegistration = Convert.ToBoolean(dRow["AllowNewRegistration"]);
                    companySettingsList.MemberCardMinLength = Convert.ToInt32(dRow["MemberCardMinLength"].ToString());
                    companySettingsList.MemberCardMaxLength = Convert.ToInt32(dRow["MemberCardMaxLength"].ToString());
                    companySettingsList.EnableStoreEvents = Convert.ToBoolean(dRow["EnableStoreEvents"]);
                    companySettingsList.StoreTimings = dRow["StoreTimings"].ToString();
                    companySettingsList.StoreTimingLable = dRow["StoreTimingLable"].ToString();
                    companySettingsList.ClientLogo = string.Concat(_configurationHelper.BarCodeUrlPath, "ClientImages/", "ClientLogo.png");
                    companySettingsList.UsePhoneNumberAsLoyaltyNumber = Convert.ToBoolean(dRow["UsePhoneNumberAsLoyaltyNumber"]);
                    companySettingsList.EnableEmailAddressUpdate = Convert.ToBoolean(dRow["EnableEmailAddressUpdate"]);
                    companySettingsList.IsPhoneNumberMandatory = Convert.ToBoolean(dRow["IsPhoneNumberMandatory"]);
                    companySettingsList.EnableShopMenu = Convert.ToBoolean(dRow["IsPhoneNumberMandatory"]);
                    companySettingsList.EnableShopMenuWebSiteUrl = Convert.ToString(dRow["EnableShopMenuWebSiteUrl"]);
                    companySettingsList.LinkCardRegistrationText = Convert.ToString(dRow["LinkCardRegistrationText"]);
                    companySettingsList.EnableCateringMenu = Convert.ToBoolean(dRow["EnableCateringMenu"]);
                    companySettingsList.EnableCateringMenuWebSiteUrl = Convert.ToString(dRow["EnableCateringMenuWebSiteUrl"]);
                    companySettingsList.PrescriptionRefillsLinkUrl = Convert.ToString(dRow["PrescriptionRefillsLinkUrl"]);
                    companySettingsList.PrescriptionRefillsText = Convert.ToString(dRow["PrescriptionRefillsText"]);
                }

                socialMediaSettingsList = (from DataRow dr in dtSocialMediaSettings.Rows
                                           select new SocialMediaSettings
                                           {
                                               Title = dr["Title"].ToString(),
                                               Value = dr["Value"].ToString(),
                                               ImageURL = dr["ImageURL"].ToString(),
                                               IsSocialMedia = Convert.ToBoolean(dr["IsSocialMedia"]),
                                               SequenceNumber = Convert.ToInt32(dr["SequenceNumber"])
                                           }
                                           ).ToList();
                finalList.ClientGeneralInfo = companySettingsList;
                finalList.SocialMediaSettings = socialMediaSettingsList;
            }catch (Exception ex)
            {
                con.Close();    
            }
            return finalList;
        }
        public Survey Survey()
        {
            Survey objSurvey = new Survey();
            List<SurveyQuestions> surveyQuestionsList = new List<SurveyQuestions>();   
            List<SurveyQuestionOptions> surveyQuestionOptionsList = new List<SurveyQuestionOptions>();
            // string connectionName = "";
            //connectionName = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
            string connectionName = "";
            connectionName = _configuration.GetConnectionString("RSADBCon").ToString();
            SqlConnection con = new SqlConnection(connectionName);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                cmd = new SqlCommand("GetSurveys", con);
                cmd.CommandType = CommandType.StoredProcedure;
                da= new SqlDataAdapter(cmd);
                da.Fill(ds);
                DataTable dtSuvery = ds.Tables[0];
                DataTable dtQuestions = ds.Tables[1];
                DataTable dtQuestionOptions = ds.Tables[2]; 
                if(dtSuvery.Rows.Count > 0)
                {
                    DataRow dRow = dtSuvery.Rows[0];
                    objSurvey.SurveyID = Convert.ToInt32(dRow["SurveyID"].ToString());
                    objSurvey.StartsOn = Convert.ToDateTime(dRow["StartsOn"].ToString());
                    objSurvey.ExpiresOn = Convert.ToDateTime(dRow["ExpiresOn"].ToString()) ;
                    objSurvey.Title = dRow["Title"].ToString();
                    objSurvey.Details = dRow["Details"].ToString();
                    objSurvey.SurveyImageURL = (string.IsNullOrEmpty(dRow["SurveyImageURL"].ToString()) == true ? "" : dRow["SurveyImageURL"].ToString());
                    objSurvey.IsStoreSpecific = Convert.ToBoolean(dRow["IsStoreSpecific"].ToString());
                    objSurvey.IsTargetSpecific = Convert.ToBoolean(dRow["IsTargetSpecific"].ToString());
                    objSurvey.RewardCouponID = (string.IsNullOrEmpty(dRow["RewardCouponID"].ToString()) == true ? 0 : Convert.ToInt32(dRow["RewardCouponID"].ToString()));
                    objSurvey.RewardPoints = (string.IsNullOrEmpty(dRow["RewardPoints"].ToString()) == true ? 0 : Convert.ToDecimal(dRow["RewardPoints"].ToString()));
                    objSurvey.NumberOfQuestions = (string.IsNullOrEmpty(dRow["NumberOfQuestions"].ToString()) == true ? 0 : Convert.ToInt32(dRow["NumberOfQuestions"].ToString()));
                }
                objSurvey.SurveyQuestions = (from DataRow dr in dtQuestions.Rows
                                             select new SurveyQuestions()
                                             {
                                                 SurveyQuestionID = Convert.ToInt32(dr["SurveyQuestionID"].ToString()),
                                                 SurveyID = Convert.ToInt32(dr["SurveyID"].ToString()),
                                                 SortPosition = Convert.ToInt32(dr["SortPosition"].ToString()),
                                                 QuestionTitle = dr["QuestionTitle"].ToString(),
                                                 TotalOptions = Convert.ToInt32(dr["TotalOptions"].ToString()),
                                                 SurveyQuestionOptions = (from DataRow dtdr in dtQuestionOptions.Rows
                                                                          select new SurveyQuestionOptions()
                                                                          {
                                                                              SurveyQuestionOptionID = Convert.ToInt32(dtdr["SurveyQuestionOptionID"].ToString()),
                                                                              SurveyQuestionID = Convert.ToInt32(dtdr["SurveyQuestionID"].ToString()),
                                                                              SortPosition = Convert.ToInt32(dtdr["SortPosition"].ToString()),
                                                                              OptionTitle = dtdr["OptionTitle"].ToString(),
                                                                              OptionIconTypeID = Convert.ToInt32(dtdr["OptionIconTypeID"].ToString()),

                                                                          }).ToList().Where(r => r.SurveyQuestionID == Convert.ToInt32(dr["SurveyQuestionID"].ToString())).ToList()

                                             }).ToList();
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close() ;
            }
            return objSurvey;   
        }
    }
}
