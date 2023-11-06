using Microsoft.EntityFrameworkCore;
using Wall_Net.Models;

namespace Wall_Net.DataAccess
{
    public class Wall_Net_DbContext : DbContext
    {
        public DbSet<Roles> roles {  get; set; }

    }

}
