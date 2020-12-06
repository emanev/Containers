namespace Containers.Data.Models
{
    using System;
    using System.Collections.Generic;
    public partial class ContainerCapacity
    {
        public ContainerCapacity()
        {
            Containers = new HashSet<Containers>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Containers> Containers { get; set; }
    }
}
