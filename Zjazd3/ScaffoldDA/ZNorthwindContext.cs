using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Zjazd3.ScaffoldDA
{
    public partial class ZNorthwindContext : DbContext
    {
        public ZNorthwindContext()
        {
        }

        public ZNorthwindContext(DbContextOptions<ZNorthwindContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dostawcy> Dostawcies { get; set; }
        public virtual DbSet<Kategorie> Kategories { get; set; }
        public virtual DbSet<Klienci> Kliencis { get; set; }
        public virtual DbSet<PozycjeZamówienium> PozycjeZamówienia { get; set; }
        public virtual DbSet<Pracownicy> Pracownicies { get; set; }
        public virtual DbSet<Produkty> Produkties { get; set; }
        public virtual DbSet<Spedytorzy> Spedytorzies { get; set; }
        public virtual DbSet<WartoscZamowien> WartoscZamowiens { get; set; }
        public virtual DbSet<Zamówienium> Zamówienia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = PC-DOM; Initial Catalog = ZNorthwind; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Polish_CI_AS");

            modelBuilder.Entity<Dostawcy>(entity =>
            {
                entity.Property(e => e.Iddostawcy).ValueGeneratedNever();

                entity.Property(e => e.KodPocztowy).IsFixedLength();
            });

            modelBuilder.Entity<Kategorie>(entity =>
            {
                entity.Property(e => e.Idkategorii).ValueGeneratedNever();
            });

            modelBuilder.Entity<Klienci>(entity =>
            {
                entity.HasKey(e => e.Idklienta)
                    .HasName("PK_IDKlienta");

                entity.Property(e => e.Idklienta).IsFixedLength();

                entity.Property(e => e.KodPocztowy).IsFixedLength();
            });

            modelBuilder.Entity<PozycjeZamówienium>(entity =>
            {
                entity.HasKey(e => new { e.Idzamówienia, e.Idproduktu })
                    .HasName("PK_PozycjeZamowien");

                entity.HasOne(d => d.IdproduktuNavigation)
                    .WithMany(p => p.PozycjeZamówienia)
                    .HasForeignKey(d => d.Idproduktu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PozycjeZamówienia_Produkty");

                entity.HasOne(d => d.IdzamówieniaNavigation)
                    .WithMany(p => p.PozycjeZamówienia)
                    .HasForeignKey(d => d.Idzamówienia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PozycjeZamówienia_Zamówienia");
            });

            modelBuilder.Entity<Pracownicy>(entity =>
            {
                entity.Property(e => e.Idpracownika).ValueGeneratedNever();

                entity.Property(e => e.KodPocztowy).IsFixedLength();
            });

            modelBuilder.Entity<Produkty>(entity =>
            {
                entity.Property(e => e.Idproduktu).ValueGeneratedNever();

                entity.HasOne(d => d.IddostawcyNavigation)
                    .WithMany(p => p.Produkties)
                    .HasForeignKey(d => d.Iddostawcy)
                    .HasConstraintName("FK_Produkty_Dostawcy");

                entity.HasOne(d => d.IdkategoriiNavigation)
                    .WithMany(p => p.Produkties)
                    .HasForeignKey(d => d.Idkategorii)
                    .HasConstraintName("FK_Produkty_Kategorie");
            });

            modelBuilder.Entity<Spedytorzy>(entity =>
            {
                entity.Property(e => e.Idspedytora).ValueGeneratedNever();
            });

            modelBuilder.Entity<WartoscZamowien>(entity =>
            {
                entity.ToView("WartoscZamowien");
            });

            modelBuilder.Entity<Zamówienium>(entity =>
            {
                entity.Property(e => e.Idzamówienia).ValueGeneratedNever();

                entity.Property(e => e.Idklienta).IsFixedLength();

                entity.HasOne(d => d.IdklientaNavigation)
                    .WithMany(p => p.Zamówienia)
                    .HasForeignKey(d => d.Idklienta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Zamówienia_Klienci");

                entity.HasOne(d => d.IdpracownikaNavigation)
                    .WithMany(p => p.Zamówienia)
                    .HasForeignKey(d => d.Idpracownika)
                    .HasConstraintName("FK_Zamówienia_Pracownicy");

                entity.HasOne(d => d.IdspedytoraNavigation)
                    .WithMany(p => p.Zamówienia)
                    .HasForeignKey(d => d.Idspedytora)
                    .HasConstraintName("FK_Zamówienia_Spedytorzy");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
