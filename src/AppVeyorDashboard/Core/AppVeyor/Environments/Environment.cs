namespace AppVeyorDashboard.Core.AppVeyor.Environments
{
   public class Environment
   {
      public Environment(long deploymentEnvironmentId, string environmentName)
      {
         DeploymentEnvironmentId = deploymentEnvironmentId;
         EnvironmentName = environmentName;
      }

      public long DeploymentEnvironmentId { get; }
      public string EnvironmentName { get; }
   }
}