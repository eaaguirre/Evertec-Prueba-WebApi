using Evertec.Prueba.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Evertec.Prueba.WebApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class MaritalStatusController : Controller
    {
       
        private readonly IUnitOfWork _unitOfWork;

        public MaritalStatusController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllMaritalStatus()
        {
            return Ok(await _unitOfWork.MaritalStatus.GetAllAsync());
        }
    }
}
