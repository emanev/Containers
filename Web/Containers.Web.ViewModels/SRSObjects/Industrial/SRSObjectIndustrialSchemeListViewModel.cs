namespace Containers.Web.ViewModels.SRSObjects.Industrial
{
    using System.Collections.Generic;

    public class SRSObjectIndustrialSchemeListViewModel
    {
        public int Id { get; set; }

        public IEnumerable<SRSObjectIndustrialSchemeViewModel> SRSObjectIndustrialSchemes { get; set; }
    }
}
