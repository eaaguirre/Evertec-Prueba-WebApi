using Evertec.Prueba.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evertec.Prueba.UnitOfWork
{
    public  interface IUnitOfWork
    {
        IEmployeeRepository Employee { get; }
        IUserRepository User { get; }   
        IMaritalStatusRepository MaritalStatus { get; }
    }
}
