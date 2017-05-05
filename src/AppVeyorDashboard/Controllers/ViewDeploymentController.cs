namespace AppVeyorDashboard.Controllers
{
   using System.Threading.Tasks;
   using Core.AppVeyor;
   using Core.AppVeyor.Deployments;
   using Microsoft.AspNetCore.Mvc;
   using Models.ViewDeployment;

   [Route("deployments/{deploymentEnvironmentId:long}", Name = "ViewDeployment")]
   public class ViewDeploymentController : Controller
   {
      private readonly IAppVeyorApi _appVeyorApi;

      public ViewDeploymentController(IAppVeyorApi appVeyorApi)
      {
         _appVeyorApi = appVeyorApi;
      }

      [HttpGet]
      public async Task<IActionResult> Index([FromRoute] long deploymentEnvironmentId)
      {
         var query = new ViewDeploymentQuery
         (
            deploymentEnvironmentId
         );
         var projection = await _appVeyorApi.Deployments.View(query);

         if (projection == null)
         {
            return Content(null);
         }

         var model = new ViewDeploymentModel
         (
            projection.EnvironmentName,
            projection.Version,
            projection.Status,
            projection.StartedAt,
            projection.FinishedAt
         );

         return View(model);
      }
   }
}