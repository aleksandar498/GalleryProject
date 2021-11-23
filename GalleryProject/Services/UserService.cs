using GalleryProject.Data;
using GalleryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryProject.Services
{
    public class UserService
    {
        private readonly GalleryContext _context;


        UnitOfWork unitOfWork;
        public UserService(GalleryContext context)
        {
            _context = context;
            unitOfWork = new UnitOfWork(_context);
        }
        public Task<List<User>> GetAll()
        {
            return unitOfWork.UserRepository.GetUserAsync();
        }
        public Task<User> GetById(int id)
        {
            return unitOfWork.UserRepository.GetUserByIdAsync(id);
        }
        public Task<User> Update(int id,User entity)
        {
            return unitOfWork.UserRepository.UpdateUserAsync(id,entity);
        }
        public Task<User> Add(User entity)
        {
            return unitOfWork.UserRepository.AddUserAsync(entity);
        }
        public Task<User> Delete(int id)
        {
            return unitOfWork.UserRepository.DeleteUserAsync(id);
        }
    }
}
