using System.Diagnostics;
using Dominio.Portas.Entrada;
using Api.Adaptadores.BD;
using Entidades = Api.Adaptadores.BD.Entidades;
using DTOs = Dominio.DTOs;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Api.Adaptadores.BD.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly ContextoBd _contextoBd;

        public RepositorioUsuario(ContextoBd contextoBd)
        {
            _contextoBd = contextoBd ?? throw new ArgumentNullException(nameof(contextoBd));
        }

        public async Task<DTOs.Usuario> ObterUsuario(int id)
        {
            var usuario = await _contextoBd.Usuarios.FindAsync(id);

            return new DTOs.Usuario
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                Paciente = usuario.Paciente,
                DataNascimento = usuario.DataNascimento
            };
        }

        public async Task<DTOs.Usuario> ObterUsuario(string email, string senha)
        {
            var usuario = await _contextoBd.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);
            if (usuario == null)
                return null;

            return new DTOs.Usuario
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                Paciente = usuario.Paciente,
                DataNascimento = usuario.DataNascimento
            };
        }

        public async Task<DTOs.Usuario> CadastrarUsuario(DTOs.Usuario usuario)
        {
            var entidadeUsuario = new Entidades.Usuario
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha,
                Paciente = usuario.Paciente.Value,
                DataNascimento = usuario.DataNascimento
            };

            await _contextoBd.Usuarios.AddAsync(entidadeUsuario);
            await _contextoBd.SaveChangesAsync();

            usuario.Id = entidadeUsuario.Id;

            return usuario;
        }
    }
}