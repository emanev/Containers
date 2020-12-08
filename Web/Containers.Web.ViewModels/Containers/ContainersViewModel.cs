namespace Containers.Web.ViewModels.Containers
{
    using System.ComponentModel.DataAnnotations;

    using global::Containers.Data.Models;

    public class ContainersViewModel
    {
        public int Id { get; set; }

        public string InventarNumber { get; set; }

        public ContainerColour ContainerColourType { get; set; }

        public ContainerCapacity ContainerCapacityType { get; set; }
    }
}
