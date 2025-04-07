namespace MissionControl.Shared.Models
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = true;
        public object Data { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<string> ErrorMessage { get; set; }
    }
}
