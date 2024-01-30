using Microsoft.EntityFrameworkCore;
using SqlServerOrm.Domain;

namespace SqlServerOrm.Persistence
{
    public class EduardaContext : DbContext
    {
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Genero> Generos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=10.1.1.215,11433;Database=Eduarda;User ID=sa;Password=Formacao@2024;Trusted_Connection=False;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new MusicaMap().Configure(modelBuilder.Entity<Musica>());
            new GeneroMap().Configure(modelBuilder.Entity<Genero>());
        }
    }
}
