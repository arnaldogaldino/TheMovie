using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TheMovie.Infrastructure.Data.Externsions
{
    public abstract class EntityTypeConfiguration<TEntity> where TEntity : class
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}
