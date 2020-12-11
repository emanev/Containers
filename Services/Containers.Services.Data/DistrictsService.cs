namespace Containers.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using Containers.Data.Common.Repositories;
    using Containers.Data.Models;

    public class DistrictsService : IDistrictsService
    {
        private readonly IRepository<District> districtsRepository;

        public DistrictsService(IRepository<District> districtsRepository)
        {
            this.districtsRepository = districtsRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.districtsRepository.AllAsNoTracking()
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
