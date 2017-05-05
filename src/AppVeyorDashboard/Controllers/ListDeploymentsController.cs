namespace AppVeyorDashboard.Controllers
{
   using System.Linq;
   using System.Text.RegularExpressions;
   using System.Threading.Tasks;
   using Core.AppVeyor;
   using Microsoft.AspNetCore.Mvc;
   using Models.ListDeployments;

   [Route("deployments", Name = "ListDeployments")]
   public class ListDeploymentsController : Controller
   {
      private readonly IAppVeyorApi _appVeyorApi;

      public ListDeploymentsController(IAppVeyorApi appVeyorApi)
      {
         _appVeyorApi = appVeyorApi;
      }

      [HttpGet]
      public async Task<IActionResult> Index([FromQuery] string environment)
      {
         var projection = await _appVeyorApi.Environments.List();
         var model = new ListDeploymentsModel
         (
            projection.Environments
               .Where(e => string.IsNullOrWhiteSpace(environment) || Regex.IsMatch(e.EnvironmentName, environment, RegexOptions.IgnoreCase))
               .Select(e => new Deployment(e.DeploymentEnvironmentId, e.EnvironmentName))
               .ToList()
         );

         if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
         {
            return Json(model);
         }

         return View(model);
      }
   }
}