namespace Containers.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Containers.Data.Models;
    using Containers.Services.Data;
    using Containers.Web.ViewModels.Warehouses;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class WarehouseController : BaseController
    {
        private readonly IWarehouseService warehouseService;
        private readonly IDistrictsService districtService;
        private readonly UserManager<ApplicationUser> userManager;

        public WarehouseController(
            IWarehouseService warehouseService,
            IDistrictsService districtService,
            UserManager<ApplicationUser> userManager)
        {
            this.warehouseService = warehouseService;
            this.districtService = districtService;
            this.userManager = userManager;
        }

        public IActionResult All()
        {
            var viewModel = new WarehouseListViewModel
            {
                Warehouses = this.warehouseService.GetAll(),
            };
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new WarehouseInputModel();
            viewModel.DistrictItems = this.districtService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(WarehouseInputModel model)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    model.DistrictItems = this.districtService.GetAllAsKeyValuePairs();
                    return this.View(model);
                }

                if (model.DistrictId == 0)
                {
                    model.DistrictItems = this.districtService.GetAllAsKeyValuePairs();
                    this.ModelState.AddModelError(string.Empty, "Please fill districts!");
                    return this.View(model);
                }

                var user = await this.userManager.GetUserAsync(this.User);

                await this.warehouseService.CreateAsync(model, user.Id);

                this.TempData["Message"] = "Warehouse added successfully.";

                return this.RedirectToAction("All");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View();
            }
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var container = this.warehouseService.GetById(id);
            return this.View(container);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.warehouseService.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
