namespace Containers.Services.Data
{
    using System.Collections.Generic;

    using Containers.Web.ViewModels.Schedules;

    public interface IScheduleService
    {
        IEnumerable<ScheduleViewModel> GetAll();
    }
}
