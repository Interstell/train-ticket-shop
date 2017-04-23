using System.Collections.Generic;
using System.Net.Http;
using TrainTicketShop.Services.SessionId;

namespace TrainTicketShop.Services {
    public class TrainInfoService
    {
        private HttpClient _httpClient;
        private PbSessionIdService _pbSessionIdService;

        public TrainInfoService(HttpClient client, PbSessionIdService pbSessionIdService) {
            _httpClient = client;
            _pbSessionIdService = pbSessionIdService;
        }

        public string GetTrainInfo(string trainHash) {
            var body = new FormUrlEncodedContent(new[]{
                    new KeyValuePair<string, string>("lang", "RU"),
                    new KeyValuePair<string, string>("trainHash", trainHash),
                    new KeyValuePair<string, string>("trainInfo", "true"),
                    new KeyValuePair<string, string>("sessionId", _pbSessionIdService.GetSessionId())
                });
            var result = _httpClient.PostAsync("https://bilet.privatbank.ua/sm/train/train.json", body).Result;
            return result.Content.ReadAsStringAsync().Result;
        }
    }
    
}
