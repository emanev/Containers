namespace Containers.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Containers.Data.Models;

    public class CitiesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Cities.Any())
            {
                return;
            }

            await dbContext.Cities.AddAsync(new City { Name = "София", DistrictId = 1 });
            await dbContext.Cities.AddAsync(new City { Name = "Пловдив", DistrictId = 2 });
            await dbContext.Cities.AddAsync(new City { Name = "Варна", DistrictId = 3 });
            await dbContext.Cities.AddAsync(new City { Name = "Бургас", DistrictId = 4 });
            await dbContext.Cities.AddAsync(new City { Name = "Поморие", DistrictId = 4 });

            await dbContext.SaveChangesAsync();
        }
    }
}
