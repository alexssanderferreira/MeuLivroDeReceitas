﻿using MeuLivroDeReceitas.Domain.Entidades;
using MeuLivroDeReceitas.Domain.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace MeuLivroDeReceitas.Infrastructure.Acesso_Repositorio;

public class UsuarioRepositorio : IUsuarioReadOnlyRepositorio, IUsuarioWriteOnlyRepositorio
{
    private readonly MeuLivroDeReceitasContext _context;

    public UsuarioRepositorio(MeuLivroDeReceitasContext context)
    {
        _context = context;
    }

    public async Task Adicionar(Usuario usuario)
    {
        await _context.Usuarios.AddAsync(usuario);
    }

    public async Task<bool> ExisteUsuarioComEmail(string email)
    {
        return await _context.Usuarios.AnyAsync(u => u.Email.Equals(email));
    }
}
