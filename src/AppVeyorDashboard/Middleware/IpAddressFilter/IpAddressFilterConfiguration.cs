namespace AppVeyorDashboard.Middleware.IpAddressFilter
{
   using System.Collections.Generic;

   public class IpAddressFilterConfiguration
   {
      public IReadOnlyCollection<string> AllowedIpAddresses { get; set; }
   }
}
