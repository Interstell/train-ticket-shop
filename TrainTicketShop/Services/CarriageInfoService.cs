using System.Collections.Generic;
using System.Net.Http;
using TrainTicketShop.Services.SessionId;

namespace TrainTicketShop.Services {
    public class CarriageInfoService
    {
        private PbSessionIdService _pbSessionIdService;
        private HttpClient _httpClient;

        public CarriageInfoService(HttpClient client, PbSessionIdService pbSessionIdService) {
            _httpClient = client;
            _pbSessionIdService = pbSessionIdService;
        }

        public string GetCarriageInfo(string carriageHash) {
            var body = new FormUrlEncodedContent(new[]{
                    new KeyValuePair<string, string>("carHash", carriageHash),
                    new KeyValuePair<string, string>("sessionId", _pbSessionIdService.GetSessionId())
                });
            var result = _httpClient.PostAsync("https://bilet.privatbank.ua/sm/train/car.json", body).Result;
            return result.Content.ReadAsStringAsync().Result;
        }
    }
}
