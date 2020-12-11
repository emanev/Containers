namespace Containers.Web.ViewModels.Containers
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using global::Containers.Data.Models;

    public class ContainersInputModel
    {
        [Required]
        [MaxLength(50)]
        public string InventarNumber { get; set; }

        [EnumDataType(typeof(Enums.ContainerColour))]
        //[Display(Name = "Colour Type:")]
        public Enums.ContainerColour ContainerColour { get; set; }

        [EnumDataType(typeof(Enums.ContainerCapacity))]
        //[Display(Name = "Capacity Type:")]
        public Enums.ContainerCapacity ContainerCapacity { get; set; }

        public IEnumerable<KeyValuePair<string, string>> WarehouseItems { get; set; }

        public int WarehouseToId { get; set; }
    }
}
