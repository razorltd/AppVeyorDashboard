namespace AppVeyorDashboard
{
   public class Project
   {
      public Project(string accountName, string name, string slug)
      {
         AccountName = accountName;
         Name = name;
         Slug = slug;
      }

      public string AccountName { get; }
      public string Name { get; }
      public string Slug { get; }
   }
}