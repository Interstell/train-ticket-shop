using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace TrainTicketShop.Entities {

    public static class EnumExtensions {
        public static string GetDisplayName(this Enum enumValue) {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
    }

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
