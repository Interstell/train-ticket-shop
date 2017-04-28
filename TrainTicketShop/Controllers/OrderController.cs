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
            TicketOrder order = new TicketOrder() {
                Tickets = tickets,
                Email = model.Email,
                CreationDate = DateTime.Now
            };
            order.SetHashCode();

            return View(new ConfirmationViewModel {
                Order = order,
                Train = model.Carriage.Train,
                Carriage = model.Carriage
            });

        }

        private void ConstructTicket(ITicketBuilder builder) {
            builder.ChooseStrategy();
            builder.FillCarriageInfo();
            builder.FillPassengerInfo();
            builder.FillTrainInfo();
            builder.CreateHashCode();
        }

        
    }

}
