using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TheMovie.Infrastructure.Data.Externsions;
using TheMovie.Domain.Entities;

namespace TheMovie.Infrastructure.Data.Mappings
{
    public class FilmeMapping : EntityTypeConfiguration<Filme>
    {
        public override void Map(EntityTypeBuilder<Filme> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
              .HasColumnType("varchar(50)")
              .IsRequired();

            builder.Property(e => e.Titulo)
              .HasColumnType("varchar(100)");

            builder.Property(e => e.Sinopse)
                .HasColumnType("varchar(1000)");

            builder.Property(e => e.Genero)
                .HasColumnType("varchar(50)");

            //builder.Property(e => e.Poster)
            //    .HasColumnType("image");

            builder.ToTable("Filmes");
        }
    }
}
