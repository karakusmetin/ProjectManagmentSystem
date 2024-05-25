using PMS_EntityLayer.Concrete;
using System;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;


namespace PMS.ServiceLayer.Services.Abstract
{
    public interface IDocumentService
    {
        Task CreateDocumentAsync(Document document);
        Task<Document> GetDocumentWithIdAsync(Guid documentId);
    }
}
