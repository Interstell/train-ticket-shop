using System.Collections.Generic;
using System.Net.Http;
using TrainTicketShop.Services.SessionId;

namespace TrainTicketShop.Services.Railway {
    public interface ICarriageInfoService {
        string GetCarriageInfo(string carriageHash);
    }

    public class CarriageInfoService : ICarriageInfoService
    {
        private ISessionIdService _pbSessionIdService;
        private HttpClient _httpClient;

        public CarriageInfoService(HttpClient client, ISessionIdService sessionIdService) {
            _httpClient = client;
            _pbSessionIdService = sessionIdService;
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
