namespace Containers.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Containers.Web.ViewModels.SRSObjects.Industrial;

    public interface ISRSObjectIndustrialContainerService
    {
        Task CreateAsync(SRSObjectIndustrialContainerInputModel input, string userId);

        IEnumerable<SRSObjectIndustrialContainerViewModel> GetAll(int id);
    }
}
