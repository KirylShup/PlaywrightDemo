using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.IO;

namespace PlayWrightDemo.Utils
{
    public static class TestsHelper
    {
        public static bool IsTestFailed()
        {
            bool isFailed = false;
            isFailed |= TestContext.CurrentContext.Result.Outcome == ResultState.Error || TestContext.CurrentContext.Result.Outcome == ResultState.Failure;
            isFailed |= TestContext.CurrentContext.Result.Outcome.Status.ToString().Equals("Failed");
            isFailed |= TestContext.CurrentContext.Result.Outcome.Label.Equals("Error") || TestContext.CurrentContext.Result.Outcome.Label.Equals("Failure");
            return isFailed;
        }

        public static string CreateScreenshotFolder()
        {
            string projectPath = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName).FullName;
            string folderName = Path.Combine(projectPath, "Outcome", "Screenshots");
            Directory.CreateDirectory(folderName);

            string name = RandomStringHelper.GetStringWithCurrentDate();
            string folderForScreenshots = Path.Combine(folderName, name);
            Directory.CreateDirectory(folderForScreenshots);

            return folderForScreenshots + @"\\";
        }
    }
}
