namespace Containers.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Containers.Web.ViewModels.SRSObjects.Industrial;

    public interface ISRSObjectIndustrialService
    {
        IEnumerable<SRSObjectIndustrialViewModel> GetAll();

        SRSObjectIndustrialViewModel GetById(int id);

        Task CreateAsync(SRSObjectIndustrialInputModel input, string userId);

        Task CreateSchemeAsync(SRSObjectIndustrialSchemeInputModel input, int id, string userId);

        IEnumerable<SRSObjectIndustrialSchemeViewModel> GetAllSchemesBySrsObjectIndustrialId(int id);

        Task CreateContainersAsync(SRSObjectIndustrialContainerInputModel input, int id, string userId);

        IEnumerable<SRSObjectIndustrialContainerViewModel> GetAllContainersBySrsObjectIndustrialId(int id);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
