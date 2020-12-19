namespace Containers.Web.Controllers
{
    using System.Diagnostics;

    using Containers.Services.Data;
    using Containers.Web.ViewModels;
    using Containers.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IGetCountsService countsService;

        public HomeController(IGetCountsService countsService)
        {
            this.countsService = countsService;
        }

        public IActionResult Index()
        {
            var countsDto = this.countsService.GetCounts();
            var viewModel = new IndexViewModel
            {
                ContainersCount = countsDto.ContainersCount,
                SRSObjectIndustrialCount = countsDto.SRSObjectIndustrialCount,
                WarehouseCount = countsDto.WarehouseCount,
                SchedulesCount = countsDto.ScheduleCount,
            };
            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
