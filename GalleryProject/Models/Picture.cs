using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryProject.Models
{
    public class Picture:BaseEntity
    {
        public string description { get; set; }
        public string imageUri { get; set; }    
        public DateTime dateAdded { get; set; }
        public int albumId { get; set; }
        public Album album { get; set; }
    }
}
