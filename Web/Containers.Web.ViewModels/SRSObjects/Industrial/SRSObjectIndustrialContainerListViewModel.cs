namespace Containers.Web.ViewModels.SRSObjects.Industrial
{
    using System.Collections.Generic;

    public class SRSObjectIndustrialContainerListViewModel
    {
        public int Id { get; set; }

        public IEnumerable<SRSObjectIndustrialContainerViewModel> SRSObjectIndustrialContainers { get; set; }
    }
}
