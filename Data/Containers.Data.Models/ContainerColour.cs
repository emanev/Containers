namespace Containers.Data.Models
{
    using System.Collections.Generic;

    using Containers.Data.Common.Models;

    public class ContainerColour
    {
        public ContainerColour()
        {
            this.Containers = new HashSet<Container>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Container> Containers { get; set; }
    }
}
