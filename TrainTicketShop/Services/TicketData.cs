using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTicketShop.Entities;

namespace TrainTicketShop.Services
{
    public interface ITicketData {
        void Add(Ticket ticket);
        Ticket Get(string hash);
        void Commit();
    }

    public class TicketData : ITicketData {
        private TrainTicketShopDbContext _context;

        public TicketData(TrainTicketShopDbContext context) {
            _context = context;
        }

        public void Add(Ticket ticket) {
            _context.Tickets.Add(ticket);
        }

        public void Commit() {
            _context.SaveChanges();
        }

        public Ticket Get(string hash) {
            return _context.Tickets.First(t => t.Hash == hash);
        }
    }
}
