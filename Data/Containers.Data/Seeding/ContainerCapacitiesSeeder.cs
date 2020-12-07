namespace Containers.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Containers.Data.Models;

    public class ContainerCapacitiesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ContainerCapacities.Any())
            {
                return;
            }

            await dbContext.ContainerCapacities.AddAsync(new ContainerCapacity { Name = "1700 литра" });
            await dbContext.ContainerCapacities.AddAsync(new ContainerCapacity { Name = "3300 литра" });

            await dbContext.SaveChangesAsync();
        }
    }
}
