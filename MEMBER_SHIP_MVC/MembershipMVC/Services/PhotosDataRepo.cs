using MembershipMVC.Data;
using MembershipMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace MembershipMVC.Services
{
    public class PhotosDataRepo : IPhotosDataRepo
    {
        private readonly ApplicationDBContext _context;

        public PhotosDataRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public bool Add(PhotoViewModel photoViewModel)
        {
           _context.Photos.Add(photoViewModel);
            
            return Save();
        }
        

        public bool Delete(PhotoViewModel photoViewModel)
        {
          _context.Photos.Remove(photoViewModel);
            return Save();
        }

        public async Task<IEnumerable<PhotoViewModel>> GetAll()
        {

           
            return await _context.Photos.ToListAsync();
        }

        public async Task<PhotoViewModel> GetByIdAsync(int id)
        {
            var result = await _context.Photos.FindAsync(id);
            return result;
        }

        public bool Update(PhotoViewModel photoViewModel)
        {
           _context.Photos.Update(photoViewModel);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
