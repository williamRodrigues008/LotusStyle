using LotusStyle.API.Datas;
using LotusStyle.API.Interfaces;
using LotusStyle.API.Services;
using Microsoft.EntityFrameworkCore;

namespace LotusStyle.API
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection Infraestrutura(this IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<DbContexto>(op =>
            {
                op.UseSqlServer(config.GetConnectionString("ConnectionString"),
                    m => m.MigrationsAssembly(typeof(DbContexto).Assembly.FullName));
            });

            service.AddScoped<ILeituraEscritaProduto, ProdutosService>();

            return service;
        }
    }
}
