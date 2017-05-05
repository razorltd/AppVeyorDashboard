namespace AppVeyorDashboard.Core.AppVeyor
{
   using System.Net.Http;
   using Autofac;
   using Builds;
   using Deployments;
   using Environments;
   using Projects;

   public class AppVeyorModule : Module
   {
      protected override void Load(ContainerBuilder builder)
      {
         builder.Register(cc => new HttpClient())
            .AsSelf()
            .SingleInstance();

         builder.RegisterType<AppVeyorHttpClient>()
            .As<IAppVeyorHttpClient>()
            .SingleInstance();

         builder.RegisterType<AppVeyorApi>()
            .As<IAppVeyorApi>()
            .SingleInstance();

         builder.RegisterType<AppVeyorBuilds>()
            .As<IAppVeyorBuilds>()
            .SingleInstance();

         builder.RegisterType<AppVeyorDeployments>()
            .As<IAppVeyorDeployments>()
            .SingleInstance();

         builder.RegisterType<AppVeyorEnvironments>()
            .As<IAppVeyorEnvironments>()
            .SingleInstance();

         builder.RegisterType<AppVeyorProjects>()
            .As<IAppVeyorProjects>()
            .SingleInstance();
      }
   }
}