﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SISTEMA_HOTEL.MODEL.Models;

public partial class SISTEMA_HOTELContext : DbContext
{
    public SISTEMA_HOTELContext()
    {
    }

    public SISTEMA_HOTELContext(DbContextOptions<SISTEMA_HOTELContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Hospede> Hospedes { get; set; }

    public virtual DbSet<Quarto> Quartos { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Data Source=jacknotebook\\sqlexpress;Initial Catalog=SISTEMA_HOTEL;User ID=sa;Password=sa123;trustservercertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hospede>(entity =>
        {
            entity.HasKey(e => e.HospedeId).HasName("PK__Hospedes__29F00BB4E73DB704");

            entity.HasIndex(e => e.Email, "UQ__Hospedes__A9D1053463E3C09C").IsUnique();

            entity.HasIndex(e => e.DocumentoIdentificacao, "UQ__Hospedes__FBF8157B0D4A4A07").IsUnique();

            entity.Property(e => e.DocumentoIdentificacao)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Quarto>(entity =>
        {
            entity.HasKey(e => e.QuartoId).HasName("PK__Quartos__903445339E4069E7");

            entity.HasIndex(e => e.Numero, "UQ__Quartos__7E532BC666825578").IsUnique();

            entity.Property(e => e.Preco).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("disponível");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.ReservaId).HasName("PK__Reservas__C3993763F1C56235");

            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("ativa");

            entity.HasOne(d => d.Hospede).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.HospedeId)
                .HasConstraintName("FK_HospedeReserva");

            entity.HasOne(d => d.Quarto).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.QuartoId)
                .HasConstraintName("FK_QuartoReserva");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}