namespace Containers.Web.ViewModels.Warehouses
{
    using System.ComponentModel.DataAnnotations;

    public class WarehouseInputModel
    {
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

        public int CityId { get; set; }

        public int DistrictId { get; set; }
    }
}
