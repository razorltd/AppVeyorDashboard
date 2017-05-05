namespace AppVeyorDashboard.Core.AppVeyor.Deployments
{
   using System;

   public class ViewDeploymentProjection
   {
      public ViewDeploymentProjection(string environmentName, string version, string status, DateTime startedAt, DateTime finishedAt)
      {
         EnvironmentName = environmentName;
         Version = version;
         Status = status;
         StartedAt = startedAt;
         FinishedAt = finishedAt;
      }

      public string EnvironmentName { get; }
      public DateTime FinishedAt { get; }
      public DateTime StartedAt { get; }
      public string Status { get; }
      public string Version { get; }
   }
}