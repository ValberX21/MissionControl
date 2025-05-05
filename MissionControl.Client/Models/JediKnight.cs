using MissionControl.Client.Enum;

namespace MissionControl.Client.Models
{
    public class JediKnight
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string JediName { get; set; }

        public string LightsaberColor { get; set; }

        public JediRank Rank { get; set; } 

        public AccessLevel AccessLevel { get; set; } 

        public DateTime LastAccessTime { get; set; } = DateTime.UtcNow;

        public bool IsDarkSideSuspected { get; set; } = false;

        public string PlanetOrigin { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
