using Wall_Net.Models;

namespace Wall_Net.DataAccess.SeedsData
{
    public static class UserSeed
    {
        public static List<User> GetUsers()
        {
            return new List<User>
        {
            new User
            {
                Id = 1,
                FirstName = "Leandro",
                LastName = "Mumbach",
                Email = "lean@email.com",
                Password = "123456",
                Points = 20,
                Rol_Id = 1,
            },
            new User
            {
                Id = 2,
                FirstName = "Pepe",
                LastName = "Gonzalez",
                Email = "pepe@email.com",
                Password = "123456",
                Points = 20,
                Rol_Id = 2,
            }
        };
        }
    }
}
