using Microsoft.AspNetCore.Mvc;
using TrainTicketShop.Entities;
using TrainTicketShop.Services;
using TrainTicketShop.ViewModels;
using System.Collections.Generic;

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
            Carriage carriage = new Carriage(json);

            CarriageSchema schema = _carriageSchemaData.GetSchema(carriage.Schema.Id);

            ViewBag.CarriageSchemaSvg = schema.Schema;


            return View(new CarriageViewModel {
                Carriage = carriage,
                CarriageSchema = schema,
                Tickets = new List<TicketViewModel>(new TicketViewModel[10]) //todo can be invalid
            });
        }
    }
}
