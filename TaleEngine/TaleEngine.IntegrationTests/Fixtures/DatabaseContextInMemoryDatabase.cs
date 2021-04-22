using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using TaleEngine.Data;

namespace TaleEngine.IntegrationTests
{
    [ExcludeFromCodeCoverage]
    public class DatabaseContextInMemoryDatabase
    {
        protected DatabaseContext _context;

        public DatabaseContextInMemoryDatabase()
        {
            var options = CreateNewContextOptions();

            _context = new DatabaseContext(options);
        }

        protected static DbContextOptions<DatabaseContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<DatabaseContext>();
            builder.UseInMemoryDatabase("TaleEngine")
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }
    }
}