using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainTicketShop.Entities
{
    public class Ticket
    {
        public string Email { get; set; } 

        public string Name { get; set; } 
        public string Surname { get; set; } 
        public int SeatNumber { get; set; }  
        public PassengerType PassengerType { get; set; } 

        public string BirthDate { get; set; } 
        public string StudentsCardId { get; set; }

        public string TrainNumber { get; set; }
        public int TrainTravelTime { get; set; }
        public string TrainPassengerDepartureDate { get; set; }
        public string TrainPassengerArrivalDate { get; set; }
        public string TrainClass { get; set; }
        public string TrainCategory { get; set; }
        public string TrainModel { get; set; }
        public string TrainDepartureStation { get; set; }
        public int TrainDepartureStationId { get; set; }
        public string TrainArrivalStation { get; set; }
        public int TrainArrivalStationId { get; set; }
        public string TrainPassengerDepartureStation { get; set; }
        public int TrainPassengerDepartureStationId { get; set; }
        public string TrainPassengerArrivalStation { get; set; }
        public int TrainPassengerArrivalStationId { get; set; }


        public string CarriageNumber { get; set; }
        public string CarriageType { get; set; }
        public string Price { get; set; }

    }
}
