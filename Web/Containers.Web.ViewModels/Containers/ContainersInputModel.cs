namespace Containers.Web.ViewModels.Containers
{
    using System.ComponentModel.DataAnnotations;

    using global::Containers.Data.Models;

    public class ContainersInputModel
    {
        [Required]
        [MaxLength(50)]
        public string InventarNumber { get; set; }

        [EnumDataType(typeof(ContainerColour))]
        [Display(Name = "Colour Type:")]
        public ContainerColour ContainerColourType { get; set; }

        [EnumDataType(typeof(ContainerCapacity))]
        [Display(Name = "Capacity Type:")]
        public ContainerCapacity ContainerCapacityType { get; set; }
    }
}
