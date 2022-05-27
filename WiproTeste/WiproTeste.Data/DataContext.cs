using Microsoft.EntityFrameworkCore;
using WiproTeste.Data.Entities;

namespace WiproTeste.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; } = null!;
        public virtual DbSet<Filmes> Filmes { get; set; } = null!;
        public virtual DbSet<Locacoes> Locacoes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.Property(e => e.Documento)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Filmes>(entity =>
            {
                entity.Property(e => e.Titulo)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Locacoes>(entity =>
            {
                entity.Property(e => e.DataDevolucao).HasColumnType("date");

                entity.Property(e => e.DataLocacao).HasColumnType("date");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Locacoes)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Locacoes_Clientes");

                entity.HasOne(d => d.Filme)
                    .WithMany(p => p.Locacoes)
                    .HasForeignKey(d => d.FilmeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Locacoes_Filmes");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
