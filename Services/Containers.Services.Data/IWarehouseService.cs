namespace Containers.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Containers.Web.ViewModels.Warehouses;

    public interface IWarehouseService
    {
        Task CreateAsync(WarehouseInputModel model, string userId);

        Task UpdateAsync(int id, WarehouseInputModel input);

        Task DeleteAsync(int id);

        IEnumerable<WarehouseViewModel> GetAll();

        WarehouseInputModel GetById(int id);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
