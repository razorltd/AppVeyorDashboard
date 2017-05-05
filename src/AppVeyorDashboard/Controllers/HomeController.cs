namespace AppVeyorDashboard.Controllers
{
   using Microsoft.AspNetCore.Mvc;

   [Route("", Name = "Home")]
   public class HomeController : Controller
   {
      [HttpGet]
      public IActionResult Index()
      {
         return View();
      }
   }
}