namespace AppVeyorDashboard.Core.AppVeyor.Deployments
{
   public class ViewDeploymentQuery
   {
      public ViewDeploymentQuery(long deploymentEnvironmentId)
      {
         DeploymentEnvironmentId = deploymentEnvironmentId;
      }

      public long DeploymentEnvironmentId { get; }
   }
}