using Locadora.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.Data.Mapping
{
    public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity

    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Ignore(b => b.Excluido);
        }
    }

}
