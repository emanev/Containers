namespace Containers.Data.Models
{
    using System.Collections.Generic;

    public partial class District
    {
        public District()
        {
            this.Schedule = new HashSet<Schedule>();
            this.SrsobjectIndustrial = new HashSet<SrsobjectIndustrial>();
            this.Warehouse = new HashSet<Warehouse>();
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
