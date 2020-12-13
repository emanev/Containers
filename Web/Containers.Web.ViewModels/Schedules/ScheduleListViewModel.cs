namespace Containers.Web.ViewModels.Schedules
{
    using System.Collections.Generic;

    public class ScheduleListViewModel// : PagingViewModel
    {
        public IEnumerable<ScheduleViewModel> Schedules { get; set; }
    }
}
