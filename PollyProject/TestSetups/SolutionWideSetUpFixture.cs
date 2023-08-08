using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using NUnit.Framework;
using PollyProject.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger = PollyProject.Utilities.Logger;

namespace PollyProject.TestSetups
{
    [SetUpFixture]
    public class SolutionWideSetUpFixture
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Logger.Info("Starting API service tests");
            EnvironmentManager.LoadConfigFile();

        }

        [OneTimeTearDown]
        public void OneTimeTearDown() 
        {
            Logger.Info("Tests run completed");
        }
    }
}
