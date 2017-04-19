using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainTicketShop.Entities
{
    public class TrainTicketShopDbContext : IdentityDbContext<User>
    {
        public TrainTicketShopDbContext(DbContextOptions options) : base(options) {

        }
    }
}
