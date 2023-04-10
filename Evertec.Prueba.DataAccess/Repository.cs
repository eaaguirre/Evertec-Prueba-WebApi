using Dapper.Contrib.Extensions;
using Evertec.Prueba.Repositories;
using System.Data.SqlClient;

namespace Evertec.Prueba.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected string _connectionString;
        public Repository( string connectionString)
        {
            SqlMapperExtensions.TableNameMapper = (Type) => { return $"{Type.Name} "; };
            _connectionString=connectionString;
        }
        #region "Asynn Methods"
        public async Task<bool> DeleteAsync(TEntity entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.DeleteAsync(entity);
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.GetAllAsync<TEntity>();
            }
        }

        public async Task<TEntity> GetAsynByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await  connection.GetAsync<TEntity>(id);
            }
        }

        public async  Task<int> InsertAsync(TEntity entity)
        {
             using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.InsertAsync(entity);
            }
        }

        public  async Task<bool> UpdateAsync(TEntity entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.UpdateAsync(entity);
            }
        }

        #endregion
    }
}
