namespace AppVeyorDashboard.Core.AppVeyor.Projects
{
   public class ListProjectBranchesQuery
   {
      public ListProjectBranchesQuery(string accountName, string projectSlug)
      {
         AccountName = accountName;
         ProjectSlug = projectSlug;
      }

      public string AccountName { get; }
      public string ProjectSlug { get; }
   }
}