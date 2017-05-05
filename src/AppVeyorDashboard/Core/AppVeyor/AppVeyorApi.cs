namespace AppVeyorDashboard.Core.AppVeyor
{
   using Builds;
   using Deployments;
   using Environments;
   using Projects;

   public class AppVeyorApi : IAppVeyorApi
   {
      public AppVeyorApi(IAppVeyorBuilds appVeyorBuilds, IAppVeyorDeployments appVeyorDeployments, IAppVeyorEnvironments appVeyorEnvironments, IAppVeyorProjects appVeyorProjects)
      {
         Builds = appVeyorBuilds;
         Deployments = appVeyorDeployments;
         Environments = appVeyorEnvironments;
         Projects = appVeyorProjects;
      }

      public IAppVeyorBuilds Builds { get; }
      public IAppVeyorDeployments Deployments { get; }
      public IAppVeyorEnvironments Environments { get; }
      public IAppVeyorProjects Projects { get; }
   }
}