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

        // Containers/All/8
        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 12;
            var viewModel = new ContainersListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                ContainersCount = this.containersService.GetCount(),
                Containers = this.containersService.GetAll(id, ItemsPerPage),
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
                model.WarehouseItems = this.warehouseService.GetAllAsKeyValuePairs();

                if (!this.ModelState.IsValid)
                {
                    return this.View(model);
                }

                if (model.WarehouseToId == 0)
                {
                    this.ModelState.AddModelError(string.Empty, "Please fill warehouses!");
                    return this.View(model);
                }

                if (!this.containersService.IsUniqueContainer(model))
                {
                    this.ModelState.AddModelError(string.Empty, "Inventar number is not unique!");
                    return this.View(model);
                }

                var user = await this.userManager.GetUserAsync(this.User);

                await this.containersService.CreateAsync(model, user.Id);

                this.TempData["Message"] = "Container was added successfully.";

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
