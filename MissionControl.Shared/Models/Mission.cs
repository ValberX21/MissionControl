using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionControl.Shared.Models
{
    public class Mission
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = String.Empty;
        [Required]
        public string Destination { get; set; } = String.Empty;
        [Required]
        public DateTime LaunchDate { get; set; } = DateTime.Now;
        [Required]
        public string RocketType { get; set; } = String.Empty;
        [Required]
        public string Status { get; set; } = String.Empty;
    }
}
