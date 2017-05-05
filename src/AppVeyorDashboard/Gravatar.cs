namespace AppVeyorDashboard
{
   using System.Collections.Generic;

   public static class Gravatar
   {
      static Gravatar()
      {
         Urls = new Dictionary<string, string>();
      }

      public static Dictionary<string, string> Urls { get; }
   }
}