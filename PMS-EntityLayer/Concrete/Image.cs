using PMS.CoreLayer.Entities;
using PMS.EntityLayer.Concrete;
using System.Collections.Generic;

namespace PMS_EntityLayer.Concrete
{
    public class Image : BaseEntityWithId
    {
        public string FileName { get; set; }
        public byte[] ImageData { get; set; }

        public ICollection<AppUser> Users { get; set;}
    }
}
