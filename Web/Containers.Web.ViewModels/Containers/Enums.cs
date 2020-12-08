namespace Containers.Web.ViewModels.Containers
{
    using System.ComponentModel.DataAnnotations;

    public class Enums
    {
        public enum ContainerColour
        {
            Зелен = 1,
            Жълт = 2,
            Син = 3,
        }

        public enum ContainerCapacity
        {
            [Display(Name = "1700 литра")]
            _1700Литра = 1,
            [Display(Name = "3300 литра")]
            _3300Литра = 2,
        }
    }
}
