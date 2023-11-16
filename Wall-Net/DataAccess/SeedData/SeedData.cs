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
                new Account { Id = 1, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, User_Id = 1 },
                new Account { Id = 2, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, User_Id = 2 },
                new Account { Id = 3, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, User_Id = 3 },
                new Account { Id = 4, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, User_Id = 4 },
                new Account { Id = 5, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, User_Id = 5 },
                new Account { Id = 6, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, User_Id = 6 },
                new Account { Id = 7, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, User_Id = 7 },
                new Account { Id = 8, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, User_Id = 8 },
                new Account { Id = 9, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, User_Id = 9 }
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
                new User
                {Id = 1, FirstName = "Leandro", LastName = "Mumbach" ,Email = "lean@email.com" ,Password = "123456", Points = 20, Rol_Id = 1,},
                new User {Id = 2, FirstName = "Pepe", LastName = "Gonzalez", Email = "pepe@email.com", Password = "123456", Points = 20, Rol_Id = 1,},
                new User{Id = 3, FirstName = "Sandra", LastName = "Gonzalez", Email = "sandra@email.com", Password = "123456", Points = 20, Rol_Id = 1,},
                new User{Id = 4, FirstName = "Juan", LastName = "Gonzalez", Email = "juan@email.com", Password = "123456", Points = 20, Rol_Id = 1,},
                new User{Id = 5, FirstName = "Martin", LastName = "Gonzalez", Email = "martin@email.com", Password = "123456", Points = 20, Rol_Id = 2,},
                new User{Id = 6, FirstName = "Fede", LastName = "Gonzalez", Email = "fede@email.com", Password = "123456", Points = 20, Rol_Id = 2,},
                new User{Id = 7, FirstName = "Jose", LastName = "Gonzalez", Email = "jose@email.com", Password = "123456", Points = 20, Rol_Id = 2,},
                new User{Id = 8, FirstName = "Mica", LastName = "Gonzalez", Email = "mica@email.com", Password = "123456", Points = 20, Rol_Id = 2,},
                new User{Id = 9, FirstName = "Sofia", LastName = "Gonzalez", Email = "sofia@email.com", Password = "123456", Points = 20, Rol_Id = 2,}
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












    