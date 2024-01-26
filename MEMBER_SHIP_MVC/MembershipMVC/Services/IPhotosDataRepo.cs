using MembershipMVC.Models;

namespace MembershipMVC.Services
{
    public interface IPhotosDataRepo
    {
        Task<IEnumerable<PhotoViewModel>> GetAll();
        bool Add(PhotoViewModel photoViewModel);
        bool Update(PhotoViewModel photoViewModel);
        bool Delete(PhotoViewModel photoViewModel);
        Task<PhotoViewModel> GetByIdAsync(int id);
        bool Save();

    }
}
