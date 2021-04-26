using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Data;

namespace TaleEngine.IntegrationTests
{
    [ExcludeFromCodeCoverage]
    public class TaleEngineContextInMemoryDatabase
    {
        protected TaleEngineContext _dbContext;

        public TaleEngineContextInMemoryDatabase()
        {
            var options = CreateNewContextOptions();

            _dbContext = new TaleEngineContext(options);
        }

        protected static DbContextOptions<TaleEngineContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<TaleEngineContext>();
            builder.UseInMemoryDatabase("TaleEngine")
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }
    }
}