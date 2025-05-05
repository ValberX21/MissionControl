namespace MissionControl.Shared.Models
{
    public class LoginResponse
    {
        public string Message { get; set; } = "";

        public JediKnightModel? jediKnight { get; set; }
    }
}
