namespace Containers.Data.Models
{
    using System;
    using System.Collections.Generic;
    public partial class SrsobjectIndustrialSchema
    {
        public int Id { get; set; }
        public int SrsobjectIndustrialId { get; set; }
        public DateTime? EntryDate { get; set; }
        public byte WeekDay { get; set; }
        public byte[] Hour { get; set; }
        
        public virtual SrsobjectIndustrial SrsobjectIndustrial { get; set; }
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

    }
}
