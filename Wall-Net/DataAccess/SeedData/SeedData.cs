using Microsoft.EntityFrameworkCore;
using Wall_Net.Models;

namespace Wall_Net.DataAccess.SeedData
{
    public class SeedData
    {

       public static List<Roles> SeedsRoles()
        public static List<Transaction> SeedsTransaction()
        {
            return new List<Roles>
            return new List<Transaction>
            {
                new Roles { Id = 1, Name = "Admin", Description = "Encargado de agregar y borrar usuarios" },
                new Roles { Id = 2, Name = "Regular", Description = "Cliente nuevo" },
                new Roles { Id = 3, Name = "Admin", Description = "Administrador de las transacciones" },
                new Roles { Id = 4, Name = "Regular", Description = "Cliente antiguo" }
                new Transaction { TransactionId = 1, Amount = 100.00m, Concept = "Ejemplo de transacción 1", Date = DateTime.Now, Type = "topup", AccountId = 1, UserId = 1 },
                new Transaction { TransactionId = 1, Amount = 100.00m, Concept = "Ejemplo de transacción 1", Date = DateTime.Now, Type = "topup", AccountId = 1, UserId = 1 },
                new Transaction { TransactionId = 1, Amount = 100.00m, Concept = "Ejemplo de transacción 1", Date = DateTime.Now, Type = "topup", AccountId = 1, UserId = 1 },
                new Transaction { TransactionId = 1, Amount = 100.00m, Concept = "Ejemplo de transacción 1", Date = DateTime.Now, Type = "topup", AccountId = 1, UserId = 1 }
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

        public static List<FixedTermDeposit> SeedsFixed()
        public static List<Catalogue> SeedsCatalogue()
        {
            return new List<FixedTermDeposit>
            return new List<Catalogue>
            {
                new FixedTermDeposit{Id=1,user_id=1,account_id=1,amount=100,creation_date=new DateTime(2001,2,3),closing_date=new DateTime(2001,3,3),nominalRate=12,state="Inmovilizado"},
                new FixedTermDeposit { Id =2, user_id =2, account_id =2, amount =150, creation_date = new DateTime(2001, 3, 4),closing_date=DateTime.Now, nominalRate =5, state ="Activo"},
                new FixedTermDeposit { Id =3, user_id =2, account_id =3, amount =200, creation_date = new DateTime(2001, 5, 6),closing_date=DateTime.Now, nominalRate =12, state ="Activo"},
                new FixedTermDeposit { Id =4, user_id =1, account_id =4, amount =250, creation_date = new DateTime(2007, 7, 7), closing_date = new DateTime(2008, 7, 7), nominalRate =17, state ="Invomilizado"}
                new Catalogue {Id=1,ProductDescription = "Producto 1",Image = "imagen1.jpg",Points = 100},
                new Catalogue {Id=2,ProductDescription = "Producto 2",Image = "imagen2.jpg",Points = 90},
                new Catalogue {Id=3,ProductDescription = "Producto 3",Image = "imagen3.jpg",Points = 80},
                new Catalogue {Id=4,ProductDescription = "Producto 4",Image = "imagen4.jpg",Points = 70}
        };
        }

    }
}
