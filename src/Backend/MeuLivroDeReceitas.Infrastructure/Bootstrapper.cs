using FluentMigrator.Runner;
using MeuLivroDeReceitas.Domain.Extension;
using MeuLivroDeReceitas.Domain.Repositorios;
using MeuLivroDeReceitas.Infrastructure.Acesso_Repositorio;
using MeuLivroDeReceitas.Infrastructure.Acesso_Repositorio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MeuLivroDeReceitas.Infrastructure;

public static class Bootstrapper
{
    public static void AddRepositorio(this IServiceCollection services, IConfiguration configurationManager) 
    {
        AddFluentMigrator(services, configurationManager);

        AddContext(services, configurationManager);
        AddUnidadeDeTrabalho(services);
        AddRepositorios(services);
    }

    private static void AddContext(IServiceCollection service, IConfiguration configurationManager)
    {
        var versaoServidor = new MySqlServerVersion(new Version(8,0,32));
        var connectionString = configurationManager.GetConexaoCompleta();

        service.AddDbContext<MeuLivroDeReceitasContext>(dbContextOptions =>
        {
            dbContextOptions.UseMySql(connectionString, versaoServidor);
        });
    }

    private static void AddUnidadeDeTrabalho(IServiceCollection services)
    {
        services.AddScoped<IUnidadeDeTrabalho, UnidadeDeTrabalho>();
    }

    private static void AddRepositorios(IServiceCollection services)
    {
        services.AddScoped<IUsuarioWriteOnlyRepositorio, UsuarioRepositorio>()
                .AddScoped<IUsuarioReadOnlyRepositorio, UsuarioRepositorio>();
    }

    private static void AddFluentMigrator(IServiceCollection services, IConfiguration configurationManager)
    {
        services.AddFluentMigratorCore().ConfigureRunner(c => c.AddMySql5().WithGlobalConnectionString(configurationManager.GetConexaoCompleta()).ScanIn(Assembly.Load("MeuLivroDeReceitas.Infrastructure")).For.All());
    }
}
