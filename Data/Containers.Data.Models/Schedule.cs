namespace Containers.Data.Models
{
    using System;
    using System.Collections.Generic;
    public partial class Schedule
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

        public virtual City City { get; set; }

        public virtual District District { get; set; }

        public virtual ObjectTypes ObjectType { get; set; }

        public virtual SrsobjectIndustrial Srsobject { get; set; }
    }
}
