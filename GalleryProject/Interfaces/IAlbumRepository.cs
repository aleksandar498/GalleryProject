using GalleryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryProject.Interfaces
{
    public interface IAlbumRepository
    {
        Task<Album> GetAlbumByIdAsync(int id);
        Task<List<Album>> GetAlbumAsync();
        Task<Album> AddAlbumAsync(Album entity);
        Task<Album> UpdateAlbumAsync(Album entity);

        Task<Album> DeleteAlbumAsync(int id);
    }
}
