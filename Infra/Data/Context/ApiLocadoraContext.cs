namespace Locadora.Infra.Data.Context
{
    using Locadora.Entities;
    using Locadora.Infra.Data.Mapping;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public class LocadoraContext : DbContext
    {

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Locacao> Locacao { get; set; }
        public virtual DbSet<LocacaoItem> LocacaoItens { get; set; }
        public virtual DbSet<Filme> Filmes { get; set; }

        private readonly IConfiguration configuration;

        public LocadoraContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public LocadoraContext(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder == null || !optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=WELLINGTON-HP\\SQLEXPRESS;Initial Catalog=locadora;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(new ClienteMap().Configure);
            modelBuilder.Entity<Locacao>(new LocacaoMap().Configure);
            modelBuilder.Entity<LocacaoItem>(new LocacaoItemMap().Configure);
            modelBuilder.Entity<Filme>(new FilmeMap().Configure);
        }
    }
}
