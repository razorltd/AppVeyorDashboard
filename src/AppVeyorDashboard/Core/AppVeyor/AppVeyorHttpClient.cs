namespace AppVeyorDashboard.Core.AppVeyor
{
   using System.Net.Http;
   using System.Threading.Tasks;
   using Microsoft.Extensions.Options;

   public class AppVeyorHttpClient : IAppVeyorHttpClient
   {
      private readonly AppVeyorApiConfiguration _appVeyorApiConfiguration;
      private readonly HttpClient _httpClient;

      public AppVeyorHttpClient(HttpClient httpClient, IOptions<AppVeyorApiConfiguration> appVeyorApiConfigurationOptions)
      {
         _httpClient = httpClient;
         _appVeyorApiConfiguration = appVeyorApiConfigurationOptions.Value;
      }

      public async Task<HttpResponseMessage> GetAsync(string path)
      {
         var request = new HttpRequestMessage(HttpMethod.Get, BuildUrl(path));

         return await SendAsync(request);
      }

      private string BuildUrl(string path)
      {
         var url = _appVeyorApiConfiguration.Url.Trim();

         if (url.EndsWith("/"))
         {
            url = url.TrimEnd('/');
         }

         return $"{url}/api/{path}";
      }

      private async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
      {
         request.Headers.Add("Accept", "application/json");
         request.Headers.Add("Authorization", $"Bearer {_appVeyorApiConfiguration.Token}");

         var response = await _httpClient.SendAsync(request);
         response.EnsureSuccessStatusCode();

         return response;
      }
   }
}