using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.ShirtStore.WebApi.Domains
{
    public partial class ShirtStoreContext : DbContext
    {
        public ShirtStoreContext()
        {
        }

        public ShirtStoreContext(DbContextOptions<ShirtStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Camisetas> Camisetas { get; set; }
        public virtual DbSet<Cores> Cores { get; set; }
        public virtual DbSet<Empresas> Empresas { get; set; }
        public virtual DbSet<Estoques> Estoques { get; set; }
        public virtual DbSet<Perfis> Perfis { get; set; }
        public virtual DbSet<Tamanhos> Tamanhos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress;Initial Catalog=T_ShirtStore;User Id=sa;Pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Camisetas>(entity =>
            {
                entity.HasKey(e => e.IdCamiseta);

                entity.Property(e => e.Descriçao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cores>(entity =>
            {
                entity.HasKey(e => e.IdCores);

                entity.Property(e => e.Cor)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empresas>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa);

                entity.Property(e => e.NomeEmpresa)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCamisetaNavigation)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.IdCamiseta)
                    .HasConstraintName("FK__Empresas__IdCami__59FA5E80");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Empresas__IdUsua__59063A47");
            });

            modelBuilder.Entity<Estoques>(entity =>
            {
                entity.HasKey(e => e.IdEstoque);

                entity.Property(e => e.Unidades)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCamisetaNavigation)
                    .WithMany(p => p.Estoques)
                    .HasForeignKey(d => d.IdCamiseta)
                    .HasConstraintName("FK__Estoques__IdCami__60A75C0F");

                entity.HasOne(d => d.IdCoresNavigation)
                    .WithMany(p => p.Estoques)
                    .HasForeignKey(d => d.IdCores)
                    .HasConstraintName("FK__Estoques__IdCore__628FA481");

                entity.HasOne(d => d.IdTamanhoNavigation)
                    .WithMany(p => p.Estoques)
                    .HasForeignKey(d => d.IdTamanho)
                    .HasConstraintName("FK__Estoques__IdTama__619B8048");
            });

            modelBuilder.Entity<Perfis>(entity =>
            {
                entity.HasKey(e => e.IdPerfil);

                entity.Property(e => e.Perfil)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tamanhos>(entity =>
            {
                entity.HasKey(e => e.IdTamanho);

                entity.Property(e => e.Tamanho)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D105343F0C72EE")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPerfil)
                    .HasConstraintName("FK__Usuarios__IdPerf__5070F446");
            });
        }
    }
}
