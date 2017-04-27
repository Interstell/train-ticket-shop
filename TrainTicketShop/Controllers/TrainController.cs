using Microsoft.AspNetCore.Mvc;
using TrainTicketShop.Entities;
using TrainTicketShop.Services;
using TrainTicketShop.ViewModels;
using System.Collections.Generic;
using Newtonsoft.Json;
using TrainTicketShop.Services.Railway;

namespace TrainTicketShop.Controllers {
    public class TrainController : Controller
    {

        private ICarriageSchemaData _carriageSchemaData;
        private IRailwayService _railwayService;

        public TrainController(IRailwayService railwayService,
            ICarriageSchemaData carriageSchemaData) {

            _carriageSchemaData = carriageSchemaData;
            _railwayService = railwayService;
        }

        [HttpGet]
        public IActionResult Index([FromQuery]string hash) {
            string json = _railwayService.GetTrainInfo(hash);
            Train model = new Train(json);

            return View(model);
        }

        [HttpGet]
        public IActionResult Car([FromQuery]string hash) {
            string json = _railwayService.GetCarriageInfo(hash);
            Carriage carriage = new Carriage(json);

            CarriageSchema schema = _carriageSchemaData.GetSchema(carriage.Schema.Id);

            ViewBag.CarriageSchemaSvg = schema.Schema;

            return View(new CarriageViewModel {
                Carriage = carriage,
                CarriageSerialized = JsonConvert.SerializeObject(carriage),
                Tickets = new List<TicketViewModel>(new TicketViewModel[10])
            });
        }
    }
}
