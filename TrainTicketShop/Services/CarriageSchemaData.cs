using System.Linq;
using TrainTicketShop.Entities;

namespace TrainTicketShop.Services {
    public interface ICarriageSchemaData {
        CarriageSchema GetSchema(int id);
    }

    public class CarriageSchemaData : ICarriageSchemaData
    {
        private TrainTicketShopDbContext _context;

        public CarriageSchemaData(TrainTicketShopDbContext context) {
            _context = context;
        }

        public CarriageSchema GetSchema(int schemaId) {
            return _context.CarriageSchemas.FirstOrDefault(r => r.SchemaId == schemaId);
        }
    }
}
