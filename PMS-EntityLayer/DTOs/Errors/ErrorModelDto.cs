
namespace PMS_EntityLayer.DTOs.Errors
{
    public class ErrorModelDto
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
