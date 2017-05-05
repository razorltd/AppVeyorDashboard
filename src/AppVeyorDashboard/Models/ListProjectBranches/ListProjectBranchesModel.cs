namespace AppVeyorDashboard.Models.ListProjectBranches
{
   using System.Collections.Generic;

   public class ListProjectBranchesModel
   {
      public ListProjectBranchesModel(IReadOnlyCollection<string> branches)
      {
         Branches = branches;
      }

      public IReadOnlyCollection<string> Branches { get; }
   }
}