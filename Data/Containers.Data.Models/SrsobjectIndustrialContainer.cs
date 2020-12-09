namespace Containers.Data.Models
{
    using Containers.Data.Common.Models;

    public class SrsobjectIndustrialContainer : BaseDeletableModel<int>
    {
        public int SrsobjectIndustrialId { get; set; }

        public int ContainerId { get; set; }

        public int MovementId { get; set; }

        public string AddedByUserId { get; set; }

        public virtual Container Container { get; set; }

        public virtual Movement Movement { get; set; }

        public virtual SrsobjectIndustrial SrsobjectIndustrial { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }
    }
}
