using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTicketShop.Entities;
using TrainTicketShop.ViewModels;

namespace TrainTicketShop.Controllers
{
    public class OrderController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(CarriageViewModel model) {
            model.Carriage = JsonConvert.DeserializeObject<Carriage>(model.CarriageSerialized);
            return new JsonResult(JsonConvert.SerializeObject(model));
            /*if (ModelState.IsValid) {
                return new JsonResult(JsonConvert.SerializeObject(model));
            }
            else return View();*/
        }
    }
}
