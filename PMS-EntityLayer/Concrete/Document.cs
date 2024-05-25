using PMS.CoreLayer.Entities;
using PMS.EntityLayer.Concrete;
using System;

namespace PMS_EntityLayer.Concrete
{
    public class Document : BaseEntityWithId
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
