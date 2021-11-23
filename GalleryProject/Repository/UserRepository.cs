using GalleryProject.Data;
using GalleryProject.Interfaces;
using GalleryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryProject.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly GalleryContext _context;
        UnitOfWork unitOfWork;
        public UserRepository(GalleryContext context) : base(context)
        {
            _context = context;
            unitOfWork = new UnitOfWork(_context);
        }
        public async Task<User> AddUserAsync(User entity)
        {
            User temp = new User()
            {
                id = entity.id,
                username = entity.username,
                password=entity.password,
                name = entity.name,
                email = entity.email,
                dateOfBirth = entity.dateOfBirth
            };
            await unitOfWork.UserRepository.Add(temp);
            return entity;
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            User tempEntity = await GetUserByIdAsync(id);
            await unitOfWork.UserRepository.Delete(tempEntity);
            return tempEntity;
        }

        public Task<List<User>> GetUserAsync()
        {
            return unitOfWork.UserRepository.ListAll();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {

            return  unitOfWork.UserRepository.GetById(id);
        }

        public async Task<User> UpdateUserAsync(User entity)
        {
            User tempEntity = await GetUserByIdAsync(entity.id);

            tempEntity.username = entity.username;
            tempEntity.password = entity.password;
            tempEntity.name = entity.name;
            tempEntity.email = entity.email;
            tempEntity.dateOfBirth = entity.dateOfBirth;
            await unitOfWork.UserRepository.Update(tempEntity);
            return tempEntity;

        }
    }
}
