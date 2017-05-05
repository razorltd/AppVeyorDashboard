namespace AppVeyorDashboard.Core.AppVeyor.Environments
{
   using System.Collections.Generic;

   public class ListEnvironmentsProjection
   {
      public ListEnvironmentsProjection(IReadOnlyCollection<Environment> environments)
      {
         Environments = environments;
      }

      public IReadOnlyCollection<Environment> Environments { get; }
   }
}