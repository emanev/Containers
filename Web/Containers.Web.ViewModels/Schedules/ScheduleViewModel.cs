namespace Containers.Web.ViewModels.Schedules
{
    using System;

    public class ScheduleViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int ObjectTypeId { get; set; }

        public ObjectType ObjectType { get; set; }

        public DateTime RaiseDate { get; set; }

        public string SrsobjectName { get; set; }

        public string DistrictName { get; set; }

        public TimeSpan RaiseTimeFrom { get; set; }

        public TimeSpan RaiseTimeTo { get; set; }
    }
}
