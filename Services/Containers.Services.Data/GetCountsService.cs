namespace Containers.Services.Data
{
    using System.Linq;

    using Containers.Data.Common.Repositories;
    using Containers.Data.Models;
    using Containers.Services.Data.Models;

    public class GetCountsService : IGetCountsService
    {
        private readonly IDeletableEntityRepository<Container> containersRepository;
        private readonly IDeletableEntityRepository<SrsobjectIndustrial> srsObjectIndustrialRepository;
        private readonly IDeletableEntityRepository<Warehouse> warehouseRepository;
        private readonly IDeletableEntityRepository<Schedule> scheduleRepository;

        public GetCountsService(
            IDeletableEntityRepository<Container> containersRepository,
            IDeletableEntityRepository<SrsobjectIndustrial> srsObjectIndustrialRepository,
            IDeletableEntityRepository<Warehouse> warehouseRepository,
            IDeletableEntityRepository<Schedule> scheduleRepository)
        {
            this.containersRepository = containersRepository;
            this.srsObjectIndustrialRepository = srsObjectIndustrialRepository;
            this.warehouseRepository = warehouseRepository;
            this.scheduleRepository = scheduleRepository;
        }

        public CountsDto GetCounts()
        {
            var data = new CountsDto
            {
                ContainersCount = this.containersRepository.All().Count(),
                SRSObjectIndustrialCount = this.srsObjectIndustrialRepository.All().Count(),
                WarehouseCount = this.warehouseRepository.All().Count(),
                ScheduleCount = this.scheduleRepository.All().Count(),
            };

            return data;
        }
    }
}
