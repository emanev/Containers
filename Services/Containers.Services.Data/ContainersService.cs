namespace Containers.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Containers.Data.Common.Repositories;
    using Containers.Data.Models;
    using Containers.Web.ViewModels.Containers;

    public class ContainersService : IContainersService
    {
        private readonly IDeletableEntityRepository<Container> containersRepository;
        private readonly IRepository<Movement> movementsRepository;

        public ContainersService(
            IDeletableEntityRepository<Container> containersRepository,
            IRepository<Movement> movementsRepository)
        {
            this.containersRepository = containersRepository;
            this.movementsRepository = movementsRepository;
        }

        public async Task CreateAsync(ContainersInputModel input, string userId)
        {
            try
            {
                var container = new Container
                {
                    ContainerCapacityId = (int)input.ContainerCapacity,
                    ContainerColourId = (int)input.ContainerColour,
                    InventarNumber = input.InventarNumber,
                };

                await this.containersRepository.AddAsync(container);
                await this.containersRepository.SaveChangesAsync();

                int containerId = container.Id;

                var movement = new Movement
                {
                    ContainerId = containerId,
                    WarehouseFromId = null,
                    WarehouseToId = input.WarehouseToId,
                    IsLastMovement = true,
                    AddedByUserId = userId,
                    EntryDate = null,
                };

                await this.movementsRepository.AddAsync(movement);
                await this.movementsRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task UpdateAsync(int id, ContainersInputModel input)
        {
            var container = this.containersRepository.All().FirstOrDefault(x => x.Id == id);
            container.InventarNumber = input.InventarNumber;
            container.ContainerColourId = (int)input.ContainerColour;
            container.ContainerCapacityId = (int)input.ContainerCapacity;
            await this.containersRepository.SaveChangesAsync();
        }

        public IEnumerable<ContainersViewModel> GetAll()
        {
            var containers = this.containersRepository.AllAsNoTracking()
                .Select(x => new ContainersViewModel
            {
                Id = x.Id,
                InventarNumber = x.InventarNumber,
                ContainerColourId = x.ContainerColourId,
                ContainerColour = (Enums.ContainerColour)x.ContainerColourId,
                ContainerCapacityId = x.ContainerCapacityId,
                ContainerCapacity = (Enums.ContainerCapacity)x.ContainerCapacityId,
            }).ToList();

            return containers;
        }

        public ContainersViewModel GetById(int id)
        {
            var container = this.containersRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                 .Select(x => new ContainersViewModel
                 {
                     Id = x.Id,
                     InventarNumber = x.InventarNumber,
                     ContainerColourId = x.ContainerColourId,
                     ContainerColour = (Enums.ContainerColour)x.ContainerColourId,
                     ContainerCapacityId = x.ContainerCapacityId,
                     ContainerCapacity = (Enums.ContainerCapacity)x.ContainerCapacityId,
                 })
                .FirstOrDefault();

            return container;
        }

        public async Task DeleteAsync(int id)
        {
            var movements = this.movementsRepository.All().Where(x => x.ContainerId == id);
            foreach (var movement in movements)
            {
                this.movementsRepository.Delete(movement);
            }

            await this.movementsRepository.SaveChangesAsync();

            var container = this.containersRepository.All().FirstOrDefault(x => x.Id == id);
            this.containersRepository.Delete(container);
            await this.containersRepository.SaveChangesAsync();
        }
    }
}
