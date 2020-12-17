namespace Containers.Data.Models
{
    using System;

    using Containers.Data.Common.Models;

    public class Schedule : BaseDeletableModel<int>
    {
        public string Description { get; set; }

        public int ObjectTypeId { get; set; }

        public DateTime RaiseDate { get; set; }

        public int SrsobjectId { get; set; }

        public int DistrictId { get; set; }

        public TimeSpan RaiseTimeFrom { get; set; }

        public TimeSpan RaiseTimeTo { get; set; }

        public virtual District District { get; set; }

        public virtual ObjectType ObjectType { get; set; }

        public virtual SrsobjectIndustrial Srsobject { get; set; }
    }
}
