namespace Containers.Web.ViewModels.Schedules
{
    using System;
    using System.Collections.Generic;

    public class ScheduleInputModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public ObjectType ObjectType { get; set; }

        public DateTime RaiseDate { get; set; }

        public int SrsobjectId { get; set; }

        public int CityId { get; set; }

        public int DistrictId { get; set; }

        public TimeSpan RaiseTimeFrom { get; set; }

        public TimeSpan RaiseTimeTo { get; set; }

        public IEnumerable<KeyValuePair<string, string>> DistrictItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> SrsObjectIndustrialItems { get; set; }
    }
}
