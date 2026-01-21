using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Models
{
   public class Appointment
   {
      public int AppointmentId { get; set; }
      public int CustomerId { get; set; }
      public int UserId { get; set; }
      public string Type { get; set; }
      public DateTime StartUtc { get; set; }
      public DateTime EndUtc { get; set; }
   }
}

