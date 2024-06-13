using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using PMS.ServiceLayer.Services.Abstract;
using PMS_EntityLayer.DTOs.Mail;
using System;
using System.Threading.Tasks;


namespace PMS_WebUI.Controllers
{
    public class MailController : Controller
    {
        private readonly IProjectService projectService;

        public MailController(IProjectService projectService)
        {
            this.projectService = projectService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(Guid projectId)
        {
            var project = await projectService.GetProjectWithNonDeletedWithUsersWithTasksWithManagerAsync(projectId);
            var mailreq = new MailRequest
            {
                ProjectName=project.ProjectName,
                ReceiverMail = project.ProjectManager.AppUser.Email,
                Subject = project.ProjectName +" projesi hakkında danışma",
                ProjectManagerName = project.ProjectManager.AppUser.FirstName+" "+project.ProjectManager.AppUser.LastName,
                UserName = HttpContext.User.Identity.Name,

            };
            return View(mailreq);
        }
        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("ProjeYönetimSistemi", "projectmanagementsystemm@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            mimeMessage.Subject = mailRequest.Subject;

            var bodyBuilder = new BodyBuilder();

            // Yeni eklenen alanları kullanarak mail içeriğini dinamik hale getirme
            bodyBuilder.TextBody = $@"
            Proje: {mailRequest.ProjectName}
            Kullanıcı: {mailRequest.UserName}

            {$@"Merhaba Sayın {mailRequest.ProjectManagerName}"}

            {mailRequest.Body}

            {"(Uyarı)Bu mail yöneticisi olduğunuz proje yönetim sistemi üzerindeki ismi geçen proje dolayısıyla projede görevi veya görevleri bulanan bir kullanıcıdan gelmiştir.Eğer bilginiz dışındaysa lütfen dikkate alamyınız"}";

            mimeMessage.Body = bodyBuilder.ToMessageBody();

            using (SmtpClient client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("projectmanagementsystemm@gmail.com", "oabffthvxpadvzja");
                client.Send(mimeMessage);
                client.Disconnect(true);
            }

            return RedirectToAction("Index", "UserTask");
        }
    }
}
