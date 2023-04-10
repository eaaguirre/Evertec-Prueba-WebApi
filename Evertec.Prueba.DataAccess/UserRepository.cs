using Dapper;
using Evertec.Prueba.Models;
using Evertec.Prueba.Repositories;
using System.Data.SqlClient;

namespace Evertec.Prueba.DataAccess
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString)
        {
        }

        public Response<User> ValidateUser(string email, string password)
        {
            var response = new Response<User>();
            var parameters = new DynamicParameters();
            parameters.Add("@email", email);
            parameters.Add("@password", password);

            using (var cn = new SqlConnection(_connectionString))
            {
                try
                {
                    var data = cn.QueryFirstOrDefault<User>("dbo.ValidateUser", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    response.Data = data;
                    response.IsSucces = true;
                    response.Message = "Usuario Autenticado con Exito";
                }
                catch (InvalidOperationException e)
                {
                    response.IsSucces = true;
                    response.Message = "Usuario no encontrado";
                }
                catch (Exception ex)
                {
                    response.Message = ex.Message;

                }

               
            }
            return response;
        }
    }
}
