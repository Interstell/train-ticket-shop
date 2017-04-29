using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTicketShop.Entities;
using TrainTicketShop.Services;
using TrainTicketShop.Services.Messaging;
using TrainTicketShop.Services.Tickets;
using TrainTicketShop.ViewModels;

namespace TrainTicketShop.Controllers {

    public class OrderController : Controller {
        private IOrderCacheService _orderCacheService;
        private ITicketData _ticketData;

        public OrderController(IOrderCacheService orderCacheService, ITicketData ticketData ) {
            _orderCacheService = orderCacheService;
            _ticketData = ticketData;
        }

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
            TicketOrder order = new TicketOrder(_orderCacheService, _ticketData) {
                Tickets = tickets,
                Email = model.Email,
                CreationDate = DateTime.Now
            };

            order.SetHashCode();
            order.Book();

            return View(new ConfirmationViewModel {
                Order = order,
                Train = model.Carriage.Train,
                Carriage = model.Carriage
            });
        }

        

        [HttpPost]
        public IActionResult Confirm(string hash) {
            TicketOrder order = _orderCacheService.Get(hash);
            order.OrderCacheService = _orderCacheService;
            order.TicketData = _ticketData;

            order.ConfirmPayment();
            return RedirectToAction("Success", new { hash = hash });
        }

        [HttpGet]
        public IActionResult Success([FromQuery]string hash) {
            TicketOrder order = _orderCacheService.Get(hash);
            if (order == null) {
                return RedirectToAction("Index", "Search");
            }
            return View(order);
        }

        [HttpGet]
        public IActionResult Ticket([FromQuery]string hash) {
            return View(_ticketData.Get(hash));
        }

        private void ConstructTicket(ITicketBuilder builder) {
            builder.ChooseStrategy();
            builder.FillCarriageInfo();
            builder.FillPassengerInfo();
            builder.FillTrainInfo();
            builder.CreateHashCode();
        }

        public IActionResult Email() {
            EmailSender sender = new EmailSender();
            sender.Test().Wait();
            return Content("ok");
        }

        
    }

}
