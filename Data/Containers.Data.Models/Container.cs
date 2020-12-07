namespace Containers.Data.Models
{
    using System.Collections.Generic;

    public partial class Container
    {
        public Container()
        {
            this.Movement = new HashSet<Movement>();
            this.SrsobjectIndustrialContainer = new HashSet<SrsobjectIndustrialContainer>();
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
