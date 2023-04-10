using Evertec.Prueba.Models;

namespace Evertec.Prueba.Repositories
{
    public  interface IUserRepository:IRepository<User>
    {
        Response<User> ValidateUser(string email, string password);
    }
}
