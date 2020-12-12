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
        private readonly UserManager<ApplicationUser> userManager;

        public SRSObjectIndustrialController(
            ISRSObjectIndustrialService srsObjectIndustrialService,
            IDistrictsService districtService,
            UserManager<ApplicationUser> userManager)
        {
            this.srsObjectIndustrialService = srsObjectIndustrialService;
            this.districtService = districtService;
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

        [HttpGet("SRSObjectIndustrial/All/{id}")]
        public IActionResult Details(int id)
        {
            var srsObjectIndustrial = this.srsObjectIndustrialService.GetById(id);
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

        [HttpPost("SRSObjectIndustrial/All/{id}")]
        [Authorize]
        public async Task<IActionResult> CreateScheme(SRSObjectIndustrialSchemeInputModel model)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    return this.View(model);
                }

                var user = await this.userManager.GetUserAsync(this.User);

                await this.srsObjectIndustrialService.CreateSchemeAsync(model, user.Id);

                this.TempData["Message"] = "Schema was added successfully.";

                return this.RedirectToAction("AllSchemes", new { id = model.SrsobjectIndustrialId });
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View();
            }
        }

        public IActionResult AllSchemes(int id)
        {
            var viewModel = new SRSObjectIndustrialSchemeListViewModel
            {
                SRSObjectIndustrialSchemes = this.srsObjectIndustrialService.GetAllSchemesBySrsObjectIndustrialId(id),
            };
            return this.View(viewModel);
        }

        //CreateSchemaAsync
        //GetAllSchemesBySrsObjectIndustrialId
    }
}
