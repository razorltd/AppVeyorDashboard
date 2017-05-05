namespace AppVeyorDashboard.Models.ViewBuild
{
   using System;

   public class ViewBuildModel
   {
      public ViewBuildModel(string projectName, string projectSlug, string branch, string version, string status,
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
      public TimeSpan? BuildTime
      {
         get
         {
            if (StartedAt == DateTime.MinValue)
            {
               return null;
            }

            return (FinishedAt == DateTime.MinValue ? DateTime.Now : FinishedAt) - StartedAt;
         }
      }
      public string CommitterAvatarUrl { get; }
      public string CommitterName { get; }
      public int? CompilationErrorsCount { get; }
      public int? FailedTestsCount { get; }
      public DateTime FinishedAt { get; }
      public bool HasTimedOut => BuildTime != null && BuildTime >= Timeout;
      public int? PassedTestsCount { get; }
      public string ProjectName { get; }
      public string ProjectSlug { get; }
      public string Status { get; }
      public DateTime StartedAt { get; }
      public TimeSpan Timeout { get; }
      public int? TotalTestsCount => PassedTestsCount + FailedTestsCount;
      public string Version { get; }
   }
}