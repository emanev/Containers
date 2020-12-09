namespace Containers.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Containers.Web.ViewModels.Warehouses;

    public interface IWarehouseService
    {
        Task CreateAsync(WarehouseInputModel model, string userId);

        Task UpdateAsync(int id, WarehouseViewModel input);

        IEnumerable<WarehouseViewModel> GetAll();

        WarehouseViewModel GetById(int id);
    }
}
