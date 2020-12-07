namespace Containers.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Containers.Services.Data.Models;

    public interface IWarehouseService
    {
        Task CreateAsync(WarehouseViewModel model);

        IEnumerable<WarehouseViewModel> GetAll();
    }
}
