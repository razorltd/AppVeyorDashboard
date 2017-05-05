namespace AppVeyorDashboard.Core.AppVeyor.Deployments
{
   using System.Threading.Tasks;

   public interface IAppVeyorDeployments
   {
      Task<ViewDeploymentProjection> View(ViewDeploymentQuery query);
   }
}