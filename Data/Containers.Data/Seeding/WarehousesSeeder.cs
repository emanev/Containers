namespace Containers.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Containers.Common;
    using Containers.Data.Models;

    public class WarehousesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Warehouses.Any())
            {
                return;
            }

            await dbContext.Warehouses.AddAsync(
                new Warehouse { Name = GlobalConstants.SRSObjectIndustrialName, DistrictId = 1, CityId = 4, IsDeleted = false });

            await dbContext.SaveChangesAsync();
        }
    }
}
