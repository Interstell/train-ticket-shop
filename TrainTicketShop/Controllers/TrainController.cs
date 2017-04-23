using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TrainTicketShop.Entities;
using TrainTicketShop.Services;

namespace TrainTicketShop.Controllers {
    public class TrainController : Controller
    {
        private TrainInfoService _trainInfoService;
        private CarriageInfoService _carriageInfoService;

        public TrainController(TrainInfoService trainInfoService, CarriageInfoService carriageInfoService) {
            _trainInfoService = trainInfoService;
            _carriageInfoService = carriageInfoService;
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

        [HttpGet]
        public IActionResult Car([FromQuery]string hash) {
            /*string json = _carriageInfoService.GetCarriageInfo(hash);
            Carriage car = new Carriage(json);*/
            /*return new JsonResult(JsonConvert.DeserializeObject(
                    _carriageInfoService.GetCarriageInfo(hash);
                ));*/

            return View();
        }
    }
}
