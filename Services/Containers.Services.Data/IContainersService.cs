namespace Containers.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Containers.Web.ViewModels.Containers;

    public interface IContainersService
    {
        Task CreateAsync(ContainersInputModel model, string userId);

        IEnumerable<ContainersViewModel> GetAll();

        IEnumerable<ContainersViewModel> GetAll(int page, int itemsPerPage = 12);

        ContainersViewModel GetById(int id);

        Task DeleteAsync(int id);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        bool IsUniqueContainer(ContainersInputModel input);

        int GetCount();
    }
}
