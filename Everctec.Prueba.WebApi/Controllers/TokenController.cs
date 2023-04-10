using Evertec.Prueba.Models;
using Evertec.Prueba.UnitOfWork;
using Evertec.Prueba.WebApi.Autentication;
using Microsoft.AspNetCore.Mvc;

namespace Evertec.Prueba.WebApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class TokenController : Controller
    {
        private ITokenProvider _tokenProvider;
        private IUnitOfWork _unitOfWork;

        
        public TokenController(ITokenProvider tokenProvider, IUnitOfWork unitOfWork)
        {
            _tokenProvider = tokenProvider;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("GetToken")]
        public JsonWebToken GetToken([FromBody] User userLogin)
        {
            var user = _unitOfWork.User.ValidateUser(userLogin.Email, userLogin.Password);
            if (user.Data ==null)
                throw new UnauthorizedAccessException($"User Or Password Is Missing");

            var token = new JsonWebToken
            {
                Access_Token = _tokenProvider.CreateToken(user.Data,DateTime.UtcNow.AddMinutes(10)),
                Expires_in = 10//minutos

            };
            return token;

        }
    }
}
