using Wall_Net.Models;

namespace Wall_Net.DataAccess.SeedsData
{
    public static class RoleSeed
    {
        public static List<Roles> GetRoles()
        {
            return new List<Roles>
            {
                new Roles { Id = 1, Name = "Admin", Description = "Encargado de agregar y borrar usuarios" },
                new Roles { Id = 2, Name = "Regular", Description = "Cliente nuevo" },
                new Roles { Id = 3, Name = "Admin", Description = "Administrador de las transacciones" },
                new Roles { Id = 4, Name = "Regular", Description = "Cliente antiguo" }
            };
        }
    }
}
