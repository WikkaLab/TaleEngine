using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using TaleEngine.API;

namespace TaleEngine.IntegrationTests.Base
{
    [ExcludeFromCodeCoverage]
    public class ActivityScenarioBase
    {
        private const string ApiUrlBase = "api/v3/activity";

        public TestServer CreateServer()
        {
            var hostBuilder = new WebHostBuilder()
                .ConfigureAppConfiguration(cb =>
                {
                    cb.AddJsonFile("appsettings.json", optional: false)
                    .AddEnvironmentVariables();
                })
                .UseEnvironment("IntegrationTest")
                .UseStartup<Startup>();

            return new TestServer(hostBuilder);
        }

        public static class Get
        {
            public static string GetActivities(int editionId)
            {
                return $"{ApiUrlBase}/GetActivities/{editionId}";
            }
        }
    }
}