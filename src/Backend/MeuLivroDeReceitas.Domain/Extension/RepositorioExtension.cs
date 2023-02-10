 using Microsoft.Extensions.Configuration;

namespace MeuLivroDeReceitas.Domain.Extension;

public static class RepositorioExtension
{
     public static string GetConexao(this IConfiguration configurationManager)
    {
        var conexao = configurationManager.GetConnectionString("Conexao");

        return conexao;
    }

    public static string GetNomeDatabase(this IConfiguration configurationManager)
    {
        var nomeDatabase = configurationManager.GetConnectionString("NomeDatabase");

        return nomeDatabase;
    }

    public static string GetConexaoCompleta(this IConfiguration configurationManager)
    {
        return $"{configurationManager.GetConexao()}Database={configurationManager.GetNomeDatabase()}";
    }
}
