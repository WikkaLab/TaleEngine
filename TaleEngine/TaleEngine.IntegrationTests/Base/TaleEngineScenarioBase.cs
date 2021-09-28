using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace TaleEngine.IntegrationTests.Base
{
    [ExcludeFromCodeCoverage]
    public class TaleEngineScenarioBase
    {
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
    }
}