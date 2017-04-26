using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTicketShop.ViewModels;

namespace TrainTicketShop.Controllers
{
    public class OrderController : Controller
    {
        [HttpPost]
        public IActionResult Index(CarriageViewModel model) {

            return View();
        }
    }
}
