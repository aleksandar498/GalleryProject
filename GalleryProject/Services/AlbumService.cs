using GalleryProject.Data;
using GalleryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryProject.Services
{
    public class AlbumService
    {
        private readonly GalleryContext _context;


        UnitOfWork unitOfWork;
        public AlbumService(GalleryContext context)
        {
            _context = context;
            unitOfWork = new UnitOfWork(_context);
        }
        public Task<List<Album>> GetAll()
        {
            return unitOfWork.AlbumRepository.GetAlbumAsync();
        }
        public Task<Album> GetById(int id)
        {
            return unitOfWork.AlbumRepository.GetAlbumByIdAsync(id);
        }
        public Task<Album> Update(int id,Album entity)
        {
            return unitOfWork.AlbumRepository.UpdateAlbumAsync(id,entity);
        }
        public Task<Album> Add(Album entity)
        {
            return unitOfWork.AlbumRepository.AddAlbumAsync(entity);
        }
        public Task<Album> Delete(int id)
        {
            return unitOfWork.AlbumRepository.DeleteAlbumAsync(id);
        }
    }
}
