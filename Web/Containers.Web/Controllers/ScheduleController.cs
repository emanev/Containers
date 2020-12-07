namespace Containers.Web.Controllers
{
    using Containers.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    public class ScheduleController : BaseController
    {
        private readonly IScheduleService scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            this.scheduleService = scheduleService;
        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
