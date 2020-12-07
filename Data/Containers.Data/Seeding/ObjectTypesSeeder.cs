namespace Containers.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Containers.Data.Models;

    public class ObjectTypesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ObjectTypes.Any())
            {
                return;
            }

            await dbContext.ObjectTypes.AddAsync(new ObjectType { Name = "Индустрия" });
            await dbContext.ObjectTypes.AddAsync(new ObjectType { Name = "Население" });

            await dbContext.SaveChangesAsync();
        }
    }
}
