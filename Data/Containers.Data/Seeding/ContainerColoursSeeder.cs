namespace Containers.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Containers.Data.Models;

    public class ContainerColoursSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ContainerColours.Any())
            {
                return;
            }

            await dbContext.ContainerColours.AddAsync(new ContainerColour { Name = "жълт" });
            await dbContext.ContainerColours.AddAsync(new ContainerColour { Name = "зелен" });
            await dbContext.ContainerColours.AddAsync(new ContainerColour { Name = "син" });

            await dbContext.SaveChangesAsync();
        }
    }
}
