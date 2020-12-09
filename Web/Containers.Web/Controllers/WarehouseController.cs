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
        private readonly UserManager<ApplicationUser> userManager;

        public WarehouseController(WarehouseService warehouseService, UserManager<ApplicationUser> userManager)
        {
            this.warehouseService = warehouseService;
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

        //[Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Create(WarehouseInputModel model)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View();
                }

                var user = await this.userManager.GetUserAsync(this.User);

                await this.warehouseService.CreateAsync(model, user.Id);

                this.TempData["Message"] = "Container added successfully.";

                return this.RedirectToAction("All");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View();
            }
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

        //[Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Edit(int id)
        {
            var inputModel = this.warehouseService.GetById(id);
            return this.View(inputModel);
        }

        [HttpPost]
        //[Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Edit(int id, WarehouseViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.warehouseService.UpdateAsync(id, input);
            return this.RedirectToAction(nameof(this.Edit), new { id });
        }
    }
}
