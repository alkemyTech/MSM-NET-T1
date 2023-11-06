using System;
using System.Collections.Generic;
using Wall_Net.Models;

namespace Wall_Net.Seeders
{
    public class AccountsSeeds
    {
        public static List<Account> SeedsAcounts()
        {
            List<Account> accounts = new List<Account>()
            {
                new Account
                {
                    creationDate = DateTime.Now,
                    money = 1000,
                    isBlocked = false,
                    user_Id = 1
                },
                new Account
                {
                    creationDate = DateTime.Now,
                    money = 500,
                    isBlocked = true,
                    user_Id = 2
                },
                new Account
                {
                    creationDate = DateTime.Now,
                    money = 750,
                    isBlocked = false,
                    user_Id = 3
                },
                new Account
                {
                    creationDate = DateTime.Now,
                    money = 2000,
                    isBlocked = false,
                    user_Id = 4
                },
                new Account
                {
                    creationDate = DateTime.Now,
                    money = 300,
                    isBlocked = true,
                    user_Id = 5
                }
            };
            Console.WriteLine("Hola");
            return accounts;
        }
    }
}
