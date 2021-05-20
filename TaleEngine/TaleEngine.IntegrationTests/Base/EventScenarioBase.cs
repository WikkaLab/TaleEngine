using System.Diagnostics.CodeAnalysis;

namespace TaleEngine.IntegrationTests.Base
{
    [ExcludeFromCodeCoverage]
    public class EventScenarioBase : TaleEngineScenarioBase
    {
        private const string ApiUrlBase = "api/v2/event";

        public static class Get
        {
            public static string GetEvents()
            {
                return $"{ApiUrlBase}/GetEvents";
            }
        }
    }
}