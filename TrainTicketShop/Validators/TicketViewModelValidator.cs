using FluentValidation;
using System.Text.RegularExpressions;
using TrainTicketShop.ViewModels;

namespace TrainTicketShop.Validators {
    public class TicketViewModelValidator : AbstractValidator<TicketViewModel> {
        public TicketViewModelValidator() {
            RuleFor(ticketVM => ticketVM.Surname)
                .NotEmpty()
                .When(ticketVM => ticketVM.IsActive == true)
                .WithMessage("Укажите фамилию.");
            RuleFor(ticketVM => ticketVM.Name)
                .NotEmpty()
                .When(ticketVM => ticketVM.IsActive == true)
                .WithMessage("Укажите имя.");
            RuleFor(ticketVM => ticketVM.PassengerType)
                .IsInEnum();
            RuleFor(ticketVM => ticketVM.BirthDate)
                .Must(birthdate => Regex.IsMatch(birthdate, @"\d{2}.\d{2}.\d{4}"))
                .When(ticketVM => ticketVM.IsActive == true)
                .WithMessage("Неправильный формат даты.");
            RuleFor(ticketVM => ticketVM.StudentsCardId)
                .Must(id => Regex.IsMatch(id, @"[А-Я]{2}\d{8}"))
                .When(ticketVM => ticketVM.IsActive == true)
                .WithMessage("Неправильный формат номера студенческого билета.");

           //todo add checks for unsupported opps for different passanger types

        }
    }
}
