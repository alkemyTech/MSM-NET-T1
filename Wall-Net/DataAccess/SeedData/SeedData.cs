using Microsoft.EntityFrameworkCore;
using Wall_Net.Models;

namespace Wall_Net.DataAccess.SeedData
{
    public class SeedData
    {
        public static List<Roles> SeedsRoles()
        {
            return new List<Roles>
            {
                new Roles { Id = 1, Name = "Admin", Description = "Encargado de agregar y borrar usuarios" },
                new Roles { Id = 2, Name = "Regular", Description = "Cliente nuevo" },
                new Roles { Id = 3, Name = "Admin", Description = "Administrador de las transacciones" },
                new Roles { Id = 4, Name = "Regular", Description = "Cliente antiguo" }
            };
        }
        public static List<User> SeedsUsers()
        {
            return new List<User>
            {
                new User
                {Id = 1, FirstName = "Leandro", LastName = "Mumbach" ,Email = "lean@email.com" ,Password = "123456", Points = 20, Rol_Id = 1,},
                new User
                {Id = 2, FirstName = "Pepe", LastName = "Gonzalez", Email = "pepe@email.com", Password = "123456", Points = 20, Rol_Id = 1,
                } 
            };
        }
        public static List<Account> SeedsAcounts()
        {
            return new List<Account>
            {
                new Account { Id = 1, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, User_Id = 1 },
                new Account { Id = 2, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, User_Id = 1 },
                new Account { Id = 3, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, User_Id = 1 },
                new Account { Id = 4, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, User_Id = 1 },
                new Account { Id = 5, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, User_Id = 1 },
                new Account { Id = 6, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, User_Id = 1 },
                new Account { Id = 7, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, User_Id = 1 },
                new Account { Id = 8, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, User_Id = 1 },
                new Account { Id = 9, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, User_Id = 1 }
            };
        }
    }
}
