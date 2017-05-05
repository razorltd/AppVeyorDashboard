namespace AppVeyorDashboard.Core.AppVeyor.Projects
{
   using System.Collections.Generic;

   public class ListProjectBranchesProjection
   {
      public ListProjectBranchesProjection(IReadOnlyCollection<string> branches)
      {
         Branches = branches;
      }

      public IReadOnlyCollection<string> Branches { get; }
   }
}