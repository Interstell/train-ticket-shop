using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTicketShop.Entities;
using TrainTicketShop.ViewModels;

namespace TrainTicketShop.Services.Tickets
{
    // #PATTERN STRATEGY
    public abstract class TicketBuildingStrategy
    {
        protected Ticket _ticket;
        protected TicketViewModel _ticketVM;

        public TicketBuildingStrategy(Ticket ticket, TicketViewModel ticketVM) {
            _ticket = ticket;
            _ticketVM = ticketVM;
        }

        public virtual void FillTicketWithData() {
            _ticket.Name = _ticketVM.Name;
            _ticket.Surname = _ticketVM.Surname;
            _ticket.PassengerType = _ticketVM.PassengerType;
        }
    }

    public class AdultStrategy : TicketBuildingStrategy {
        public AdultStrategy(Ticket ticket, TicketViewModel ticketVM) : base(ticket, ticketVM) {
        }

        public override void FillTicketWithData() {
            base.FillTicketWithData();
            //blank - nothing to do
        }
    }

    public class StudentStrategy : TicketBuildingStrategy {
        public StudentStrategy(Ticket ticket, TicketViewModel ticketVM) : base(ticket, ticketVM) {
        }

        public override void FillTicketWithData() {
            base.FillTicketWithData();
            _ticket.StudentsCardId = _ticketVM.StudentsCardId;
        }
    }

    public class KidStrategy : TicketBuildingStrategy {
        public KidStrategy(Ticket ticket, TicketViewModel ticketVM) : base(ticket, ticketVM) {
        }

        public override void FillTicketWithData() {
            base.FillTicketWithData();
            _ticket.BirthDate = _ticketVM.BirthDate;
        }
    }
}
