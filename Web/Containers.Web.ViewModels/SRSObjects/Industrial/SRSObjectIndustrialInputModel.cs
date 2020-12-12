namespace Containers.Web.ViewModels.SRSObjects.Industrial
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SRSObjectIndustrialInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string ContactPerson { get; set; }

        public string Note { get; set; }

        public DateTime? EntryDate { get; set; }

        public int UserId { get; set; }

        public int DistrictId { get; set; }

        public string DistrictName { get; set; }

        public IEnumerable<KeyValuePair<string, string>> DistrictItems { get; set; }
    }
}
