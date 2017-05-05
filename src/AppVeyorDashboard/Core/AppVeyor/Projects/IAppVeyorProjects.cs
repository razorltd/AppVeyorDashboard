namespace AppVeyorDashboard.Core.AppVeyor.Projects
{
   using System.Threading.Tasks;

   public interface IAppVeyorProjects
   {
      Task<ListProjectBranchesProjection> ListBranches(ListProjectBranchesQuery query);
      Task<ListProjectsProjection> List();
   }
}