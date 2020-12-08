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
        private readonly IContainersColourService containersColourService;
        private readonly IContainersCapacityService containersCapacityService;

        public ContainersController(
            IContainersService containersService,
            IContainersColourService containersColourService,
            IContainersCapacityService containersCapacityService)
        {
            this.containersService = containersService;
            this.containersColourService = containersColourService;
            this.containersCapacityService = containersCapacityService;
        }

        public IActionResult All()
        {
            // TO DO  NullRefenece Exception  model is null
            return this.View();
        }

        public IActionResult Create()
        {
            var viewModel = new ContainersInputModel();
            viewModel.ContainersColourItems = this.containersColourService.GetAllAsKeyValuePairs();
            viewModel.ContainersCapacityItems = this.containersCapacityService.GetAllAsKeyValuePairs();
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
                    return this.View();
                }

                await this.containersService.CreateAsync(model);

                this.TempData["Message"] = "Recipe added successfully.";

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
