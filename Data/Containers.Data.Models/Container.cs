namespace Containers.Data.Models
{
    using System.Collections.Generic;

    using Containers.Data.Common.Models;

    public class Container : BaseDeletableModel<int>
    {
        public Container()
        {
            this.Movement = new HashSet<Movement>();
            this.SrsobjectIndustrialContainer = new HashSet<SrsobjectIndustrialContainer>();
        }

        public string InventarNumber { get; set; }

        public int ContainerColourId { get; set; }

        public int ContainerCapacityId { get; set; }

        public virtual ICollection<Movement> Movement { get; set; }

        public virtual ICollection<SrsobjectIndustrialContainer> SrsobjectIndustrialContainer { get; set; }
    }
}
