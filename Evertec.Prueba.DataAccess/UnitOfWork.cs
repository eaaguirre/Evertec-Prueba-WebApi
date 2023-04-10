using Evertec.Prueba.Repositories;
using Evertec.Prueba.UnitOfWork;

namespace Evertec.Prueba.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(string connectionsString )
        {
            Employee = new EmployeeRepository(connectionsString);
            User= new UserRepository(connectionsString);
            MaritalStatus = new MaritalStatusRepository(connectionsString);
        }
        public IEmployeeRepository Employee { get;  private set; }

        public IUserRepository User { get; private set; }

        public IMaritalStatusRepository MaritalStatus { get; private set; }
    }
}
