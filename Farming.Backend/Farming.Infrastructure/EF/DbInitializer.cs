using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Farming.Infrastructure.EF
{
    internal static class DbInitializer
    {
        public static void CreateAndSeedDatabase(ReadDbContext context)
        {
            if (!(context.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
            {
                context.Database.Migrate();
            }
        }
    }
}
