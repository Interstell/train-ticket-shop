using System.Collections.Generic;
using System.Net.Http;
using TrainTicketShop.Services.SessionId;

namespace TrainTicketShop.Services {
    public class SearchTrainService
    {
        private HttpClient _httpClient;
        private PbSessionIdService _pbSessionIdService;

        public SearchTrainService(HttpClient client, PbSessionIdService pbSessionIdService) {
            _httpClient = client;
            _pbSessionIdService = pbSessionIdService;
        }

        public string GetTrainsFromWeb(int from, int to, string date) {
            var body = new FormUrlEncodedContent(new[]{
                    new KeyValuePair<string, string>("departureDate", date ),
                    new KeyValuePair<string, string>("lang", "RU"),
                    new KeyValuePair<string, string>("from", from.ToString()),
                    new KeyValuePair<string, string>("to", to.ToString()),
                    new KeyValuePair<string, string>("sessionId", _pbSessionIdService.GetSessionId())
                });
            var result = _httpClient.PostAsync("https://bilet.privatbank.ua/sm/train/search.json", body).Result;
            return result.Content.ReadAsStringAsync().Result;
        }
    }
}
