using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrainTicketShop.Entities;

namespace TrainTicketShop.ViewModels
{
    public enum PassengerType {
        [Display(Name = "Взрослый")]
        Adult,
        [Display(Name = "Ребенок")]
        Kid,
        [Display(Name = "Студент")]
        Student
    }

    public class TicketViewModel { 
        //[Required]
        public int SeatNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public PassengerType PassengerType { get; set; }

        [RegularExpression(@"\d{2}.\d{2}.\d{4}")]
        public string BirthDate { get; set; }
        [RegularExpression(@"[А-Я]{2}\d{8}")]
        public string StudentsCardId { get; set; }
    }

    public class CarriageViewModel
    {
        public Carriage Carriage { get; set; }
        public string CarriageSerialized { get; set; }
        public List<TicketViewModel> Tickets { get; set; }
    }
}
