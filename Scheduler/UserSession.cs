namespace Scheduler
{
   public class UserSession
   {
      public static UserSession Current { get; private set; }

      public int UserId { get; }
      public string UserName { get; }

      private UserSession(int userId, string userName)
      {
         UserId = userId;
         UserName = userName;
      }

      public static void Start(int userId, string userName)
      {
         Current = new UserSession(userId, userName);
      }
   }
}
