using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TrainTicketShop.Entities {

    public enum PassengerType {
        [Display(Name = "Взрослый")]
        Adult,
        [Display(Name = "Ребенок")]
        Kid,
        [Display(Name = "Студент")]
        Student
    }

    public class User : IdentityUser
    {
        public User() {

        }
    }
}
