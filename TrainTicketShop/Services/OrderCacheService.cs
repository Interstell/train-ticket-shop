using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTicketShop.Entities;

namespace TrainTicketShop.Services
{
    public interface IOrderCacheService {
        TicketOrder Get(string hash);
        void Set(TicketOrder order);
        void Delete(TicketOrder order);
    }

    public class OrderCacheService : IOrderCacheService
    {
        private ConnectionMultiplexer _redis;
        private IDatabase _db;

        public OrderCacheService(ConnectionMultiplexer multiplexer) {
            _redis = multiplexer;
            _db = _redis.GetDatabase(1);
        }

        public TicketOrder Get(string hash) {
            return JsonConvert.DeserializeObject<TicketOrder>(_db.StringGet(hash));
        }

        public void Set(TicketOrder order) {
            _db.StringSetAsync(order.HashCode, JsonConvert.SerializeObject(order), TimeSpan.FromMinutes(15));
        }

        public void Delete(TicketOrder order) {
            _db.KeyDelete(order.HashCode);
        }
    }
}
