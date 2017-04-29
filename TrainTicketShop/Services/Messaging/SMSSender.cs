using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TrainTicketShop.Entities;

namespace TrainTicketShop.Services.Messaging
{
    public class SMSSender : IMessageSender
    {
        private string _apiKey;
        private HttpClient _httpClient;
        public IMessageSender Successor { get; set; }

        public SMSSender(string apiKey, HttpClient client) {
            _apiKey = apiKey;
            _httpClient = client;
        }

        public Task SendTicketLinks(TicketOrder order) {
            if (!String.IsNullOrEmpty(order.MobilePhone)) {
                var sb = new StringBuilder();
                foreach (var ticket in order.Tickets) {
                    sb.Append(ticket.Hash);
                    sb.Append(" \n");
                }

                var result = _httpClient.GetAsync($"https://api.mobizon.com/service/message/sendsmsmessage?apiKey={_apiKey}&recipient={order.MobilePhone}&text={sb.ToString()}&from=Poezzhayka".Replace(' ','+')).Result;
                Successor?.SendTicketLinks(order);
                return result.Content.ReadAsStringAsync();
            }
           
            Successor?.SendTicketLinks(order);
            return null;
        }
    }
}
