namespace Containers.Web.ViewModels.SRSObjects.Industrial
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class SRSObjectIndustrialSchemeInputModel
    {
        public int SrsobjectIndustrialId { get; set; }

        public DateTime? EntryDate { get; set; }

        public Weekday WeekDay { get; set; }

        [Required]
        public TimeSpan Hour { get; set; }
    }
}
