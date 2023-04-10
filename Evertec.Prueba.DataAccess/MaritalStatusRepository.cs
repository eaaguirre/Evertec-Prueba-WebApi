using Evertec.Prueba.Models;
using Evertec.Prueba.Repositories;

namespace Evertec.Prueba.DataAccess
{
    public class MaritalStatusRepository : Repository<MaritalStatus>, IMaritalStatusRepository
    {
        public MaritalStatusRepository(string connectionString) : base(connectionString) { }

        
    }
}
