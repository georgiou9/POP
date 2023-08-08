using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using NUnit.Framework;
using Logger = PollyProject.Utilities.Logger;

namespace PollyProject.TestSetups
{
    public class BaseTest : SolutionWideSetUpFixture
    {
        [SetUp]
        public async Task BeforeEachtest()
        {
            Logger.Info($"Running test: {TestContext.CurrentContext.Test.Name}");
        }

        [TearDown]
        public void AfterEachtest()
        {
            Logger.Info($"Completing test: {TestContext.CurrentContext.Test.Name} " +
                $"Result: {TestContext.CurrentContext.Result.Outcome} ");
        }
    }
}
