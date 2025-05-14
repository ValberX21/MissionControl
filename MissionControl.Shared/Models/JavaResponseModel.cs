using System.ComponentModel.DataAnnotations;

namespace MissionControl.Shared.Models
{
    public class JavaResponseModel
    {
        [Key]
        public Guid JavaResponseId { get; set; }

        public string Status { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public DateTime ReceivedAt { get; set; }
    }
}
