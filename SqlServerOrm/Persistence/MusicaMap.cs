using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SqlServerOrm.Domain;

namespace SqlServerOrm.Persistence
{
    public class MusicaMap : IEntityTypeConfiguration<Musica>
    {
        public void Configure(EntityTypeBuilder<Musica> builder)
        {
            builder.ToTable("musica");

            builder.HasKey(c => c.Codigo);

            builder.Property(c => c.Codigo)
                .HasColumnName("codigo")
                .HasColumnType("int")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(150)")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.NomeCantor)
                 .HasColumnName("nomeCantor")
                 .HasColumnType("varchar(150)")
                 .HasMaxLength(150);

            builder.Property(c => c.GeneroCodigo)
                .HasColumnName("codigo_genero")
                .HasColumnType("int")
                .IsRequired();

            builder.HasOne(c => c.Genero)
                .WithMany(ct => ct.Musicas)
                .HasForeignKey(c => c.GeneroCodigo)
                .IsRequired();
        }
    }
}
