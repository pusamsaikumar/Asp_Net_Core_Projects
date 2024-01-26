using System.ComponentModel.DataAnnotations;

namespace LoginDemo.Models
{
   
    [Serializable]
    public class RetailersModel
    {
        [Key]
        public int RSAClientId { get; set; }

        public string ClientName { get; set; }

        //public string ClientProfile { get; set; }

        public string Email { get; set; }

        public string AndriodArn { get; set; }

        public string IphoneArn { get; set; }

        public string AllUsersArn { get; set; }

        public string DBName { get; set; }

        public bool PushNOtificationEnabled { get; set; }

        public bool IsEditView { get; set; }
    }
}
