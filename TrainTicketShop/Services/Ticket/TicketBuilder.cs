using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainTicketShop.Services.Ticket
{
    interface ITicketBuilder {
        void PrepareObject();
        void FillPassengerInfo();
        void FillTrainInfo();
        void FillCarriageInfo();
    }

    public class TicketBuilder
    {

    }
}
