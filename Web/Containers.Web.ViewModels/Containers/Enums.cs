namespace Containers.Web.ViewModels.Containers
{
    using System.ComponentModel.DataAnnotations;

    public class Enums
    {
        public enum ContainerColour
        {
            Green = 1,
            Yello = 2,
            Blue = 3,
        }

        public enum ContainerCapacity
        {
            [Display(Name = "1700 liters")]
            _1700Liters = 1,
            [Display(Name = "3300 liters")]
            _3300Liters = 2,
        }
    }
}
