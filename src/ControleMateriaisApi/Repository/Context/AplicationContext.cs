using ControleMateriaisApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace ControleMateriaisApi.Repository.Context
{
    public class AplicationContext:DbContext
    {
        public AplicationContext( DbContextOptions<AplicationContext> options) : base(options)    
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Polo> Polos { get; set; }
        public DbSet<Material> Materiais { get; set; }
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<Saida> Saidas { get; set; }
        public DbSet<EntradaMaterial> EntradasMateriais { get; set; }
        public DbSet<SaidaMaterial> SaidasMateriais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
