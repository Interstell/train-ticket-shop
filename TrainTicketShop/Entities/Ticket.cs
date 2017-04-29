using System.ComponentModel.DataAnnotations;

namespace TrainTicketShop.Entities
{
    public class Ticket
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; } 

        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public int SeatNumber { get; set; }
        [Required]
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

        [Required]
        public string CarriageNumber { get; set; }
        [Required]
        public string CarriageType { get; set; }
        [Required]
        public double Price { get; set; }

        [Required]
        public string Hash { get; set; }
        [Required]
        public string BoughtDate { get; set; }

    }
}
