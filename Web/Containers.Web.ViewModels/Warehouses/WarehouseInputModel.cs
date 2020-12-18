namespace Containers.Web.ViewModels.Warehouses
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class WarehouseInputModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string ContactPerson { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        [MaxLength(50)]
        public string Phone { get; set; }

        public int DistrictId { get; set; }

        public string DistrictName { get; set; }

        public IEnumerable<KeyValuePair<string, string>> DistrictItems { get; set; }
    }
}
