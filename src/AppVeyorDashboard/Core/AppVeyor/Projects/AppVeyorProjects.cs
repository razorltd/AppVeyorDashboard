namespace AppVeyorDashboard.Core.AppVeyor.Projects
{
   using System.Linq;
   using System.Threading.Tasks;
   using Newtonsoft.Json.Linq;

   public class AppVeyorProjects : IAppVeyorProjects
   {
      private readonly IAppVeyorHttpClient _httpClient;

      public AppVeyorProjects(IAppVeyorHttpClient httpClient)
      {
         _httpClient = httpClient;
      }

      public async Task<ListProjectsProjection> List()
      {
         var response = await _httpClient.GetAsync("projects");
         var json = await response.Content.ReadAsStringAsync();
         var model = JArray.Parse(json);

         var projects =
            model.Select(p => new Project
               (
                  p.Value<string>("accountName"),
                  p.Value<string>("name"),
                  p.Value<string>("slug")
               ))
               .ToList();

         return new ListProjectsProjection
         (
            projects
         );
      }

      public async Task<ListProjectBranchesProjection> ListBranches(ListProjectBranchesQuery query)
      {
         var response =
            await _httpClient.GetAsync($"projects/{query.AccountName}/{query.ProjectSlug}/history?recordsNumber=10");
         var json = await response.Content.ReadAsStringAsync();
         var model = JObject.Parse(json);
         var branches = model.SelectToken("builds").Select(b => b.SelectToken("branch"))
            .Values<string>()
            .Distinct()
            .ToList();

         return new ListProjectBranchesProjection
         (
            branches
         );
      }
   }
}