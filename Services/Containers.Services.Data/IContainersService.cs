namespace Containers.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Containers.Web.ViewModels.Containers;

    public interface IContainersService
    {
        Task CreateAsync(ContainersInputModel model);

        IEnumerable<ContainersViewModel> GetAll();
    }
}
