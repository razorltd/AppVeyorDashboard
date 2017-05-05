namespace AppVeyorDashboard.Models.ListDeployments
{
   public class Deployment
   {
      public Deployment(long deploymentEnvironmentId, string environmentName)
      {
         DeploymentEnvironmentId = deploymentEnvironmentId;
         EnvironmentName = environmentName;
      }

      public long DeploymentEnvironmentId { get; }
      public string EnvironmentName { get; }
   }
}