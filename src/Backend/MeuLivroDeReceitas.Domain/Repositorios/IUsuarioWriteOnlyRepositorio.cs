using MeuLivroDeReceitas.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Domain.Repositorios;

public interface IUsuarioWriteOnlyRepositorio
{
    Task Adicionar(Usuario usuario);
}
