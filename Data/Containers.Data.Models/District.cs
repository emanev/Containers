namespace Containers.Data.Models
{
    using System;
    using System.Collections.Generic;
    public partial class District
    {
        public District()
        {
            Schedule = new HashSet<Schedule>();
            SrsobjectIndustrial = new HashSet<SrsobjectIndustrial>();
            Warehouse = new HashSet<Warehouse>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Schedule> Schedule { get; set; }
        public virtual ICollection<SrsobjectIndustrial> SrsobjectIndustrial { get; set; }
        public virtual ICollection<Warehouse> Warehouse { get; set; }
    }
}
