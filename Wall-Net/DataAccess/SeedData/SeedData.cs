using Wall_Net.Models;

namespace Wall_Net.DataAccess.SeedData
{
    public class SeedData
    {
        public static List<Roles> GetRoles()
        {
            return new List<Roles>
            {
                new Roles{Name="Admin", Description="Encargado de agregar y borrar usuarios"},
                new Roles{Name="Regular", Description="Cliente nuevo"},
                new Roles{Name="Admin", Description="Administrador de las transacciones"},
                new Roles{Name="Regular", Description="Cliente antiguo"}
            };
        }
    }
}
