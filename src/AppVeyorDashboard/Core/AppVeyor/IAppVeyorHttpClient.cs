namespace AppVeyorDashboard.Core.AppVeyor
{
   using System.Net.Http;
   using System.Threading.Tasks;

   public interface IAppVeyorHttpClient
   {
      Task<HttpResponseMessage> GetAsync(string path);
   }
}