namespace Containers.Web.ViewModels.Schedules
{
    using System;

    public class ScheduleViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int ObjectTypeId { get; set; }

        public DateTime RaiseDate { get; set; }

        public int SrsobjectId { get; set; }

        public int CityId { get; set; }

        public int DistrictId { get; set; }

        public TimeSpan RaiseTimeFrom { get; set; }

        public TimeSpan RaiseTimeTo { get; set; }
    }
}
