using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrainTicketShop.Entities;
using TrainTicketShop.Validators;

namespace TrainTicketShop.ViewModels
{
    

    [Validator(typeof(TicketViewModelValidator))]
    public class TicketViewModel {
        public bool IsActive { get; set; }

        public int SeatNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public PassengerType PassengerType { get; set; }

        public string BirthDate { get; set; }
        public string StudentsCardId { get; set; }

        public TicketViewModel() {
            IsActive = false;
        }
    }

    public class CarriageViewModel
    {
        [Required]
        public string Email { get; set; }
        public string MobilePhone { get; set; }

        public Carriage Carriage { get; set; }
        public string CarriageSerialized { get; set; }
        public List<TicketViewModel> Tickets { get; set; }
    }
}
