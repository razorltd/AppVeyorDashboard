namespace AppVeyorDashboard.Core.AppVeyor.Environments
{
   using System.Linq;
   using System.Threading.Tasks;
   using Newtonsoft.Json.Linq;

   public class AppVeyorEnvironments : IAppVeyorEnvironments
   {
      private readonly IAppVeyorHttpClient _httpClient;

      public AppVeyorEnvironments(IAppVeyorHttpClient httpClient)
      {
         _httpClient = httpClient;
      }

      public async Task<ListEnvironmentsProjection> List()
      {
         var response = await _httpClient.GetAsync("environments");
         var json = await response.Content.ReadAsStringAsync();
         var model = JArray.Parse(json);

         var environments =
            model.Select(
                  e =>
                     new Environment
                     (
                        e.Value<long>("deploymentEnvironmentId"),
                        e.Value<string>("name")
                     ))
               .ToList();

         return new ListEnvironmentsProjection
         (
            environments
         );
      }
   }
}