using GalleryProject.Data;
using GalleryProject.Interfaces;
using GalleryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryProject.Repository
{
    public class PictureRepository : GenericRepository<Picture>, IPictureRepository
    {
        private readonly GalleryContext _context;
        UnitOfWork unitOfWork;
        public PictureRepository(GalleryContext context) : base(context)
        {
            _context = context;
            unitOfWork = new UnitOfWork(_context);

        }
        public async Task<Picture> AddPictureAsync(Picture entity)
        {
            Picture temp = new Picture()
            {
                id = entity.id,
                description = entity.description,
                imageUri = entity.imageUri,
                dateAdded = entity.dateAdded,
                albumId=entity.albumId
              
            };
            await unitOfWork.PictureRepository.Add(temp);
            return entity;
        }

        public async Task<Picture> DeletePictureAsync(int id)
        {
            Picture tempEntity = await GetPictureByIdAsync(id);
            await unitOfWork.PictureRepository.Delete(tempEntity);
            return tempEntity;
        }

        public Task<List<Picture>> GetPictureAsync()
        {
            return unitOfWork.PictureRepository.ListAll();
        }

        public async Task<Picture> GetPictureByIdAsync(int id)
        {
            return unitOfWork.PictureRepository.GetById(id);
        }

        public async Task<Picture> UpdatePictureAsync(int id,Picture entity)
        {
            Picture tempEntity = await GetPictureByIdAsync(id);
            if(entity.description!=null) tempEntity.description = entity.description;
            if (entity.imageUri != null) tempEntity.imageUri = entity.imageUri;
            if (entity.dateAdded != null) tempEntity.dateAdded = entity.dateAdded;          
            await unitOfWork.PictureRepository.Update(tempEntity);
            return tempEntity;
        }
    }
}
