namespace Containers.Data.Models
{
    using System.Collections.Generic;

    public partial class City
    {
        public City()
        {
            this.Schedule = new HashSet<Schedule>();
            this.Warehouse = new HashSet<Warehouse>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int DistrictId { get; set; }

        public virtual ICollection<Schedule> Schedule { get; set; }

        public virtual ICollection<Warehouse> Warehouse { get; set; }
    }
}
