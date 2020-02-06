namespace Locadora.Infra.Data.Mapping
{
    using Locadora.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class LocacaoItemMap : BaseEntityConfiguration<LocacaoItem>
    {
        public override void Configure(EntityTypeBuilder<LocacaoItem> entity)

        {
            //Obrigatório chamar
            base.Configure(entity);

            entity
                .ToTable("tb_Locacao_item");

            entity
                .HasKey(e => e.Id);

            entity
                .Property(e => e.Id)
                .HasColumnName("Id_Locacao_Item");

            entity.Property(e => e.IdLocacao)
                .HasColumnName("Id_Locacao");

            entity.Property(e => e.IdFilme)
                .HasColumnName("Id_Filme");

            entity.Property(e => e.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(70)
                .IsUnicode(false);

            entity
                .HasOne(d => d.Locacao)
                .WithMany(p => p.LocacaoItems)
                .HasForeignKey(d => d.IdLocacao)
                .HasConstraintName("FK_tb_Locacao_tb_Locacao_item");
        }
    }
}
