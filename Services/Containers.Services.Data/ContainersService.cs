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
        private readonly IDeletableEntityRepository<SrsobjectIndustrialContainer> srsObjectIndurstiralContainerRepository;

        public ContainersService(
            IDeletableEntityRepository<Container> containersRepository,
            IRepository<Movement> movementsRepository,
            IDeletableEntityRepository<SrsobjectIndustrialContainer> srsObjectIndurstiralContainerRepository)
        {
            this.containersRepository = containersRepository;
            this.movementsRepository = movementsRepository;
            this.srsObjectIndurstiralContainerRepository = srsObjectIndurstiralContainerRepository;
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
                    WarehouseId = input.WarehouseToId,
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

        public bool IsUniqueContainer(ContainersInputModel input)
        {
            var result = this.containersRepository.AllAsNoTracking()
                                .Where(x => x.InventarNumber == input.InventarNumber)
                                .FirstOrDefault();

            if (result != null)
            {
                return false;
            }

            return true;
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
            var industrialContainersIds = this.srsObjectIndurstiralContainerRepository.AllAsNoTracking()
                .Select(x => x.ContainerId).ToList();

            var containers = this.containersRepository.AllAsNoTracking()
                .Where(x => !industrialContainersIds.Contains(x.Id))
                .Select(x => new ContainersViewModel
            {
                Id = x.Id,
                InventarNumber = x.InventarNumber,
                ContainerColourId = x.ContainerColourId,
                ContainerColour = (Enums.ContainerColour)x.ContainerColourId,
                ContainerCapacityId = x.ContainerCapacityId,
                ContainerCapacity = (Enums.ContainerCapacity)x.ContainerCapacityId,
                ContainerCapacityDisplayName = ((Enums.ContainerCapacity)x.ContainerCapacityId).GetDisplayName(),
            }).ToList();

            return containers;
        }

        public IEnumerable<ContainersViewModel> GetAll(int page, int itemsPerPage = 12)
        {
            var containers = this.containersRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .Select(x => new ContainersViewModel
                {
                    Id = x.Id,
                    InventarNumber = x.InventarNumber,
                    ContainerColourId = x.ContainerColourId,
                    ContainerColour = (Enums.ContainerColour)x.ContainerColourId,
                    ContainerCapacityId = x.ContainerCapacityId,
                    ContainerCapacity = (Enums.ContainerCapacity)x.ContainerCapacityId,
                    ContainerCapacityDisplayName = ((Enums.ContainerCapacity)x.ContainerCapacityId).GetDisplayName(),
                }).ToList();

            return containers;
        }

        public int GetCount()
        {
            return this.containersRepository.All().Count();
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

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            var industrialContainersIds = this.srsObjectIndurstiralContainerRepository.AllAsNoTracking()
                .Select(x => x.ContainerId).ToList();

            var result = this.containersRepository.AllAsNoTracking()
                .Where(x => !industrialContainersIds.Contains(x.Id))
                .Select(x => new
                {
                    x.Id,
                    x.InventarNumber,
                })
                .OrderBy(x => x.InventarNumber)
                .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.InventarNumber));

            return result;
        }
    }
}
