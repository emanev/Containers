namespace Containers.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Containers.Data.Common.Models;

    public class SrsobjectIndustrial : BaseDeletableModel<int>
    {
        public SrsobjectIndustrial()
        {
            this.Schedule = new HashSet<Schedule>();
            this.SrsobjectIndustrialContainer = new HashSet<SrsobjectIndustrialContainer>();
            this.SrsobjectIndustrialSchema = new HashSet<SrsobjectIndustrialSchema>();
        }

        public string Name { get; set; }

        public string Address { get; set; }

        public string ContactPerson { get; set; }

        public string Note { get; set; }

        public DateTime? EntryDate { get; set; }

        public int DistrictId { get; set; }

        public virtual District District { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<Schedule> Schedule { get; set; }

        public virtual ICollection<SrsobjectIndustrialContainer> SrsobjectIndustrialContainer { get; set; }

        public virtual ICollection<SrsobjectIndustrialSchema> SrsobjectIndustrialSchema { get; set; }
    }
}
