namespace Locadora.Infra.Data.Mapping
{
    using Locadora.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ClienteMap : BaseEntityConfiguration<Cliente>
    {
        public override void Configure(EntityTypeBuilder<Cliente> entity)

        {
            //Obrigatório chamar
            base.Configure(entity);

            entity
                .ToTable("tb_cliente");

            entity
                .HasKey(e => e.Id);

            // Indices
            entity.Property(e => e.Id)
                .HasColumnName("Id_Cliente");

            entity
                .Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasDefaultValueSql("('')");

        }
    }
}
