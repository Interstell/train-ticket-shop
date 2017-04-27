using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TrainTicketShop.Entities;
using TrainTicketShop.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrainTicketShop.Controllers {
    public class SearchController : Controller
    {
        private SearchTrainService _searchTrainService;

        public SearchController(SearchTrainService searchTrainService) {
            _searchTrainService = searchTrainService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Train([FromQuery]int from, [FromQuery]int to, [FromQuery]string date) {
            string json = _searchTrainService.GetTrainsFromWeb(from, to, date);
            TrainsSearchResult model = new TrainsSearchResult(json);

            return View(model);
        }
    }
}
