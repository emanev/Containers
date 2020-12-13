namespace Containers.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Containers.Web.ViewModels.Schedules;

    public interface IScheduleService
    {
        IEnumerable<ScheduleViewModel> GetAll();

        ScheduleViewModel GetById(int id);

        Task CreateAsync(ScheduleInputModel input, string userId);
    }
}
