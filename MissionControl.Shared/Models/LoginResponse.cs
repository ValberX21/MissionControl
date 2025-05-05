namespace MissionControl.Shared.Models
{
    public class LoginResponse
    {
        public string Message { get; set; } = "";

        public JediKnight? jediKnight { get; set; }
    }
}
