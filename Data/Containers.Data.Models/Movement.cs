﻿namespace Containers.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Containers.Data.Common.Models;

    public partial class Movement
    {
        public Movement()
        {
            this.SrsobjectIndustrialContainer = new HashSet<SrsobjectIndustrialContainer>();
        }

        public int Id { get; set; }

        public int ContainerId { get; set; }

        public int WarehouseId { get; set; }

        public bool IsLastMovement { get; set; }

        public DateTime? EntryDate { get; set; }

        public virtual Container Container { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<SrsobjectIndustrialContainer> SrsobjectIndustrialContainer { get; set; }
    }
}
