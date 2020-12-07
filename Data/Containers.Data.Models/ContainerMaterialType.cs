﻿namespace Containers.Data.Models
{
    using System.Collections.Generic;

    public partial class ContainerMaterialType
    {
        public ContainerMaterialType()
        {
            this.Containers = new HashSet<Container>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Container> Containers { get; set; }
    }
}
