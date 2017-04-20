using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainTicketShop.Services
{
    public class CacheService
    {
        private ConnectionMultiplexer _redis;
        private IDatabase _db;

        public CacheService(ConnectionMultiplexer multiplexer) {
            _redis = multiplexer;
            _db = _redis.GetDatabase();
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
