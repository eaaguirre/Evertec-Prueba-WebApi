using Evertec.Prueba.Models;

namespace Evertec.Prueba.Repositories
{
    public  interface IEmployeeRepository:IRepository<Employee>
    {
        Task<IEnumerable<EmployeeDto>> EmployeePagegList(int page, int rows);
        Task<IEnumerable<Employee>> InsertEmployeeAsync(Employee employee);
        Task<IEnumerable<EmployeeDto>> GetEmployeeByIdAsync(int id);

        Task<IEnumerable<Employee>> UpdateEmployeeAsync(Employee entity);
    }
}
