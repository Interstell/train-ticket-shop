using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using TrainTicketShop.Entities;

namespace TrainTicketShop.Services.Messaging {
    public class EmailSender : IMessageSender {
        private string _apiKey;

        public EmailSender(string apiKey) {
            _apiKey = apiKey;
        }

        public IMessageSender Successor { get; set; }

        public async Task SendTicketLinks(TicketOrder order) {
            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress("watchman.kpi@yandex.ru", "Поезжайка");
            var subject = $"Покупка билетов {order.Tickets[0].TrainPassengerDepartureStation} - {order.Tickets[0].TrainPassengerArrivalStation}";
            var to = new EmailAddress(order.Email, "User");
            var sbPlain = new StringBuilder();
            var sbHtml = new StringBuilder();

            sbPlain.Append("Вы приобрели билеты на поезд на нашем сайте. На всякий случай, отправляем Вам ссылки на них.\n");
            sbHtml.Append(
                "<h3>Вы приобрели билеты на поезд на нашем сайте.<br> На всякий случай, отправляем Вам ссылки на них.</h3>");

            foreach (var ticket in order.Tickets) {
                sbPlain.Append($"http://localhost:58335/order/ticket?hash={ticket.Hash}\n");
                sbHtml.Append($"<a href=\"http://localhost:58335/order/ticket?hash={ticket.Hash}\">{ticket.Hash}</a><br>");
            }

            var msg = MailHelper.CreateSingleEmail(from, to, subject, sbPlain.ToString(), sbHtml.ToString());
            var response = await client.SendEmailAsync(msg);

            Successor?.SendTicketLinks(order);
        }
    }
}
