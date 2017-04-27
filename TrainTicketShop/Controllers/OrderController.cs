using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTicketShop.Entities;
using TrainTicketShop.Services.Tickets;
using TrainTicketShop.ViewModels;

namespace TrainTicketShop.Controllers {
    public class OrderController : Controller {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(CarriageViewModel model) {
            model.Carriage = JsonConvert.DeserializeObject<Carriage>(model.CarriageSerialized);

            List<Ticket> tickets = new List<Ticket>();
            foreach (var ticketVM in model.Tickets.Where(ticket => ticket.IsActive)) {
                ITicketBuilder builder = new TicketBuilder(ticketVM, model.Carriage, model.Email);
                ConstructTicket(builder);
                tickets.Add(builder.Ticket);
            }
            return View();

        }

        private Ticket ConstructTicket(ITicketBuilder builder) {
            builder.ChooseStrategy();
            builder.FillPassengerInfo();
            builder.FillTrainInfo();
            builder.FillCarriageInfo();
            return builder.Ticket;
        }
    }
}
