using System.Security.Cryptography;
using System.Text;

namespace MeuLivroDeReceitas.Application.Servico.Criptografia;

public class EncriptadorDeSenha
{
    private readonly string _chaveDeEncriptaçao;

    public EncriptadorDeSenha(string chaveDeEncriptaçao)
    {
        _chaveDeEncriptaçao = chaveDeEncriptaçao;
    }

    public string Criptografar(string senha)
    {
        var senhaComChaveAdicional = $"{senha}{_chaveDeEncriptaçao}";

        var bytes = Encoding.UTF8.GetBytes(senhaComChaveAdicional);
        var sha512 = SHA512.Create();
        byte[] hashBytes = sha512.ComputeHash(bytes);
        return StringBytes(hashBytes);
    }

    private static string StringBytes(byte[] bytes)
    {
        var sb = new StringBuilder();
        foreach (byte b in bytes)
        {
            var hex = b.ToString("x2");
            sb.Append(hex);
        }
        return sb.ToString();
    }
}
