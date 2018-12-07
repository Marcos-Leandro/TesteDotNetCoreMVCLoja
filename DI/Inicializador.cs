using Data;
using Domain;
using Domain.Produtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DI
{
    public class Inicializador
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<Context>(options => options.UseSqlServer(connectionString));
            services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));
            services.AddScoped(typeof(CategoriaArmazenar));
        }
    }
}
