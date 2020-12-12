namespace Containers.Web.ViewModels.SRSObjects.Industrial
{
    using System;

    public class SRSObjectIndustrialSchemeInputModel
    {
        public int SrsobjectIndustrialId { get; set; }

        public DateTime? EntryDate { get; set; }

        public byte WeekDay { get; set; }

        public byte[] Hour { get; set; }
    }
}
