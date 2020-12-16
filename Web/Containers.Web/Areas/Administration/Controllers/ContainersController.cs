namespace Containers.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Containers.Data.Models;
    using Containers.Services.Data;
    using Containers.Web.Areas.Administration.Controllers;
    using Containers.Web.ViewModels.Containers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ContainersController : AdministrationController
    {
        private readonly IContainersService containersService;
        private readonly IWarehouseService warehouseService;
        private readonly UserManager<ApplicationUser> userManager;

        public ContainersController(
            IContainersService containersService,
            IWarehouseService warehouseService,
            UserManager<ApplicationUser> userManager)
        {
            this.containersService = containersService;
            this.warehouseService = warehouseService;
            this.userManager = userManager;
        }

        public IActionResult All()
        {
            var viewModel = new ContainersListViewModel
            {
                Containers = this.containersService.GetAll(),
            };
            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var container = this.containersService.GetById(id);
            return this.View(container);
        }

        public IActionResult Delete(int id)
        {
            var container = this.containersService.GetById(id);
            return this.View(container);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.containersService.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new ContainersInputModel();
            viewModel.WarehouseItems = this.warehouseService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(ContainersInputModel model)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    model.WarehouseItems = this.warehouseService.GetAllAsKeyValuePairs();
                    return this.View(model);
                }

                if (model.WarehouseToId == 0)
                {
                    model.WarehouseItems = this.warehouseService.GetAllAsKeyValuePairs();
                    this.ModelState.AddModelError(string.Empty, "Please fill warehouses!");
                    return this.View(model);
                }

                var user = await this.userManager.GetUserAsync(this.User);

                await this.containersService.CreateAsync(model, user.Id);

                return this.RedirectToAction("All");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View();
            }
        }
    }
}
