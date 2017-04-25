using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TrainTicketShop.Entities;
using TrainTicketShop.Services;

namespace TrainTicketShop.Controllers {
    public class TrainController : Controller
    {
        private TrainInfoService _trainInfoService;
        private CarriageInfoService _carriageInfoService;
        private ICarriageSchemaData _carriageSchemaData;

        public TrainController(TrainInfoService trainInfoService, 
            CarriageInfoService carriageInfoService,
            ICarriageSchemaData carriageSchemaData) {
            _trainInfoService = trainInfoService;
            _carriageInfoService = carriageInfoService;
            _carriageSchemaData = carriageSchemaData;
        }

        [HttpGet]
        public IActionResult Index([FromQuery]string hash) {
            /*return new JsonResult(JsonConvert.DeserializeObject(
                    _trainInfoService.GetTrainInfo(hash)
                ));*/
            string json = _trainInfoService.GetTrainInfo(hash);
            Train model = new Train(json);

            return View(model);
        }

        [HttpGet]
        public IActionResult Car([FromQuery]string hash) {
            /*return new JsonResult(JsonConvert.DeserializeObject(
                    _carriageInfoService.GetCarriageInfo(hash);
                ));*/

            string json = _carriageInfoService.GetCarriageInfo(hash);
            Carriage model = new Carriage(json);

            CarriageSchema schema = _carriageSchemaData.GetSchema(model.Schema.Id);

            ViewBag.CarriageSchemaSvg = schema.Schema;

            return View(model);
        }
    }
}
