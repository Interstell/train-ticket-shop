using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTicketShop.Entities;

namespace TrainTicketShop.Services.Messaging
{
    public interface IMessageSender {
        IMessageSender Successor { get; set; }

        Task SendTicketLinks(TicketOrder order);
    }
}
