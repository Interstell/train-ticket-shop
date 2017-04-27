using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TrainTicketShop.Services.Railway;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrainTicketShop.Controllers.REST.SearchHints {
    [Route("api/search/hints")]
    public class SearchHintsController : Controller {
        private IRailwayService _railwayService;

        public SearchHintsController(IRailwayService railwayService) {
            _railwayService = railwayService;
        }

        [HttpGet]
        public JsonResult Get([FromQuery] string input) {
            return new JsonResult(JsonConvert.DeserializeObject(_railwayService.GetHints(input)));
        }
    }
}
