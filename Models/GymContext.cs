using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Palestra.Models;

public partial class GymContext : DbContext
{
    public GymContext()
    {
    }

    public GymContext(DbContextOptions<GymContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Corsi> Corsis { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Personale> Personales { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=TERENZI-PC\\SQLEXPRESS;Database=Gym;User Id=fla;Password=Fla1;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Corsi>(entity =>
        {
            entity.HasKey(e => e.IdCorso).HasName("PK__Corsi__2248BA0CCBB6E161");

            entity.ToTable("Corsi");

            entity.Property(e => e.IdCorso).HasColumnName("ID_Corso");
            entity.Property(e => e.Descrizione).HasColumnType("text");
            entity.Property(e => e.NomeCorso)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Nome_Corso");
            entity.Property(e => e.NumPartecipanti).HasColumnName("Num_Partecipanti");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPers).HasName("PK__Persona__B5EEB7E69BD2DDBC");

            entity.ToTable("Persona");

            entity.Property(e => e.IdPers).HasColumnName("ID_Pers");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Personale>(entity =>
        {
            entity.HasKey(e => e.IdPersonale).HasName("PK__Personal__13F1C8416501EB9A");

            entity.ToTable("Personale");

            entity.Property(e => e.IdPersonale).HasColumnName("ID_Personale");
            entity.Property(e => e.CorsiRif).HasColumnName("Corsi_rif");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.SalaRif).HasColumnName("Sala_rif");

            entity.HasOne(d => d.CorsiRifNavigation).WithMany(p => p.Personales)
                .HasForeignKey(d => d.CorsiRif)
                .HasConstraintName("FK__Personale__Corsi__72C60C4A");

            entity.HasOne(d => d.SalaRifNavigation).WithMany(p => p.Personales)
                .HasForeignKey(d => d.SalaRif)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Personale__Sala___71D1E811");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.IdSala).HasName("PK__Sale__2071DEA72C4255A8");

            entity.ToTable("Sale");

            entity.Property(e => e.IdSala).HasColumnName("ID_Sala");
            entity.Property(e => e.CapacitàMax).HasColumnName("Capacità_Max");
            entity.Property(e => e.CorsiRif).HasColumnName("Corsi_rif");
            entity.Property(e => e.NomeSala)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("Nome_sala");

            entity.HasOne(d => d.CorsiRifNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.CorsiRif)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Sale__Corsi_rif__571DF1D5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
