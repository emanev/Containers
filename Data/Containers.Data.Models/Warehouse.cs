namespace Containers.Data.Models
{
    using System.Collections.Generic;

    using Containers.Data.Common.Models;

    public class Warehouse : BaseDeletableModel<int>
    {
        public Warehouse()
        {
            this.MovementWarehouse = new HashSet<Movement>();
        }

        public string Name { get; set; }

        public string Address { get; set; }

        public string ContactPerson { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int? DistrictId { get; set; }

        public virtual District District { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<Movement> MovementWarehouse { get; set; }
    }
}
