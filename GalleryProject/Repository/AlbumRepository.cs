using GalleryProject.Data;
using GalleryProject.Interfaces;
using GalleryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryProject.Repository
{
    public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
    {
        private readonly GalleryContext _context;
        UnitOfWork unitOfWork;
        public AlbumRepository(GalleryContext context) : base(context)
        {
            _context = context;
            unitOfWork = new UnitOfWork(_context);
        }
        public async Task<Album> AddAlbumAsync(Album entity)
        {
            Album temp = new Album()
            {
                id = entity.id,
                albumName = entity.albumName,
                description = entity.description,
                dateCreated = entity.dateCreated,
                userId=entity.userId

               

            };
            await unitOfWork.AlbumRepository.Add(temp);
            return entity;
        }

        public async Task<Album> DeleteAlbumAsync(int id)
        {
            Album tempEntity = await GetAlbumByIdAsync(id);
            await unitOfWork.AlbumRepository.Delete(tempEntity);
            return tempEntity;
        }

        public Task<List<Album>> GetAlbumAsync()
        {
            return unitOfWork.AlbumRepository.ListAll();
        }

        public async Task<Album> GetAlbumByIdAsync(int id)
        {
            return unitOfWork.AlbumRepository.GetById(id);
        }

        public async Task<Album> UpdateAlbumAsync(int id,Album entity)
        {
            Album tempEntity = await GetAlbumByIdAsync(id);
            if (entity.albumName != null) tempEntity.albumName = entity.albumName;
            if (entity.description != null) tempEntity.description = entity.description;
            if (entity.dateCreated != null) tempEntity.dateCreated = entity.dateCreated;
          
            await unitOfWork.AlbumRepository.Update(tempEntity);
            return tempEntity;
        }
    }
}
