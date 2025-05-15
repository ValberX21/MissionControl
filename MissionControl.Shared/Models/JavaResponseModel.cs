using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MissionControl.Shared.Models
{
    public class JavaResponseModel
    {
        [Key]
        [JsonPropertyName("id")] // or use [JsonProperty("id")] if using Newtonsoft
        public Guid JavaResponseId { get; set; }

        [JsonPropertyName("externalReference")]
        public string ExternalReference { get; set; } = string.Empty;

        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;

        [JsonPropertyName("message")]
        public string Details { get; set; } = string.Empty;

        [JsonPropertyName("receivedAt")]
        public DateTime ReceivedAt { get; set; }
    }
}
