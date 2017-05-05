namespace AppVeyorDashboard.Models.ListDeployments
{
   using System.Collections.Generic;

   public class ListDeploymentsModel
   {
      public ListDeploymentsModel(IReadOnlyCollection<Deployment> deployments)
      {
         Deployments = deployments;
      }

      public IReadOnlyCollection<Deployment> Deployments { get; }
   }
}