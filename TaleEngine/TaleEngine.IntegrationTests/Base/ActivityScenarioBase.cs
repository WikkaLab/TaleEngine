using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;

namespace TaleEngine.IntegrationTests.Base
{
    [ExcludeFromCodeCoverage]
    public class ActivityScenarioBase : TaleEngineScenarioBase
    {
        private const string ApiUrlBase = "api/v2/activity";

        public static class Get
        {
            public static string GetActivities(int editionId)
            {
                return $"{ApiUrlBase}/GetActivities/{editionId}";
            }
        }
    }
}