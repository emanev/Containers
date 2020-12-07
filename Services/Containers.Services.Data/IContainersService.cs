namespace Containers.Services.Data
{
    using System.Collections.Generic;

    using System.Threading.Tasks;

    using Containers.Services.Data.Models;

    public interface IContainersService
    {
        Task CreateAsync(ContainersInputModel model);

        IEnumerable<ContainersViewModel> GetAll();
    }
}
