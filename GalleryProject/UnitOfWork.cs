using GalleryProject.Data;
using GalleryProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryProject
{
    public class UnitOfWork : IDisposable
    {

        private GalleryContext _context;
        private AlbumRepository _albumRepository;
        private PictureRepository _pictureRepository;
        private UserRepository _userRepository;


        public UnitOfWork(GalleryContext context)
        {
            _context = context;

        }

        public AlbumRepository AlbumRepository
        {
            get
            {
                if (this._albumRepository == null)
                {
                    this._albumRepository = new AlbumRepository(_context);
                }
                return _albumRepository;
            }
        }
        public PictureRepository PictureRepository
        {
            get
            {
                if (this._pictureRepository == null)
                {
                    this._pictureRepository = new PictureRepository(_context);
                }
                return _pictureRepository;
            }
        }
        public UserRepository UserRepository
        {
            get
            {
                if (this._userRepository == null)
                {
                    this._userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }
       
        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
