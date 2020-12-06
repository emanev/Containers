namespace Containers.Data.Models
{ 
    using System;
    using System.Collections.Generic;

    public partial class City
    {
        public City()
        {
            District = new HashSet<District>();
            Schedule = new HashSet<Schedule>();
            Warehouse = new HashSet<Warehouse>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<District> District { get; set; }
        public virtual ICollection<Schedule> Schedule { get; set; }
        public virtual ICollection<Warehouse> Warehouse { get; set; }
    }
}
