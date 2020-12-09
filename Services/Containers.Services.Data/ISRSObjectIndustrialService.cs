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

        Task CreateSchemaAsync(SRSObjectIndustrialSchemaInputModel input, int srsObjectIndustrialId, string userId);

        IEnumerable<SRSObjectIndustrialSchemaViewModel> GetAllSchemesBySrsObjectIndustrialId(int id);
    }
}
