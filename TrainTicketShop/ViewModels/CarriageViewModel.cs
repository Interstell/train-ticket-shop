using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTicketShop.Entities;

namespace TrainTicketShop.ViewModels
{
    public enum PassengerType {
        Adult,
        Kid,
        Student
    }

    public class TicketViewModel { //todo attributes like required && max/minlength
        public int SeatNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public PassengerType PassengerType { get; set; }

        public string BirthDate { get; set; }
        public string StudentsCardId { get; set; }
    }

    public class CarriageViewModel
    {
        public Carriage Carriage { get; set; }
        public CarriageSchema CarriageSchema { get; set; }
        public List<TicketViewModel> Tickets { get; set; }

    }
}
