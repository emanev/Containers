namespace Containers.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Containers.Data.Models;
    using Containers.Services.Data;
    using Containers.Web.ViewModels.Schedules;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ScheduleController : BaseController
    {
        private readonly IScheduleService scheduleService;
        private readonly IDistrictsService districtService;
        private readonly ISRSObjectIndustrialService srsObjectIndustrialService;
        private readonly UserManager<ApplicationUser> userManager;

        public ScheduleController(
            IScheduleService scheduleService,
            IDistrictsService districtService,
            ISRSObjectIndustrialService srsObjectIndustrialService,
            UserManager<ApplicationUser> userManager)
        {
            this.scheduleService = scheduleService;
            this.districtService = districtService;
            this.srsObjectIndustrialService = srsObjectIndustrialService;
            this.userManager = userManager;
        }

        public IActionResult All()
        {
            var viewModel = new ScheduleListViewModel
            {
                Schedules = this.scheduleService.GetAll(),
            };
            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var schedule = this.scheduleService.GetById(id);
            if (schedule == null)
            {
                return this.NotFound();
            }

            return this.View(schedule);
        }

        [Authorize]
        public IActionResult Create()
        {
            var model = new ScheduleInputModel();
            model.DistrictItems = this.districtService.GetAllAsKeyValuePairs();
            model.SrsObjectIndustrialItems = this.srsObjectIndustrialService.GetAllAsKeyValuePairs();
            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(ScheduleInputModel model)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    model.DistrictItems = this.districtService.GetAllAsKeyValuePairs();
                    model.SrsObjectIndustrialItems = this.srsObjectIndustrialService.GetAllAsKeyValuePairs();
                    return this.View(model);
                }

                if (model.DistrictId == 0)
                {
                    model.DistrictItems = this.districtService.GetAllAsKeyValuePairs();
                    this.ModelState.AddModelError(string.Empty, "Please fill districts!");
                    return this.View(model);
                }

                if (model.SrsobjectId == 0)
                {
                    model.DistrictItems = this.districtService.GetAllAsKeyValuePairs();
                    this.ModelState.AddModelError(string.Empty, "Please fill SRS Objects!");
                    return this.View(model);
                }

                var user = await this.userManager.GetUserAsync(this.User);

                await this.scheduleService.CreateAsync(model, user.Id);

                this.TempData["Message"] = "The schedule was added successfully.";

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
