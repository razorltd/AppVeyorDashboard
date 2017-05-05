namespace AppVeyorDashboard.Core.AppVeyor.Builds
{
   using System;

   public class ViewBuildProjection
   {
      public ViewBuildProjection(string projectName, string projectSlug, string branch, string version, string status,
         string committerName, DateTime startedAt, DateTime finishedAt, TimeSpan timeout, int? compilationErrorsCount,
         int? passedTestsCount, int? failedTestsCount)
      {
         ProjectName = projectName;
         ProjectSlug = projectSlug;
         Branch = branch;
         Version = version;
         Status = status;
         CommitterName = committerName;
         StartedAt = startedAt;
         FinishedAt = finishedAt;
         Timeout = timeout;
         CompilationErrorsCount = compilationErrorsCount;
         PassedTestsCount = passedTestsCount;
         FailedTestsCount = failedTestsCount;
      }

      public string Branch { get; }
      public string CommitterName { get; }
      public int? CompilationErrorsCount { get; }
      public int? FailedTestsCount { get; }
      public DateTime FinishedAt { get; }
      public int? PassedTestsCount { get; }
      public string ProjectName { get; }
      public string ProjectSlug { get; }
      public string Status { get; }
      public DateTime StartedAt { get; }
      public TimeSpan Timeout { get; }
      public string Version { get; }
   }
}