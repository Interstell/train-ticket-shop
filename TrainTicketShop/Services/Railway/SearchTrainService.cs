using System.Collections.Generic;
using System.Net.Http;
using TrainTicketShop.Services.SessionId;

namespace TrainTicketShop.Services.Railway {

    public interface ISearchTrainService {
        string GetTrainsFromWeb(int from, int to, string date);
    }

    public class SearchTrainService : ISearchTrainService
    {
        private HttpClient _httpClient;
        private ISessionIdService _sessionIdService;

        public SearchTrainService(HttpClient client, ISessionIdService sessionIdService) {
            _httpClient = client;
            _sessionIdService = sessionIdService;
        }

        public string GetTrainsFromWeb(int from, int to, string date) {
            var body = new FormUrlEncodedContent(new[]{
                    new KeyValuePair<string, string>("departureDate", date ),
                    new KeyValuePair<string, string>("lang", "RU"),
                    new KeyValuePair<string, string>("from", from.ToString()),
                    new KeyValuePair<string, string>("to", to.ToString()),
                    new KeyValuePair<string, string>("sessionId", _sessionIdService.GetSessionId())
                });
            var result = _httpClient.PostAsync("https://bilet.privatbank.ua/sm/train/search.json", body).Result;
            return result.Content.ReadAsStringAsync().Result;
        }
    }
}
