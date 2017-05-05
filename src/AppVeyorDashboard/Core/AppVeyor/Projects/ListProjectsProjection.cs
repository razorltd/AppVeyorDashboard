namespace AppVeyorDashboard.Core.AppVeyor.Projects
{
   using System.Collections.Generic;

   public class ListProjectsProjection
   {
      public ListProjectsProjection(IReadOnlyCollection<Project> projects)
      {
         Projects = projects;
      }

      public IReadOnlyCollection<Project> Projects { get; }
   }
}