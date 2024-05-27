using AutoMapper;
using System.Threading.Tasks;
using PMS.DataLayer.UnitOfWorks;
using PMS.ServiceLayer.Services.Abstract;
using PMS_EntityLayer.Concrete;
using System;
using Task = System.Threading.Tasks.Task;


namespace PMS.ServiceLayer.Services.Concrete
{
    public class DocumentService : IDocumentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DocumentService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task CreateDocumentAsync(Document document)
        {
            await unitOfWork.GetRepository<Document>().AddAsync(document);
            await unitOfWork.SaveAsnyc();
        }
         public async Task<Document> GetDocumentWithIdAsync(Guid documentId)
        {
            var document = await unitOfWork.GetRepository<Document>().GetByGuidAsync(documentId);
            return document;
        }
    }
}
