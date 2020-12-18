namespace Containers.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Containers.Data.Models;
    using Containers.Services.Data;
    using Containers.Web.ViewModels.SRSObjects.Industrial;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class SRSObjectIndustrialController : BaseController
    {
        private readonly ISRSObjectIndustrialService srsObjectIndustrialService;
        private readonly IDistrictsService districtService;
        private readonly IContainersService containerService;
        private readonly UserManager<ApplicationUser> userManager;

        public SRSObjectIndustrialController(
            ISRSObjectIndustrialService srsObjectIndustrialService,
            IDistrictsService districtService,
            IContainersService containerService,
            UserManager<ApplicationUser> userManager)
        {
            this.srsObjectIndustrialService = srsObjectIndustrialService;
            this.districtService = districtService;
            this.containerService = containerService;
            this.userManager = userManager;
        }

        public IActionResult All()
        {
            var viewModel = new SRSObjectIndustrialListViewModel
            {
               SRSObjectIndustrials = this.srsObjectIndustrialService.GetAll(),
            };
            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var srsObjectIndustrial = this.srsObjectIndustrialService.GetById(id);
            if (srsObjectIndustrial == null)
            {
                return this.NotFound();
            }

            return this.View(srsObjectIndustrial);
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new SRSObjectIndustrialInputModel();
            viewModel.DistrictItems = this.districtService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(SRSObjectIndustrialInputModel model)
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

                await this.srsObjectIndustrialService.CreateAsync(model, user.Id);

                this.TempData["Message"] = "SRS Object Industrial was added successfully.";

                return this.RedirectToAction("All");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View();
            }
        }

        [Authorize]
        public IActionResult CreateScheme()
        {
            var viewModel = new SRSObjectIndustrialSchemeInputModel();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateScheme(SRSObjectIndustrialSchemeInputModel model, int id)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View(model);
                }

                if (model.Hour.Hours > 24 || model.Hour.Hours < 0)
                {
                    this.ModelState.AddModelError(string.Empty, "Please fill Correctly Hour field!");
                    return this.View(model);
                }

                var user = await this.userManager.GetUserAsync(this.User);

                await this.srsObjectIndustrialService.CreateSchemeAsync(model, id, user.Id);

                this.TempData["Message"] = "Scheme was added successfully.";

                return this.RedirectToAction("AllSchemes", new { id });
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View();
            }
        }

        public IActionResult AllSchemes(int id)
        {
            try
            {
                var viewModel = new SRSObjectIndustrialSchemeListViewModel
                {
                    Id = id,
                    SRSObjectIndustrialSchemes = this.srsObjectIndustrialService.GetAllSchemesBySrsObjectIndustrialId(id),
                };
                return this.View(viewModel);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View();
            }
        }

        [Authorize]
        public IActionResult CreateContainer(int id)
        {
            var model = new SRSObjectIndustrialContainerInputModel();
            model.ContainerItems = this.containerService.GetAllAsKeyValuePairs();
            model.SrsobjectIndustrialId = id;
            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateContainer(SRSObjectIndustrialContainerInputModel model, int id)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    model.ContainerItems = this.containerService.GetAllAsKeyValuePairs();
                    return this.View(model);
                }

                if (model.ContainerId == 0)
                {
                    model.ContainerItems = this.containerService.GetAllAsKeyValuePairs();
                    model.SrsobjectIndustrialId = id;
                    this.ModelState.AddModelError(string.Empty, "Please choose container!");
                    return this.View(model);
                }

                var user = await this.userManager.GetUserAsync(this.User);

                await this.srsObjectIndustrialService.CreateContainersAsync(model, id, user.Id);

                this.TempData["Message"] = "Industrial container was added successfully.";

                return this.RedirectToAction("AllContainers", new { id });
            }
            catch (Exception ex)
            {
                model.ContainerItems = this.containerService.GetAllAsKeyValuePairs();
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View();
            }
        }

        public IActionResult AllContainers(int id)
        {
            try
            {
                var viewModel = new SRSObjectIndustrialContainerListViewModel
                {
                    Id = id,
                    SRSObjectIndustrialContainers = this.srsObjectIndustrialService.GetAllContainersBySrsObjectIndustrialId(id),
                };
                return this.View(viewModel);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View();
            }
        }
    }
}
