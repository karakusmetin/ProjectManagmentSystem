using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS.ServiceLayer.Services.Abstract;
using PMS_EntityLayer.Concrete;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PMS_WebUI.Areas.ProjectManager.Controllers
{
    [Area("ProjectManager")]
    [Authorize(Roles = "Admin,ProjectManager,Superadmin")]
    public class DocumentController : Controller
    {
        private readonly IDocumentService documentService;

        public DocumentController(IDocumentService documentService)
        {
            this.documentService = documentService;
        }
        [HttpPost]
        public async Task<ActionResult> Add(IFormFile fromFile,Guid projectId)
        {
            var document = new Document { };

            if (fromFile != null && fromFile.Length > 0)
            {
                if (fromFile.ContentType != "application/pdf")
                {
                    return Json(new { success = false, message = "Only PDF files are allowed." });
                }

                using var memoryStream = new MemoryStream();
                await fromFile.CopyToAsync(memoryStream);

                document.FileName = fromFile.FileName;
                document.ContentType = fromFile.ContentType;
                document.Content = memoryStream.ToArray();
                document.ProjectId = projectId;
            }
            await documentService.CreateDocumentAsync(document);
            return Json(new { success = true, message = "Document uploaded successfully." });
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Guid documentId,Guid projectId)
        {
            var result = await documentService.DeleteDocumentAsync(documentId);
            if (result)
            {
                return Json(new { success = true, message = "Document deleted successfully." });
            }
            return RedirectToAction("Detail", "Project", new { Area = "ProjectManager", projectId = projectId });

        }
    }
}
