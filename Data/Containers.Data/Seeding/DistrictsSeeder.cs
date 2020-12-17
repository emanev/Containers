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

            await dbContext.Districts.AddAsync(new District { Name = "Sofia" });
            await dbContext.Districts.AddAsync(new District { Name = "Plovdiv" });
            await dbContext.Districts.AddAsync(new District { Name = "Varna" });
            await dbContext.Districts.AddAsync(new District { Name = "Burgas" });
            await dbContext.Districts.AddAsync(new District { Name = "Stara Zagora" });
            await dbContext.Districts.AddAsync(new District { Name = "Ruse" });
            await dbContext.Districts.AddAsync(new District { Name = "Sliven" });
            await dbContext.Districts.AddAsync(new District { Name = "Pleven" });
            await dbContext.Districts.AddAsync(new District { Name = "Dobrich" });
            await dbContext.Districts.AddAsync(new District { Name = "Veliko Tyrnovo" });

            await dbContext.SaveChangesAsync();
        }
    }
}
