using GalleryProject.Data;
using GalleryProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalleryProject.Models;

namespace GalleryProject.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly GalleryContext _context;
        private DbSet<T> entities;
      
        public GenericRepository(GalleryContext context)
        {
            _context = context;
            entities = _context.Set<T>();


        }
        public async Task<T> Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity cannot be null", nameof(entity));
            }
            try
            {

                await entities.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;

            }
            catch (Exception e)
            {

                throw new ArgumentException("Save failed", e.Message);
            }
        }
        public async Task<T> Delete(T entity)
        {
            try
            {
                entities.Remove(entity);
                await _context.SaveChangesAsync();
                return entity;

            }
            catch (Exception)
            {

                throw new ArgumentException("Delete failed");
            }
        }

        public T GetById(int id)
        {
            return entities.Find(id);
        }

        public Task<List<T>> ListAll()
        {
            return entities.ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("Entity cannot be null", nameof(entity));
            }
            try
            {
                entities.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {

                throw new ArgumentException("Update failed", nameof(entity));
            }
        }
    }
}
