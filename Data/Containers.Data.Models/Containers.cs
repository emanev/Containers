namespace Containers.Data.Models
{
    using System;
    using System.Collections.Generic;
    public partial class Containers
    {
        public Containers()
        {
            Movement = new HashSet<Movement>();
            SrsobjectIndustrialContainer = new HashSet<SrsobjectIndustrialContainer>();
        }

        public int Id { get; set; }
        public string InventarNumber { get; set; }
        public int ContainerColourId { get; set; }
        public int ContainerMaterialTypeId { get; set; }
        public int ContainerCapacityId { get; set; }

        public virtual ContainerCapacity ContainerCapacity { get; set; }
        public virtual ContainerColour ContainerColour { get; set; }
        public virtual ContainerMaterialType ContainerMaterialType { get; set; }
        public virtual ICollection<Movement> Movement { get; set; }
        public virtual ICollection<SrsobjectIndustrialContainer> SrsobjectIndustrialContainer { get; set; }
    }
}
