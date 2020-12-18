namespace Containers.Web.ViewModels.Schedules
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ScheduleViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int ObjectTypeId { get; set; }

        public ObjectType ObjectType { get; set; }

        [Required]
        public DateTime RaiseDate { get; set; }

        public string SrsobjectName { get; set; }

        public string DistrictName { get; set; }

        [Required]
        public TimeSpan RaiseTimeFrom { get; set; }

        [Required]
        public TimeSpan RaiseTimeTo { get; set; }
    }
}
