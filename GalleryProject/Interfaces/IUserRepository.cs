using GalleryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryProject.Interfaces
{
   public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<List<User>> GetUserAsync();
        Task<User> AddUserAsync(User entity);
        Task<User> UpdateUserAsync(User entity);

        Task<User> DeleteUserAsync(int id);
    }
}
