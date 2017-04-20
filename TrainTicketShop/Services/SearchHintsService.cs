using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace TrainTicketShop.Services {
    public class SearchHintsService
    {
        private HttpClient _httpClient;
        private CacheService _cache;

        public SearchHintsService(HttpClient client, CacheService cache) {
            _httpClient = client;
            _cache = cache;
        }

        public string GetHints(string input) {
            string cachedValue = getHintsFromCache(input);
            if (cachedValue == null) {
                string webHint = getHintsFromWeb(input);
                addHintToCache(input, webHint);
                return webHint;
            }
            else return cachedValue;
        }

        private string getHintsFromWeb(string input) {
            var body = new FormUrlEncodedContent(new[]{
                    new KeyValuePair<string, string>("broker", "PbUa" ),
                    new KeyValuePair<string, string>("lang", "RU"),
                    new KeyValuePair<string, string>("prefix", input)
                });
            var result = _httpClient.PostAsync("https://bilet.privatbank.ua/sm/train/stations.json", body).Result;
            return result.Content.ReadAsStringAsync().Result;
        }

        private string getHintsFromCache(string input) {
            return _cache.Get(input);
        }

        private void addHintToCache(string input, string hint) {
            _cache.Set(input, hint);
        }
    }
}
