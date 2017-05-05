namespace AppVeyorDashboard.Controllers
{
   using System.Linq;
   using System.Text.RegularExpressions;
   using System.Threading.Tasks;
   using Core.AppVeyor;
   using Core.AppVeyor.Projects;
   using Microsoft.AspNetCore.Mvc;
   using Models.ListProjectBranches;

   [Route("branches/{accountName}/{projectSlug}", Name = "ListProjectBranches")]
   public class ListProjectBranchesController : Controller
   {
      private readonly IAppVeyorApi _appVeyorApi;

      public ListProjectBranchesController(IAppVeyorApi appVeyorApi)
      {
         _appVeyorApi = appVeyorApi;
      }

      [HttpGet]
      public async Task<IActionResult> Index([FromRoute] string accountName, [FromRoute] string projectSlug, [FromQuery] string branch)
      {
         var query = new ListProjectBranchesQuery(accountName, projectSlug);
         var projection = await _appVeyorApi.Projects.ListBranches(query);
         var model = new ListProjectBranchesModel
         (
            projection.Branches
               .Where(b => string.IsNullOrWhiteSpace(branch) || Regex.IsMatch(b, branch, RegexOptions.IgnoreCase))
               .ToList()
         );

         return Json(model);
      }
   }
}