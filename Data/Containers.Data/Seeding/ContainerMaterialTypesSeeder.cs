namespace Containers.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Containers.Data.Models;

    public class ContainerMaterialTypesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.ContainerMaterialTypes.Any())
            {
                return;
            }

            await dbContext.ContainerMaterialTypes.AddAsync(new ContainerMaterialType { Name = "стъкло" });
            await dbContext.ContainerMaterialTypes.AddAsync(new ContainerMaterialType { Name = "пластмаса" });
            await dbContext.ContainerMaterialTypes.AddAsync(new ContainerMaterialType { Name = "хартия" });

            await dbContext.SaveChangesAsync();
        }
    }
}
