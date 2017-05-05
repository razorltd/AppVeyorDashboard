namespace AppVeyorDashboard.Models.ListBuilds
{
   public class Project
   {
      public Project(string accountName, string slug)
      {
         AccountName = accountName;
         Slug = slug;
      }

      public string AccountName { get; }
      public string Slug { get; }
   }
}