namespace PMS_EntityLayer.DTOs.Mail
{
    public class MailRequest
    {
        public string Name { get; set; }
        public string SenderMail { get; set; }
        public string ReceiverMail { get; set; }
        public string ProjectManagerName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string ProjectName { get; set; }
        public string UserName { get; set; }
    }
}
