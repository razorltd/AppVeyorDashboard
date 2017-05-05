namespace AppVeyorDashboard.Core.AppVeyor.Environments
{
   using System.Threading.Tasks;

   public interface IAppVeyorEnvironments
   {
      Task<ListEnvironmentsProjection> List();
   }
}