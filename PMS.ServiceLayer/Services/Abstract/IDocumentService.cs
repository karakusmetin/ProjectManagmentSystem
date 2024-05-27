using PMS_EntityLayer.Concrete;
using System;
using System.Threading.Tasks;



namespace PMS.ServiceLayer.Services.Abstract
{
    public interface IDocumentService
    {
        System.Threading.Tasks.Task CreateDocumentAsync(Document document);
        Task<Document> GetDocumentWithIdAsync(Guid documentId);
    }
}
