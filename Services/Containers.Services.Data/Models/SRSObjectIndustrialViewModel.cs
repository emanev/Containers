﻿namespace Containers.Services.Data.Models
{
    using System;

    public class SRSObjectIndustrialViewModel
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string ContactPerson { get; set; }

        public string Note { get; set; }

        public DateTime? EntryDate { get; set; }

        public int UserId { get; set; }

        public int DistrictId { get; set; }
    }
}