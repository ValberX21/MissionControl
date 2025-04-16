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
      
        public string Name { get; set; } = String.Empty;
  
        public string Destination { get; set; } = String.Empty;
      
        public DateTime LaunchDate { get; set; } = DateTime.Now;
       
        public string RocketType { get; set; } = String.Empty;
   
        public string Status { get; set; } = String.Empty;
    }
}
