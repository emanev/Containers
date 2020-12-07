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
