
namespace AppVeyorDashboard.Controllers
{
   using System.Threading.Tasks;
   using Core.AppVeyor;
   using Core.AppVeyor.Builds;
   using Microsoft.AspNetCore.Mvc;
   using Models.ViewBuild;

   [Route("builds/{accountName}/{projectSlug}", Name = "ViewBuild")]
   public class ViewBuildController : Controller
   {
      private readonly IAppVeyorApi _appVeyorApi;

      public ViewBuildController(IAppVeyorApi appVeyorApi)
      {
         _appVeyorApi = appVeyorApi;
      }

      [HttpGet]
      public async Task<IActionResult> Index([FromRoute] string accountName, [FromRoute] string projectSlug, [FromQuery] string branch)
      {
         var query = new ViewBuildQuery
         (
            accountName, 
            projectSlug,
            branch
         );
         var build = await _appVeyorApi.Builds.View(query);
         var model = new ViewBuildModel
         (
            build.ProjectName,
            build.ProjectSlug,
            build.Branch,
            build.Version,
            build.Status,
            build.CommitterName,
            build.StartedAt,
            build.FinishedAt,
            build.Timeout,
            build.CompilationErrorsCount,
            build.PassedTestsCount,
            build.FailedTestsCount
         );

         return View(model);
      }
   }
}