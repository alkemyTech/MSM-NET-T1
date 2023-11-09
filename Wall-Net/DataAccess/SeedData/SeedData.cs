using Wall_Net.Models;

namespace Wall_Net.DataAccess.SeedData
{
    public class SeedData
    {
        public static List<Transaction> SeedsTransaction()
        {
            return new List<Transaction>
            {
                new Transaction { TransactionId = 1, Amount = 100.00m, Concept = "Ejemplo de transacción 1", Date = DateTime.Now, Type = "topup", AccountId = 1, UserId = 1 },
                new Transaction { TransactionId = 1, Amount = 100.00m, Concept = "Ejemplo de transacción 1", Date = DateTime.Now, Type = "topup", AccountId = 1, UserId = 1 },
                new Transaction { TransactionId = 1, Amount = 100.00m, Concept = "Ejemplo de transacción 1", Date = DateTime.Now, Type = "topup", AccountId = 1, UserId = 1 },
                new Transaction { TransactionId = 1, Amount = 100.00m, Concept = "Ejemplo de transacción 1", Date = DateTime.Now, Type = "topup", AccountId = 1, UserId = 1 }
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
