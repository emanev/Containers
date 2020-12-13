namespace Containers.Web.ViewModels.SRSObjects.Industrial
{
    using System;

    public class SRSObjectIndustrialSchemeViewModel
    {
        public int SrsobjectIndustrialId { get; set; }

        public DateTime? EntryDate { get; set; }

        public Weekday WeekDay { get; set; }

        public TimeSpan Hour { get; set; }

        public string UserId { get; set; }
    }
}
