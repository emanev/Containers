namespace Containers.Web.ViewModels.Containers
{
    using System.ComponentModel.DataAnnotations;

    using global::Containers.Data.Models;

    public class ContainersViewModel
    {
        public int Id { get; set; }

        public string InventarNumber { get; set; }

        public int ContainerColourId { get; set; }

        public int ContainerCapacityId { get; set; }

        public Enums.ContainerColour ContainerColour { get; set; }

        public Enums.ContainerCapacity ContainerCapacity { get; set; }

        public string ContainerCapacityDisplayName { get; set; }
    }
}
