namespace AppVeyorDashboard.Models.ListBuilds
{
   using System.Collections.Generic;

   public class ListBuildsModel
   {
      public ListBuildsModel(string branch, IReadOnlyCollection<Project> projects)
      {
         Branch = branch;
         Projects = projects;
      }

      public string Branch { get; }
      public IReadOnlyCollection<Project> Projects { get; }
   }
}