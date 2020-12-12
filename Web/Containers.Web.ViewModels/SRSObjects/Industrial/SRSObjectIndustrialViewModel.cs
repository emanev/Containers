namespace Containers.Web.ViewModels.SRSObjects.Industrial
{
    using System;

    public class SRSObjectIndustrialViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string ContactPerson { get; set; }

        public string Note { get; set; }

        public DateTime? EntryDate { get; set; }

        public string UserId { get; set; }

        public int DistrictId { get; set; }

        public string DistrictName { get; set; }
    }
}
