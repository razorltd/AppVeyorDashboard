namespace AppVeyorDashboard
{
   using System;
   using System.Reflection;
   using Autofac;
   using Autofac.Extensions.DependencyInjection;
   using Core.AppVeyor;
   using Microsoft.AspNetCore.Builder;
   using Microsoft.AspNetCore.Hosting;
   using Microsoft.Extensions.Configuration;
   using Microsoft.Extensions.DependencyInjection;
   using Middleware;
   using Middleware.IpAddressFilter;
   using Newtonsoft.Json.Converters;

   public class Startup
   {
      public Startup(IHostingEnvironment hostingEnvironment)
      {
         var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(hostingEnvironment.ContentRootPath)
            .AddJsonFile("config.json", false, true)
            .AddEnvironmentVariables();

         if (hostingEnvironment.IsDevelopment())
         {
            configurationBuilder.AddUserSecrets<Startup>();
         }

         Configuration = configurationBuilder.Build();
      }

      public IConfigurationRoot Configuration { get; }

      public void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment)
      {
         if (hostingEnvironment.IsDevelopment())
         {
            applicationBuilder.UseDeveloperExceptionPage();
         }

         applicationBuilder.UseIpAddressFilter();
         applicationBuilder.UseMvc();
         applicationBuilder.UseStaticFiles();
      }

      public IServiceProvider ConfigureServices(IServiceCollection services)
      {
         services.AddOptions()
                 .Configure<AppVeyorApiConfiguration>(o => Configuration.GetSection("AppVeyorApi").Bind(o))
                 .Configure<IpAddressFilterConfiguration>(o => Configuration.GetSection("IpAddressFilter").Bind(o));
         services.AddRouting(o =>
                  {
                     o.AppendTrailingSlash = false;
                     o.LowercaseUrls = true;
                  });
         services.AddMvc()
                 .AddJsonOptions(o =>
                 {
                    o.SerializerSettings.Converters.Add(new StringEnumConverter());
                 });

         var containerBuilder = new ContainerBuilder();
         containerBuilder.RegisterAssemblyModules(GetType().GetTypeInfo().Assembly);
         containerBuilder.Populate(services);
         var container = containerBuilder.Build();
         var serviceProvider = new AutofacServiceProvider(container);

         return serviceProvider;
      }
   }
}