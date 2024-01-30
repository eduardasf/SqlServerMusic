using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SqlServerOrm.Domain;

namespace SqlServerOrm.Persistence
{
    public class GeneroMap : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.ToTable("genero");

            builder.HasKey(ct => ct.Codigo);

            builder.Property(ct => ct.Codigo)
                .HasColumnName("codigo")
                .HasColumnType("int")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(ct => ct.Tipo)
                .HasColumnName("tipo")
                .HasColumnType("varchar(150)")
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
