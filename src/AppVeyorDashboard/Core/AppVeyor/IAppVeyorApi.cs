namespace AppVeyorDashboard.Core.AppVeyor
{
   using Builds;
   using Deployments;
   using Environments;
   using Projects;

   public interface IAppVeyorApi
   {
      IAppVeyorBuilds Builds { get; }
      IAppVeyorDeployments Deployments { get; }
      IAppVeyorEnvironments Environments { get; }
      IAppVeyorProjects Projects { get; }
   }
}