using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTicketShop.Entities;

namespace TrainTicketShop.ViewModels
{
    public class ConfirmationViewModel
    {
        public TicketOrder Order { get; set; }
        public TrainSuperBriefly Train { get; set; }
        public Carriage Carriage { get; set; }
    }
}
