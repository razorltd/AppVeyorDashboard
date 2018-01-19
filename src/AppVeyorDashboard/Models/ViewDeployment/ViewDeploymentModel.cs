namespace AppVeyorDashboard.Models.ViewDeployment
{
   using System;

   public class ViewDeploymentModel
   {
      public ViewDeploymentModel(string environmentName, string version, string status, DateTime startedAt, DateTime finishedAt)
      {
         EnvironmentName = environmentName;
         Version = version;
         Status = status;
         StartedAt = startedAt;
         FinishedAt = finishedAt;
      }

      public TimeSpan? DeploymentTime
      {
         get
         {
            if (StartedAt == DateTime.MinValue)
            {
               return null;
            }

            return (FinishedAt == DateTime.MinValue ? DateTime.Now : FinishedAt) - StartedAt;
         }
      }
      public string EnvironmentName { get; }
      public DateTime FinishedAt { get; }
      public DateTime StartedAt { get; }
      public string Status { get; }
      public string Version { get; }
   }
}