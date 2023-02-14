using MeuLivroDeReceitas.Application.Servico.Criptografia;
using MeuLivroDeReceitas.Application.Servico.Token;
using MeuLivroDeReceitas.Application.UseCases.Usuario.Registrar;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MeuLivroDeReceitas.Application;

public static class Bootstrapper
{
    public static void AddApplication(this IServiceCollection services, IConfiguration config)
    {
        AdicionarChaveAdicionalSenha(services, config);
        AdicionarTokenJWT(services, config);

        services.AddScoped<IRegistrarUsuarioUseCase, RegistrarUsuarioUseCase>();
    }

    private static void AdicionarChaveAdicionalSenha(this IServiceCollection services, IConfiguration config)
    {
        var section = config.GetRequiredSection("Configuracoes:ChaveAdicionalSenha");

        services.AddScoped(opt => new EncriptadorDeSenha(section.Value));
    }

    private static void AdicionarTokenJWT(this IServiceCollection services, IConfiguration config)
    {
        var sectionTempoDeVida = config.GetRequiredSection("Configuracoes:TempoVidaToken");
        var sectionKey = config.GetRequiredSection("Configuracoes:ChaveToken");

        services.AddScoped(opt => new TokenController(int.Parse(sectionTempoDeVida.Value), sectionKey.Value));
    }
}
