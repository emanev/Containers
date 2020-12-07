namespace Containers.Services.Data
{
    using System.Collections.Generic;

    using Containers.Web.ViewModels.SRSObjects.Industrial;

    public interface ISRSObjectIndustrialService
    {
        IEnumerable<SRSObjectIndustrialViewModel> GetAll();
    }
}
