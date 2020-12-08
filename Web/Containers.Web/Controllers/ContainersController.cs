namespace Containers.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Containers.Services.Data;
    using Containers.Web.ViewModels.Containers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ContainersController : BaseController
    {
        private readonly IContainersService containersService;

        public ContainersController(IContainersService containersService)
        {
            this.containersService = containersService;
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
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(ContainersInputModel model)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View();
                }

                await this.containersService.CreateAsync(model);

                this.TempData["Message"] = "Container added successfully.";

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
