namespace Containers.Web.ViewModels.SRSObjects.Industrial
{
    using System.Collections.Generic;

    public class SRSObjectIndustrialContainerInputModel
    {
        public int SrsobjectIndustrialId { get; set; }

        public int ContainerId { get; set; }

        public int MovementId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> ContainerItems { get; set; }
    }
}
