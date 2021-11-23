using GalleryProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryProject.Data
{
    public class GalleryContext : DbContext
    {
        public GalleryContext()
        {

        }
        public GalleryContext(DbContextOptions<GalleryContext> options) : base(options)
        {
        }
        public DbSet<Album> Album { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Picture> Picture { get; set; }
    }

}
