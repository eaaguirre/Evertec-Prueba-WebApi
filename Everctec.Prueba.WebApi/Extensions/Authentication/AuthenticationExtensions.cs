using Evertec.Prueba.WebApi.Autentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Evertec.Prueba.WebApi.Extensions.Authentication
{
    public  static class AuthenticationExtensions
    {
        public static IServiceCollection  AddAuthenticationToken(this IServiceCollection services)
        {

            var tokenProvider = new JwtProvider("issuer", "audience", "evertec_prueba");
            services.AddSingleton<ITokenProvider>(tokenProvider);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = tokenProvider.GetValidationParameters();
                });


            services.AddAuthorization(auth =>
            {
                auth.DefaultPolicy = new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
                
            });

            return services;

        }
        
    }
}
