namespace Containers.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using Containers.Data.Common.Repositories;
    using Containers.Data.Models;

    public class ContainersColourService : IContainersColourService
    {
        private readonly IRepository<ContainerColour> containersColourRepository;

        public ContainersColourService(IRepository<ContainerColour> containersColourRepository)
        {
            this.containersColourRepository = containersColourRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.containersColourRepository.AllAsNoTracking()
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
