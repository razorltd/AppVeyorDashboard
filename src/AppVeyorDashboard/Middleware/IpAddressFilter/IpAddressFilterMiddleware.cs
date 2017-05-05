namespace AppVeyorDashboard.Middleware.IpAddressFilter
{
   using System.Linq;
   using Microsoft.AspNetCore.Builder;
   using Microsoft.AspNetCore.Http;
   using Microsoft.Extensions.Configuration;
   using Microsoft.Extensions.Options;
   using System.Threading.Tasks;

   public class IpAddressFilterMiddleware
   {
      private readonly IpAddressFilterConfiguration _ipAddressFilterConfiguration;
      private readonly RequestDelegate _next;

      public IpAddressFilterMiddleware(RequestDelegate next, IOptions<IpAddressFilterConfiguration> ipAddressFilterConfiguration)
      {
         _next = next;
         _ipAddressFilterConfiguration = ipAddressFilterConfiguration.Value;
      }

      public async Task Invoke(HttpContext context)
      {
         var allowedIpAddresses = _ipAddressFilterConfiguration.AllowedIpAddresses;

         if (!allowedIpAddresses.Contains(context.Connection.RemoteIpAddress.ToString()))
         {
            context.Response.StatusCode = 403;

            await context.Response.WriteAsync("Unauthorized");

            return;
         }

         await _next(context);
      }
   }
}
