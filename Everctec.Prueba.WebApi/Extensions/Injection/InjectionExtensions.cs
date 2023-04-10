using Evertec.Prueba.UnitOfWork;
namespace Evertec.Prueba.WebApi.Extensions.Injection
{
    public static  class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);

            services.AddSingleton<IUnitOfWork>(option => new Evertec.Prueba.DataAccess.UnitOfWork(configuration.GetConnectionString("EvertecConnection")));
;
            return services;
        }
    }
}
