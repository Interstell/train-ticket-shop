using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TrainTicketShop.Entities;
using TrainTicketShop.Services;

namespace TrainTicketShop.Controllers {
    public class TrainController : Controller
    {
        private TrainInfoService _trainInfoService;

        public TrainController(TrainInfoService trainInfoService) {
            _trainInfoService = trainInfoService;
        }

        [HttpGet]
        public IActionResult Index([FromQuery]string hash) {
            /*return new JsonResult(JsonConvert.DeserializeObject(
                    _trainInfoService.GetTrainInfo(hash)
                ));*/
            /*string json = _trainInfoService.GetTrainInfo(hash);
            Train result = new Train(json);*/

            return View();
        }
    }
}
