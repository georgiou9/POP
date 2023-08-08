using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace PollyProject.Utilities
{
    public static class EnvironmentManager
    {
        public static string BaseUrl { get; private set; }
        //public static string CoinDeskUrl { get; private set; }

        public static void LoadConfigFile()
        {
            // Set desired env in test.runsettings file
            var env = TestContext.Parameters.Get("Env");

            if (env == null) Assert.Fail("Env parameter doesn't have value. Please check Env parameter in test.runsettings");
            Logger.Info($"Settings environment variables to {env}");

            var configuration = new ConfigurationBuilder()
                .AddJsonFile($"Configs/Env{env.ToUpper()}.json")
                .Build();

            SetEnvironmetVariables( configuration );
        }

        private static void SetEnvironmetVariables(IConfigurationRoot configuration)
        {
            BaseUrl = configuration["CoinDeskServices:BaseUrl"];
        }
    }
}
