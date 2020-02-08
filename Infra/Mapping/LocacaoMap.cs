namespace Locadora.Infra.Data.Mapping
{
    using Locadora.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class LocacaoMap : BaseEntityConfiguration<Locacao>
    {
        public override void Configure(EntityTypeBuilder<Locacao> entity)

        {
            //Obrigatório chamar
            base.Configure(entity);

            entity.ToTable("tb_Locacao");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id).HasColumnName("Id_Locacao");


            entity
                .Property(e => e.IdCliente)
                .HasColumnName("Id_Cliente");

            entity
                 .HasOne(d => d.Clientes)
                      .WithMany(p => p.Locacao)
                      .HasForeignKey(d => d.IdCliente)
                      .HasConstraintName("fk_tb_locacao_tb_cliente");
        }
    }
}