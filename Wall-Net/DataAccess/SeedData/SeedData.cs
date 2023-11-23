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
        public static List<Account> SeedsAcounts()
        {
            return new List<Account>
            {
                new Account { Id = 1, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 1 },
                new Account { Id = 2, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 2 },
                new Account { Id = 3, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 3 },
                new Account { Id = 4, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 4 },
                new Account { Id = 5, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 5 },
                new Account { Id = 6, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 6 },
                new Account { Id = 7, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 7 },
                new Account { Id = 8, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 8 },
                new Account { Id = 9, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 9 },
                new Account { Id = 10, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 10 }
            };
        }

        public static List<FixedTermDeposit> SeedsFixed()
        {
            return new List<FixedTermDeposit>
            {
                new FixedTermDeposit{Id=1,UserId=1,AccountId=1,amount=100,creation_date=new DateTime(2001,2,3),closing_date=new DateTime(2001,3,3),nominalRate=12,state="Inmovilizado"},
                new FixedTermDeposit { Id =2, UserId =2, AccountId =2, amount =150, creation_date = new DateTime(2001, 3, 4),closing_date=DateTime.Now, nominalRate =5, state ="Activo"},
                new FixedTermDeposit { Id =3, UserId =2, AccountId =3, amount =200, creation_date = new DateTime(2001, 5, 6),closing_date=DateTime.Now, nominalRate =12, state ="Activo"},
                new FixedTermDeposit { Id =4, UserId =1, AccountId =4, amount =250, creation_date = new DateTime(2007, 7, 7), closing_date = new DateTime(2008, 7, 7), nominalRate =17, state ="Invomilizado"}
        };
        }

        public static List<User> SeedsUsers()
        {
            return new List<User>
                {
                new User { Id = 1, FirstName = "Leandro", LastName = "Mumbach", Email = "lean@email.com", Password = BCrypt.Net.BCrypt.HashPassword("123456"), Points = 20, Rol_Id = 1 },
                new User { Id = 2, FirstName = "Pepe", LastName = "Gonzalez", Email = "pepe@email.com", Password = BCrypt.Net.BCrypt.HashPassword("123456"), Points = 20, Rol_Id = 1 },
                new User { Id = 3, FirstName = "Ana", LastName = "Lopez", Email = "ana@email.com", Password = BCrypt.Net.BCrypt.HashPassword("123456"), Points = 25, Rol_Id = 2 },
                new User { Id = 4, FirstName = "Carlos", LastName = "Martinez", Email = "carlos@email.com", Password = BCrypt.Net.BCrypt.HashPassword("123456"), Points = 18, Rol_Id = 1 },
                new User { Id = 5, FirstName = "Maria", LastName = "Rodriguez", Email = "maria@email.com", Password = BCrypt.Net.BCrypt.HashPassword("123456"), Points = 22, Rol_Id = 2 },
                new User { Id = 6, FirstName = "Juan", LastName = "Perez", Email = "juan@email.com", Password = BCrypt.Net.BCrypt.HashPassword("123456"), Points = 19, Rol_Id = 1 },
                new User { Id = 7, FirstName = "Laura", LastName = "Fernandez", Email = "laura@email.com", Password = BCrypt.Net.BCrypt.HashPassword("123456"), Points = 24, Rol_Id = 2 },
                new User { Id = 8, FirstName = "Diego", LastName = "Gomez", Email = "diego@email.com", Password = BCrypt.Net.BCrypt.HashPassword("123456"), Points = 21, Rol_Id = 1 },
                new User { Id = 9, FirstName = "Carmen", LastName = "Ruiz", Email = "carmen@email.com", Password = BCrypt.Net.BCrypt.HashPassword("123456"), Points = 20, Rol_Id = 2 },
                new User { Id = 10, FirstName = "Sergio", LastName = "Lopez", Email = "sergio@email.com", Password = BCrypt.Net.BCrypt.HashPassword("123456"), Points = 23, Rol_Id = 1 },
                new User { Id = 11, FirstName = "Luisa", LastName = "Garcia", Email = "luisa@email.com", Password = BCrypt.Net.BCrypt.HashPassword("123456"), Points = 19, Rol_Id = 2 },
                new User { Id = 12, FirstName = "Alejandro", LastName = "Sanchez", Email = "alejandro@email.com", Password = BCrypt.Net.BCrypt.HashPassword("123456"), Points = 18, Rol_Id = 1 },
                new User { Id = 13, FirstName = "Martina", LastName = "Hernandez", Email = "martina@email.com", Password = BCrypt.Net.BCrypt.HashPassword("123456"), Points = 22, Rol_Id = 2 },
                new User { Id = 14, FirstName = "Roberto", LastName = "Diaz", Email = "roberto@email.com", Password = BCrypt.Net.BCrypt.HashPassword("123456"), Points = 25, Rol_Id = 1 },
                new User { Id = 15, FirstName = "Isabel", LastName = "Flores", Email = "isabel@email.com", Password = BCrypt.Net.BCrypt.HashPassword("123456"), Points = 20, Rol_Id = 2 },
                };
        }
        public static List<Transaction> SeedsTransaction()
        {
            return new List<Transaction>
            {
                new Transaction { TransactionId = 1, Amount = 100.00m, Concept = "Ejemplo de transacción 1", Date = DateTime.Now, Type = "topup", AccountId = 1, UserId = 1 },
                new Transaction { TransactionId = 2, Amount = 100.00m, Concept = "Ejemplo de transacción 1", Date = DateTime.Now, Type = "topup", AccountId = 1, UserId = 1 },
                new Transaction { TransactionId = 3, Amount = 100.00m, Concept = "Ejemplo de transacción 1", Date = DateTime.Now, Type = "topup", AccountId = 1, UserId = 1 },
                new Transaction { TransactionId = 4, Amount = 100.00m, Concept = "Ejemplo de transacción 1", Date = DateTime.Now, Type = "topup", AccountId = 1, UserId = 1 }
            };
        }

        public static List<Catalogue> SeedsCatalogue()
        {
            return new List<Catalogue>
            {
                new Catalogue {Id=1,ProductDescription = "Producto 1",Image = "imagen1.jpg",Points = 100},
                new Catalogue {Id=2,ProductDescription = "Producto 2",Image = "imagen2.jpg",Points = 90},
                new Catalogue {Id=3,ProductDescription = "Producto 3",Image = "imagen3.jpg",Points = 80},
                new Catalogue {Id=4,ProductDescription = "Producto 4",Image = "imagen4.jpg",Points = 70}
        };
        }
    }
}












    