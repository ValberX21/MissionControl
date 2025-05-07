using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionControl.Shared.Models
{
    public class JediFilterModel
    {
        public string? JediName { get; set; }
        public int? Rank { get; set; }
        public string? PlanetOrigin { get; set; }
        public bool? IsActive { get; set; }

    }
}
