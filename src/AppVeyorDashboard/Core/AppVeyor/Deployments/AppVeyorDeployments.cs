namespace AppVeyorDashboard.Core.AppVeyor.Deployments
{
   using System;
   using System.Threading.Tasks;
   using Newtonsoft.Json.Linq;

   public class AppVeyorDeployments : IAppVeyorDeployments
   {
      private readonly IAppVeyorHttpClient _httpClient;

      public AppVeyorDeployments(IAppVeyorHttpClient httpClient)
      {
         _httpClient = httpClient;
      }

      public async Task<ViewDeploymentProjection> View(ViewDeploymentQuery query)
      {
         var response = await _httpClient.GetAsync($"environments/{query.DeploymentEnvironmentId}/deployments");
         var json = await response.Content.ReadAsStringAsync();
         var model = JObject.Parse(json);
         var environmentToken = model.SelectToken("environment");
         var deploymentToken = model.SelectToken("deployments[0]");

         if (deploymentToken == null)
         {
            return null;
         }

         var buildToken = deploymentToken.SelectToken("build");

         return new ViewDeploymentProjection
         (
            environmentToken.Value<string>("name"),
            buildToken.Value<string>("version"),
            deploymentToken.Value<string>("status"),
            deploymentToken.Value<DateTime>("started"),
            deploymentToken.Value<DateTime>("finished")
         );
      }
   }
}