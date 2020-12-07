namespace Containers.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Containers.Web.ViewModels.Warehouses;

    public class WarehouseService : IWarehouseService
    {
        public async Task CreateAsync(WarehouseViewModel model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WarehouseViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, WarehouseViewModel input)
        {
            throw new NotImplementedException();
        }
    }
}
