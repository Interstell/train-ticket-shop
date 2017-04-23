using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TrainTicketShop.Entities {
    public class TrainTicketShopDbContext : IdentityDbContext<User>
    {
        public TrainTicketShopDbContext(DbContextOptions options) : base(options) {

        }
    }
}
