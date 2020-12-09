namespace Containers.Web.ViewModels.Warehouses
{
    using System.Collections.Generic;

    public class WarehouseListViewModel// : PagingViewModel
    {
        public IEnumerable<WarehouseViewModel> Warehouses { get; set; }
    }
}
