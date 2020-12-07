namespace Containers.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Containers.Data.Models;

    public class DistrictsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Districts.Any())
            {
                return;
            }

            await dbContext.Districts.AddAsync(new District { Name = "София" });
            await dbContext.Districts.AddAsync(new District { Name = "Пловдив" });
            await dbContext.Districts.AddAsync(new District { Name = "Варна" });
            await dbContext.Districts.AddAsync(new District { Name = "Бургас" });

            await dbContext.SaveChangesAsync();
        }
    }
}
