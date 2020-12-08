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

        public int ColourId { get; set; }

        public int CapacityId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> ContainersColourItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> ContainersCapacityItems { get; set; }

        //[EnumDataType(typeof(ContainerColour))]
        //[Display(Name = "Colour Type:")]
        //public ContainerColour ContainerColourType { get; set; }

        //[EnumDataType(typeof(ContainerCapacity))]
        //[Display(Name = "Capacity Type:")]
        //public ContainerCapacity ContainerCapacityType { get; set; }
    }
}
