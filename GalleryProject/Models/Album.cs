using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryProject.Models
{
    public class Album:BaseEntity
    {
        public string albumName { get; set; }
        public string description { get; set; }      
        public DateTime dateCreated { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
   


    }
}
