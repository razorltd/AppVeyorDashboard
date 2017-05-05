namespace AppVeyorDashboard.Core.AppVeyor.Builds
{
   using System.Threading.Tasks;

   public interface IAppVeyorBuilds
   {
      Task<ViewBuildProjection> View(ViewBuildQuery query);
   }
}