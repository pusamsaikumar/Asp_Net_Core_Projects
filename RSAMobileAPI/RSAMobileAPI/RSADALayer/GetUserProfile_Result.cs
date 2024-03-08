namespace RSAMobileAPI.RSADALayer
{
    public class GetUserProfile_Result
    {
        public int UserDetailId { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? ClientStoreId { get; set; }
        public string MemberNumber { get; set; }
        public string FamilyMemberPhoneNumber { get; set; }
        public int IsEmployee { get; set; }
    }
}
