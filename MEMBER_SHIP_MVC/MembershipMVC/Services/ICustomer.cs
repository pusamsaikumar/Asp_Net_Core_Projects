using System.Data;

namespace MembershipMVC.Services
{
    public interface ICustomer
    {
        string DocumentUpload(IFormFile fromFile);
        DataTable CustomerDatable(string path);
        void ImportCustomer(DataTable customer);
    }
}
