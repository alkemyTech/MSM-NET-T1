using Microsoft.EntityFrameworkCore;
using Wall_Net.Models;

namespace Wall_Net.DataAccess.SeedData
{
    public class SeedData
    {
<<<<<<< HEAD
        public static List<Roles> SeedsRoles()
=======
        public static List<Account> SeedsAcounts()
>>>>>>> origin/main
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
        {
            return new List<FixedTermDeposit>
            {
                new FixedTermDeposit{Id=1,user_id=1,account_id=1,amount=100,creation_date=new DateTime(2001,2,3),closing_date=new DateTime(2001,3,3),nominalRate=12,state="Inmovilizado"},
                new FixedTermDeposit { Id =2, user_id =2, account_id =2, amount =150, creation_date = new DateTime(2001, 3, 4),closing_date=DateTime.Now, nominalRate =5, state ="Activo"},
                new FixedTermDeposit { Id =3, user_id =2, account_id =3, amount =200, creation_date = new DateTime(2001, 5, 6),closing_date=DateTime.Now, nominalRate =12, state ="Activo"},
                new FixedTermDeposit { Id =4, user_id =1, account_id =4, amount =250, creation_date = new DateTime(2007, 7, 7), closing_date = new DateTime(2008, 7, 7), nominalRate =17, state ="Invomilizado"}
        };
        }

    }
}
