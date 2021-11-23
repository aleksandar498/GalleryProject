using GalleryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryProject.Interfaces
{
    interface IGenericRepository<T> where T:BaseEntity
    {
        T GetById(int id);
        Task<List<T>> ListAll();

        Task<T> Add(T entity);
        Task<T> Update(T entity);

        Task<T> Delete(T entity);
    }
}
