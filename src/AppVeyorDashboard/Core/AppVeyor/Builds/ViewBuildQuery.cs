namespace AppVeyorDashboard.Core.AppVeyor.Builds
{
   public class ViewBuildQuery
   {
      public ViewBuildQuery(string accountName, string projectSlug, string branch)
      {
         AccountName = accountName;
         ProjectSlug = projectSlug;
         Branch = branch;
      }

      public string AccountName { get; }
      public string Branch { get; }
      public string ProjectSlug { get; }
   }
}