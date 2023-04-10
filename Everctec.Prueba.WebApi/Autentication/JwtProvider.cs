using Evertec.Prueba.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Evertec.Prueba.WebApi.Autentication
{
    public class JwtProvider : ITokenProvider
    {
        private  RsaSecurityKey _key;
        private  string _algoritm;
        private  string _issuer;
        private  string _audicence;
        public JwtProvider(string issuer,string audience,string keyname)
        {
            var parameters = new CspParameters() { KeyContainerName = keyname };
            var provider = new RSACryptoServiceProvider(2048, parameters);
            _key = new RsaSecurityKey(provider);
            _algoritm = SecurityAlgorithms.RsaSha256Signature;
            _issuer = issuer;
            _audicence = audience;

        }
        public string CreateToken(User user, DateTime expire)
        {
           JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var identity = new ClaimsIdentity(new List<Claim>()
            {
                new Claim(ClaimTypes.Name ,$"{user.FirstName} {user.LastName}"),
                new Claim (ClaimTypes.PrimarySid,user.Id.ToString())
            }, "custom");

            SecurityToken token = tokenHandler.CreateJwtSecurityToken(new SecurityTokenDescriptor
            {
                Audience = _audicence,
                Issuer = _issuer,
                SigningCredentials = new SigningCredentials(_key, _algoritm),
                Expires = expire.ToUniversalTime(),
                Subject = identity

            }) ;

            return  tokenHandler.WriteToken(token);
        }
/// <inheritdoc/>

        public TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters
            {
                IssuerSigningKey = _key,
                ValidAudience = _audicence,
                ValidIssuer = _issuer,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromSeconds(0)
            };
        }
    }
}
