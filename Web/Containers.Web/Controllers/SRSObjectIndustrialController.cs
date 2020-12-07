namespace Containers.Web.Controllers
{
    using Containers.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    public class SRSObjectIndustrialController : BaseController
    {
        private readonly ISRSObjectIndustrialService srsObjectIndustrialService;

        public SRSObjectIndustrialController(ISRSObjectIndustrialService srsObjectIndustrialService)
        {
            this.srsObjectIndustrialService = srsObjectIndustrialService;
        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
