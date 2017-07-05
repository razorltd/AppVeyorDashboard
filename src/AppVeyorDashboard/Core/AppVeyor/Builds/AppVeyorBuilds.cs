namespace AppVeyorDashboard.Core.AppVeyor.Builds
{
   using System;
   using System.Linq;
   using System.Threading.Tasks;
   using Newtonsoft.Json.Linq;

   public class AppVeyorBuilds : IAppVeyorBuilds
   {
      private readonly IAppVeyorHttpClient _httpClient;

      public AppVeyorBuilds(IAppVeyorHttpClient httpClient)
      {
         _httpClient = httpClient;
      }

      public async Task<ViewBuildProjection> View(ViewBuildQuery query)
      {
         var response = await _httpClient.GetAsync($"projects/{query.AccountName}/{query.ProjectSlug}/branch/{query.Branch}");
         var json = await response.Content.ReadAsStringAsync();
         var model = JObject.Parse(json);
         var projectToken = model.Value<JToken>("project");
         var buildToken = model.Value<JToken>("build");
         var jobToken = buildToken.Value<JToken>("jobs")
            .Children()
            .FirstOrDefault();

         return new ViewBuildProjection
         (
            projectToken.Value<string>("name"),
            projectToken.Value<string>("slug"),
            buildToken.Value<string>("branch"),
            buildToken.Value<string>("version"),
            buildToken.Value<string>("status"),
            buildToken.Value<string>("committerName"),
            buildToken.Value<DateTime>("started"),
            buildToken.Value<DateTime>("finished"),
            TimeSpan.FromMinutes(60),
            jobToken?.Value<int>("compilationErrorsCount"),
            jobToken?.Value<int>("passedTestsCount"),
            jobToken?.Value<int>("failedTestsCount")
         );
      }
   }
}