using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using TrainTicketShop.Entities;

namespace TrainTicketShop.Services.Messaging {
    public class EmailSender : IMessageSender {
        public IMessageSender Successor { get; set; }

        public void SendTicketLink(Ticket ticket) {
            throw new NotImplementedException();
        }

        public async Task Test() {
            var apiKey = "hardcoded string";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("watchman.kpi@yandex.ru", "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("urukovdima@gmail.com", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
