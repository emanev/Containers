namespace Containers.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Containers.Data.Common.Repositories;
    using Containers.Data.Models;
    using Containers.Web.ViewModels.SRSObjects.Industrial;

    public class SRSObjectIndustrialContainerService : ISRSObjectIndustrialContainerService
    {
        private readonly IDeletableEntityRepository<SrsobjectIndustrialContainer> srsObjectIndustrialContainerRepository;

        public SRSObjectIndustrialContainerService(IDeletableEntityRepository<SrsobjectIndustrialContainer> srsObjectIndustrialContainerRepository)
        {
            this.srsObjectIndustrialContainerRepository = srsObjectIndustrialContainerRepository;
        }

        public Task CreateAsync(SRSObjectIndustrialContainerInputModel input, string userId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<SRSObjectIndustrialContainerViewModel> GetAll(int id)
        {
            var containers = this.srsObjectIndustrialContainerRepository.AllAsNoTracking()
                .Select(x => new SRSObjectIndustrialContainerViewModel
                {
                    SrsobjectIndustrialId = x.SrsobjectIndustrialId,
                    ContainerId = x.SrsobjectIndustrialId,
                    MovementId = x.SrsobjectIndustrialId,
                    UserId = x.AddedByUserId,
                }).ToList();

            return containers;
        }
    }
}
