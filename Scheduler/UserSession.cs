using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public class UserSession
    {
      public int UserId { get; }
      public string UserName { get; }
      public UserSession(int userId, string userName)
      {
        UserId = userId;
        UserName = userName;
      }
   }
}
