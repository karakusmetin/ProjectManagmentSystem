using System.Threading.Tasks;
using System;

namespace PMS.ServiceLayer.Services.Abstract
{
    public interface IImageService
    {
        Task<Guid> CreateImageAsync(byte[] bytes,string fileName);
        Task<Guid> DeleteImageAsync(Guid imageId);
    }
}
