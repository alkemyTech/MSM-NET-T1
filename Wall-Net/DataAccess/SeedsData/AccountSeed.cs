using Wall_Net.Models;

namespace Wall_Net.DataAccess.SeedsData
{
    public static class AccountSeed
    {
        public static List<Account> GetAccounts()
        {
            return new List<Account>
            {
                new Account {Id=1, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 1},
                new Account {Id=2, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 1},
                new Account {Id=3, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 1},
                new Account {Id=4, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 1},
                new Account {Id=5, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 1},
                new Account {Id=6, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 1},
                new Account {Id=7, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 1},
                new Account {Id=8, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 1},
                new Account {Id=9, CreationDate = DateTime.Now, Money = 1000, IsBlocked = false, UserId = 1}
            };
        }
    }
}
