using GalleryProject.Data;
using GalleryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryProject.Services
{
    public class PictureService
    {
        private readonly GalleryContext _context;


        UnitOfWork unitOfWork;
        public PictureService(GalleryContext context)
        {
            _context = context;
            unitOfWork = new UnitOfWork(_context);
        }
        public Task<List<Picture>> GetAll()
        {
            return unitOfWork.PictureRepository.GetPictureAsync();
        }
        public Task<Picture> GetById(int id)
        {
            return unitOfWork.PictureRepository.GetPictureByIdAsync(id);
        }
        public Task<Picture> Update(Picture entity)
        {
            return unitOfWork.PictureRepository.UpdatePictureAsync(entity);
        }
        public Task<Picture> Add(Picture entity)
        {
            return unitOfWork.PictureRepository.AddPictureAsync(entity);
        }
        public Task<Picture> Delete(int id)
        {
            return unitOfWork.PictureRepository.DeletePictureAsync(id);
        }
    }
}
