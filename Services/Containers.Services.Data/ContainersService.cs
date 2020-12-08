﻿namespace Containers.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Containers.Data.Common.Repositories;
    using Containers.Data.Models;
    using Containers.Web.ViewModels.Containers;

    public class ContainersService : IContainersService
    {
        private readonly IDeletableEntityRepository<Container> containersRepository;

        public ContainersService(IDeletableEntityRepository<Container> containersRepository)
        {
            this.containersRepository = containersRepository;
        }

        public async Task CreateAsync(ContainersInputModel input)
        {
            var container = new Container
            {
                ContainerCapacityId = input.CapacityId,
                ContainerColourId = input.ColourId,
                InventarNumber = input.InventarNumber,
            };

            await this.containersRepository.AddAsync(container);
            await this.containersRepository.SaveChangesAsync();
        }

        public IEnumerable<ContainersViewModel> GetAll()
        {
            var containers = this.containersRepository.AllAsNoTracking()
                .Select(x => new ContainersViewModel
            {
                InventarNumber = x.InventarNumber,
                ContainerCapacityType = x.ContainerCapacity,
                ContainerColourType = x.ContainerColour,
            }).ToList();

            return containers;
        }
    }
}
