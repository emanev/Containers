namespace Containers.Services.Data
{
    using System.Collections.Generic;

    using Containers.Services.Data.Models;

    public interface IScheduleService
    {
        IEnumerable<ScheduleViewModel> GetAll();
    }
}
