namespace Containers.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Containers.Web.ViewModels.Containers;

    public interface IContainersService
    {
        Task CreateAsync(ContainersInputModel model, string userId);

        IEnumerable<ContainersViewModel> GetAll();

        ContainersViewModel GetById(int id);

        Task DeleteAsync(int id);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
