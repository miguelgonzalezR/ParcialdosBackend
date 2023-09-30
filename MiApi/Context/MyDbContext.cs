using System;
using System.Collections.Generic;
using MiApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MiApi.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }


    public virtual DbSet<Elecciones> Elecciones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MIGUEL;Database=GR100220RB100519GA100620;Integrated Security=True;TrustServerCertificate=True;");               

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        modelBuilder.Entity<Elecciones>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__blog__3213E83FB399F40B");

            entity.ToTable("votosel");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Candidato)
                .HasMaxLength(55)
                .IsUnicode(false)
                .HasColumnName("candidato");
            entity.Property(e => e.votos)
                .HasColumnName("votos");
            entity.Property(e => e.porcentaje)
                .HasColumnName("porcentaje");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
