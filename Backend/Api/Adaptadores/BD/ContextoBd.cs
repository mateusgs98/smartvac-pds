using Microsoft.EntityFrameworkCore;
using Api.Adaptadores.BD.Entidades;

namespace Api.Adaptadores.BD
{
    public class ContextoBd : DbContext
    {
        public ContextoBd(DbContextOptions<ContextoBd> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<TipoImunizacao> TiposImunizacao { get; set; }

        public DbSet<Sintoma> Sintomas { get; set; }

        public DbSet<Doenca> Doencas { get; set; }

        public DbSet<Vacina> Vacinas { get; set; }
    }
}