using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TrainTicketShop.Entities {
    public class TrainTicketShopDbContext : IdentityDbContext<User>
    {
        public TrainTicketShopDbContext(DbContextOptions options) : base(options) {

        }

        public DbSet<CarriageSchema> CarriageSchemas { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
