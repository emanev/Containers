namespace Containers.Web.Controllers
{
    using Containers.Services.Data;
    using Containers.Web.ViewModels.Warehouses;
    using Microsoft.AspNetCore.Mvc;

    public class WarehouseController : BaseController
    {
        private readonly IWarehouseService warehouseService;

        public WarehouseController(WarehouseService warehouseService)
        {
            this.warehouseService = warehouseService;
        }


        public IActionResult All()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(WarehouseViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                //TODO: return error
            }

            return this.View("Add", model);
        }

        [HttpPut]
        public IActionResult Details(WarehouseViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                //TODO: return error
            }

            return this.View("Details", model);
        }

        [HttpPut]
        public IActionResult Move(WarehouseViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                //TODO: return error
            }

            return this.View("Move", model);
        }
    }
}
