using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuLivroDeReceitas.Domain.Repositorios;

public interface IUsuarioReadOnlyRepositorio
{
    Task<bool> ExisteUsuarioComEmail(string email);
}
