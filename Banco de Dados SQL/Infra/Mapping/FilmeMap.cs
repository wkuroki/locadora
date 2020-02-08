namespace Locadora.Infra.Data.Mapping
{
    using Locadora.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class FilmeMap : BaseEntityConfiguration<Filme>
    {
        public override void Configure(EntityTypeBuilder<Filme> entity)

        {
            //Obrigatório chamar
            base.Configure(entity);

            entity
                .ToTable("tb_filme");

            entity
                .HasKey(e => e.Id);

            entity
                .Property(e => e.Id)
                .HasColumnName("Id_Filme");

            entity
                .Property(e => e.Descricao)
                .HasMaxLength(70)
                .IsUnicode(false);
        }
    }
}