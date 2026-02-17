using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Models
{
   public class Appointment
   {
      public Appointment()
      {
         CreateDate = DateTime.Now;
         CreatedBy = "test";
         LastUpdateBy = "test";
      }

      public int AppointmentId { get; set; }
      public int CustomerId { get; set; }
      public int UserId { get; set; }
      public string CustomerName { get; set; }
      public string Type { get; set; }
      public DateTime Start { get; set; }
      public DateTime End { get; set; }
      public string Title { get; set; } = "";
      public string Description { get; set; } = "";
      public string Location { get; set; } = "";
      public string Contact { get; set; } = "";
      public string Url { get; set; } = "";
      public string CreatedBy { get; set; } = "test";
      public string LastUpdateBy { get; set; } = "test";
      public DateTime CreateDate { get; set; } = DateTime.Now;
   }
}

