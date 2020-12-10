namespace Containers.Data.Models
{
    using System.Collections.Generic;

    using Containers.Data.Common.Models;

    public class Warehouse : BaseDeletableModel<int>
    {
        public Warehouse()
        {
            this.MovementWarehouseFrom = new HashSet<Movement>();
            this.MovementWarehouseTo = new HashSet<Movement>();
        }

        public string Name { get; set; }

        public string Address { get; set; }

        public string ContactPerson { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int CityId { get; set; }

        public int DistrictId { get; set; }

        public virtual City City { get; set; }

        public virtual District District { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<Movement> MovementWarehouseFrom { get; set; }

        public virtual ICollection<Movement> MovementWarehouseTo { get; set; }
    }
}
