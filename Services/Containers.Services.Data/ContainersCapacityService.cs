namespace Containers.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using Containers.Data.Common.Repositories;
    using Containers.Data.Models;

    public class ContainersCapacityService : IContainersCapacityService
    {
        private readonly IRepository<ContainerCapacity> containersCapacityRepository;

        public ContainersCapacityService(IRepository<ContainerCapacity> containersCapacityRepository)
        {
            this.containersCapacityRepository = containersCapacityRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.containersCapacityRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .OrderBy(x => x.Name)
                .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
