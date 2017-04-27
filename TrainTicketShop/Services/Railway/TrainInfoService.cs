using System.Collections.Generic;
using System.Net.Http;
using TrainTicketShop.Services.SessionId;

namespace TrainTicketShop.Services.Railway {
    public interface ITrainInfoService {
        string GetTrainInfo(string trainHash);
    }

    public class TrainInfoService : ITrainInfoService
    {
        private HttpClient _httpClient;
        private ISessionIdService _sessionIdService;

        public TrainInfoService(HttpClient client, ISessionIdService sessionIdService) {
            _httpClient = client;
            _sessionIdService = sessionIdService;
        }

        public string GetTrainInfo(string trainHash) {
            var body = new FormUrlEncodedContent(new[]{
                    new KeyValuePair<string, string>("lang", "RU"),
                    new KeyValuePair<string, string>("trainHash", trainHash),
                    new KeyValuePair<string, string>("trainInfo", "true"),
                    new KeyValuePair<string, string>("sessionId", _sessionIdService.GetSessionId())
                });
            var result = _httpClient.PostAsync("https://bilet.privatbank.ua/sm/train/train.json", body).Result;
            return result.Content.ReadAsStringAsync().Result;
        }
    }
    
}
