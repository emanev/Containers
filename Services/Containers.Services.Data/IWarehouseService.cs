namespace Containers.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Containers.Web.ViewModels.Warehouses;

    public interface IWarehouseService
    {
        Task CreateAsync(WarehouseViewModel model);

        Task UpdateAsync(int id, WarehouseViewModel input);

        IEnumerable<WarehouseViewModel> GetAll();
    }
}
