using PMS.CoreLayer.Entities;
using PMS.EntityLayer.Concrete;
using System.Collections.Generic;

namespace PMS_EntityLayer.Concrete
{
    public class Image : BaseEntityWithId
    {
        public string FileName { get; set; }
        public string FileType { get; set; }

        public ICollection<AppUser> Users { get; set;}

        public ICollection<Project> Projects { get; set; }

    }
}
