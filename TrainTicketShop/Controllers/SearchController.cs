using Microsoft.AspNetCore.Mvc;
using TrainTicketShop.Entities;
using TrainTicketShop.Services.Railway;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrainTicketShop.Controllers {
    public class SearchController : Controller
    {
        private IRailwayService _railwayService;

        public SearchController(IRailwayService railwayService) {
            _railwayService = railwayService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Train([FromQuery]int from, [FromQuery]int to, [FromQuery]string date) {
            string json = _railwayService.GetTrainsFromWeb(from, to, date);
            TrainsSearchResult model = new TrainsSearchResult(json);

            return View(model);
        }
    }
}
