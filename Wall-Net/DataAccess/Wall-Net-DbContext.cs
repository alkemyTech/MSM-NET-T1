using Microsoft.EntityFrameworkCore;
using Wall_Net.Models;

namespace Wall_Net.DataAccess
{
    public class Wall_Net_DbContext : DbContext
    {
        public Wall_Net_DbContext(DbContextOptions<Wall_Net_DbContext> options) : base(options)
        {
            FillUsers();
        }
        public DbSet<User> Users { get; set; }

        private void FillUsers()
        {
            if (Users.Count() == 0)
            {
                Users.Add(new User
                { 
                    Id = 1,
                    FirstName = "Leandro", 
                    LastName = "Mumbach",
                    Email = "lean@email.com",
                    Password = "123456",
                    Points = 20,
                    Rol_Id = 1,
                });
                Users.Add(new User
                {
                    Id = 2,
                    FirstName = "Pepe",
                    LastName = "Gonzalez",
                    Email = "pepe@email.com",
                    Password = "123456",
                    Points = 20,
                    Rol_Id = 1,
                });
                this.SaveChanges();
            }
        }
    }
}
