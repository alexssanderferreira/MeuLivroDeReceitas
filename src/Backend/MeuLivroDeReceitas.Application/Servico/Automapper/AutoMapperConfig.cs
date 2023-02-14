using AutoMapper;
using MeuLivroDeReceitas.Comunicacao.Request;
using MeuLivroDeReceitas.Comunicacao.Response;
using MeuLivroDeReceitas.Domain.Entidades;

namespace MeuLivroDeReceitas.Application.Servico.Automapper;

public class AutoMapperConfig: Profile
{
	public AutoMapperConfig()
	{
		CreateMap<RequestRegistrarUsuarioJson,Usuario>()
			.ForMember(destino => destino.Senha, config => config.Ignore());
        CreateMap<Usuario , RespostaUsuarioRegistradoJson>();
    }
}
