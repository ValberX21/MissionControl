using MissionControl.Shared.Enum;

namespace MissionControl.Shared.Models
{
    public class JediKnightModel
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
