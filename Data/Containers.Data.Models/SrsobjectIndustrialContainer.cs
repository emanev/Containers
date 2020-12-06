namespace Containers.Data.Models
{
    using System;
    using System.Collections.Generic;

    public partial class SrsobjectIndustrialContainer
    {
        public int Id { get; set; }

        public int SrsobjectIndustrialId { get; set; }

        public int ContainerId { get; set; }

        public int MovementId { get; set; }

        public string AddedByUserId { get; set; }

        public virtual Containers Container { get; set; }

        public virtual Movement Movement { get; set; }

        public virtual SrsobjectIndustrial SrsobjectIndustrial { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }
    }
}
