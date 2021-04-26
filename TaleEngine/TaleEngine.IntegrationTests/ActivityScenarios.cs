using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using TaleEngine.IntegrationTests.Base;
using Xunit;

namespace TaleEngine.IntegrationTests
{
    [ExcludeFromCodeCoverage]
    public class ActivityScenarios : ActivityScenarioBase
    {
        [Fact]
        public async Task Get_activities_and_response_ok_status_code()
        {
            using (var server = CreateServer())
            {
                var response = await server.CreateClient()
                   .GetAsync(Get.GetActivities(1));

                response.EnsureSuccessStatusCode();
            }
        }
    }
}