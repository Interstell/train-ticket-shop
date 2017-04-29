using System;
using System.Text.RegularExpressions;
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
            if (Regex.IsMatch(_ticket.StudentsCardId, @"[А-Я]{2}\d{8}") 
                && _ticket.CarriageType == "плацкарт" || _ticket.CarriageType == "сидячий 2 класс") {
                _ticket.Price *= 0.5;
            }
        }
    }

    public class KidStrategy : TicketBuildingStrategy {
        public KidStrategy(Ticket ticket, TicketViewModel ticketVM) : base(ticket, ticketVM) {
        }

        public override void FillTicketWithData() {
            base.FillTicketWithData();
            _ticket.BirthDate = _ticketVM.BirthDate;
            var now = DateTime.Now;
            var sixYears = now.AddYears(-6);
            var fourteenYears = now.AddYears(-14);
            var birthDate = DateTime.ParseExact(_ticket.BirthDate, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
            if (birthDate > fourteenYears && birthDate < sixYears) {
                _ticket.Price *= 0.25;
            }
            else if (birthDate > sixYears) {
                _ticket.Price = 0;
            }
        }
    }
}
