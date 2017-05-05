
namespace AppVeyorDashboard.Controllers
{
   using System.Linq;
   using System.Text.RegularExpressions;
   using System.Threading.Tasks;
   using Core.AppVeyor;
   using Microsoft.AspNetCore.Mvc;
   using Models.ListBuilds;

   [Route("builds", Name = "ListBuilds")]
   public class ListBuildsController : Controller
   {
      private readonly IAppVeyorApi _appVeyorApi;

      public ListBuildsController(IAppVeyorApi appVeyorApi)
      {
         _appVeyorApi = appVeyorApi;
      }

      [HttpGet]
      public async Task<IActionResult> Index([FromQuery] string project, [FromQuery] string branch)
      {
         var projection = await _appVeyorApi.Projects.List();
         var projects = projection.Projects
            .Where(p => string.IsNullOrWhiteSpace(project) || Regex.IsMatch(p.Name, project, RegexOptions.IgnoreCase))
            .Select(p => new Project
            (
               p.AccountName,
               p.Slug
            ))
            .ToList();

         var model = new ListBuildsModel
         (
            branch,
            projects
         );

         if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
         {
            return Json(model);
         }

         return View(model);
      }
   }
}