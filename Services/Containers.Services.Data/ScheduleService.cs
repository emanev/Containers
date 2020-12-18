namespace Containers.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Containers.Data.Common.Repositories;
    using Containers.Data.Models;
    using Containers.Web.ViewModels.Schedules;

    using ObjectType = Web.ViewModels.Schedules.ObjectType;

    public class ScheduleService : IScheduleService
    {
        private readonly IRepository<Schedule> schedulesRepository;

        public ScheduleService(IRepository<Schedule> schedulesRepository)
        {
            this.schedulesRepository = schedulesRepository;
        }

        public IEnumerable<ScheduleViewModel> GetAll()
        {
            var schedules = this.schedulesRepository.AllAsNoTracking()
                .Select(x => new ScheduleViewModel
                {
                    Id = x.Id,
                    Description = x.Description,
                    RaiseDate = x.RaiseDate,
                    DistrictName = x.District.Name,
                    RaiseTimeFrom = x.RaiseTimeFrom,
                    RaiseTimeTo = x.RaiseTimeTo,
                    ObjectType = (ObjectType)x.ObjectTypeId,
                }).ToList();

            return schedules;
        }

        public ScheduleViewModel GetById(int id)
        {
            var srsObjectIndustrial = this.schedulesRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                 .Select(x => new ScheduleViewModel
                 {
                     Id = x.Id,
                     Description = x.Description,
                     RaiseDate = x.RaiseDate,
                     RaiseTimeFrom = x.RaiseTimeFrom,
                     RaiseTimeTo = x.RaiseTimeTo,
                     ObjectType = (ObjectType)x.ObjectTypeId,
                 })
                .FirstOrDefault();

            return srsObjectIndustrial;
        }

        public async Task CreateAsync(ScheduleInputModel input, string userId)
        {
            var schedule = new Schedule
            {
                Description = input.Description,
                RaiseDate = input.RaiseDate,
                RaiseTimeFrom = input.RaiseTimeFrom,
                RaiseTimeTo = input.RaiseTimeTo,
                ObjectTypeId = (int)input.ObjectType,
                DistrictId = input.DistrictId,
            };

            await this.schedulesRepository.AddAsync(schedule);
            await this.schedulesRepository.SaveChangesAsync();
        }
    }
}
