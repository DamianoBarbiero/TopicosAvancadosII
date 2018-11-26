using Microsoft.EntityFrameworkCore;
using MvcControleJogo.Models;

namespace MvcControleJogo.Models
{
    public class MvcClienteContext : DbContext
    {
        public MvcClienteContext (DbContextOptions<MvcClienteContext> options)
            : base(options)
        {
        }

        public DbSet<MvcControleJogo.Models.Cliente> Cliente { get; set; }

        public DbSet<MvcControleJogo.Models.Empresa> Empresa { get; set; }

        public DbSet<MvcControleJogo.Models.Plataforma> Plataforma { get; set; }

        public DbSet<MvcControleJogo.Models.Jogos> Jogos { get; set; }

        public DbSet<MvcControleJogo.Models.ClienteJogo> ClienteJogo { get; set; }

        public DbSet<MvcControleJogo.Models.Categoria> Categoria { get; set; }
    }
}