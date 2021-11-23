using GalleryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryProject.Interfaces
{
     public interface IPictureRepository
    {
        Task<Picture> GetPictureByIdAsync(int id);
        Task<List<Picture>> GetPictureAsync();
        Task<Picture> AddPictureAsync(Picture entity);
        Task<Picture> UpdatePictureAsync(Picture entity);

        Task<Picture> DeletePictureAsync(int id);
    }
}
