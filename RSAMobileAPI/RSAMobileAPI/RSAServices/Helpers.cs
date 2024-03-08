using RSAMobileAPI.RSARepositories.Services;

namespace RSAMobileAPI.RSAServices
{
    public class Helpers
    {
        private readonly ConfigurationHelper _configurationHelper;

        public Helpers(ConfigurationHelper configurationHelper)
        {
            _configurationHelper = configurationHelper;
        }
        public  int GetNoOfDays(DateTime expiryDate)
        {
            int noOfDays = 0;
            try
            {
               
                var currentDate = DateTime.Now.AddHours(_configurationHelper.HoursDifferenceBetweenGMTAndClient);
                //noOfDays = Convert.ToInt32(currentDate.Subtract(expiryDate).TotalDays);
               noOfDays = (expiryDate - currentDate).Days;
                if(noOfDays < 0)
                {
                    noOfDays = 0;
                }

            }
            catch (Exception ex)
            {
                noOfDays = 0;

            }
            return noOfDays;
        }
    }
}
