using Evertec.Prueba.Models;
using Microsoft.IdentityModel.Tokens;

namespace Evertec.Prueba.WebApi.Autentication
{
    public interface ITokenProvider
    {
        string CreateToken(User user, DateTime expire);
        TokenValidationParameters GetValidationParameters();
    }
}
