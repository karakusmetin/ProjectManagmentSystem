using Microsoft.AspNetCore.Http;
using PMS.DataLayer.UnitOfWorks;
using PMS.ServiceLayer.Extensions;
using PMS.ServiceLayer.Services.Abstract;
using PMS_EntityLayer.Concrete;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PMS.ServiceLayer.Services.Concrete
{
    public class ImageService : IImageService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public ImageService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }
        public async Task<Guid> CreateImageAsync(byte[] bytes, string fileName)
        {
            var image = new Image
            {
                Id = Guid.NewGuid(),
                FileName = fileName,
                InsertDate = DateTime.Now,
                InsertedBy = _user.GetLoggedInEmail(),
                ImageData = bytes
            };
            await unitOfWork.GetRepository<Image>().AddAsync(image);
            await unitOfWork.SaveAsnyc();

            return image.Id;
        }
        public async Task<Guid> DeleteImageAsync(Guid imageId)
        {
            var image = await unitOfWork.GetRepository<Image>().GetAsync(x=>x.Id == imageId);
            image.DeletedDate = DateTime.Now;
            image.IsActive = false;
            
            await unitOfWork.GetRepository<Image>().UpdateAsnyc(image);
            await unitOfWork.SaveAsnyc();

            return image.Id;
        }
    }
}
