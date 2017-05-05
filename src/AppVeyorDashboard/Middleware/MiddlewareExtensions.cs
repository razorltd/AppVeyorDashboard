namespace AppVeyorDashboard.Middleware
{
   using IpAddressFilter;
   using Microsoft.AspNetCore.Builder;

   public static class MiddlewareExtensions
   {
      public static void UseIpAddressFilter(this IApplicationBuilder builder)
      {
         builder.UseMiddleware<IpAddressFilterMiddleware>();
      }
   }
}
