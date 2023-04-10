using System.Threading.Tasks;
namespace Evertec.Prueba.Repositories
{
    public  interface IRepository<TEntity> where TEntity : class
    {
        #region "Async Methods"

        Task<bool> DeleteAsync(TEntity entiry);
        Task<bool> UpdateAsync(TEntity entity);

        Task<int> InsertAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsynByIdAsync(int id);

        #endregion
    }
}
