using Evertec.Prueba.Models;
using Evertec.Prueba.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Evertec.Prueba.WebApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
   [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }
        [HttpGet("GetByIdAsync/{Id}")]
        public  async Task<IActionResult> GetByIdAsync(int Id)
        {
            return Ok(  await _unitOfWork.Employee.GetEmployeeByIdAsync(Id));
        }
        [HttpPost("InsertAsync")]
        public async Task<IActionResult> InsertAsync([FromBody]Employee employee)
        {
            if (!ModelState.IsValid) return BadRequest();
            return Ok( await _unitOfWork.Employee.InsertEmployeeAsync(employee));
        }

        [HttpPut("UpdateAsync")]
        public async  Task<IActionResult> UpdateAsync([FromBody] Employee employee)
        {
            if (ModelState.IsValid &&   await _unitOfWork.Employee.UpdateEmployeeAsync(employee) != null )
            {
                return Ok(new { Message = "The Employee is Updated" });
            }
            return BadRequest();
        }

        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleleteAsync([FromBody] EmployeeDto employee)
        {
            if (employee.Id> 0)
                return Ok(await _unitOfWork.Employee.DeleteAsync(employee));


            return BadRequest();
            
        }
        [HttpGet("GetPaginatedEmployee/{page:int}/{rows:int}")]
        public async Task<IActionResult> GetPaginatedEmployee(int page, int rows)
        {
            return Ok(await _unitOfWork.Employee.EmployeePagegList(page,rows));
        }


    }
}
