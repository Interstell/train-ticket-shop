using StackExchange.Redis;

namespace TrainTicketShop.Services {
    // #PATTERN ADAPTER
    public interface IHintsCacheService {
        string Get(string key);
        void Set(string key, string value);
    }


    public class HintsCacheService : IHintsCacheService
    {
        private ConnectionMultiplexer _redis;
        private IDatabase _db;

        public HintsCacheService(ConnectionMultiplexer multiplexer) {
            _redis = multiplexer;
            _db = _redis.GetDatabase(0);
        }

        public string Get(string key) {
            return _db.StringGet(key);
        }

        public void Set(string key, string value) {
            _db.StringSetAsync(key, value);
            //todo add BGSAVE call or add this call on Cron https://www.hangfire.io/
        }

    }
}
