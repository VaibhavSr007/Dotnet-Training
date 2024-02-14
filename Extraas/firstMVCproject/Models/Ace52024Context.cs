using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace firstmvcprj.Models;

public partial class Ace52024Context : DbContext
{
    public Ace52024Context()
    {
    }

    public Ace52024Context(DbContextOptions<Ace52024Context> options)
        : base(options)
    {
    }

    public virtual DbSet<SbAccountv> SbAccountvs { get; set; }

    public virtual DbSet<SbTransactionv> SbTransactionvs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DEVSQL.Corp.local;Database=ACE 5- 2024;Trusted_Connection=True;encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SbAccountv>(entity =>
        {
            entity.HasKey(e => e.AccountNumber).HasName("PK__SbAccoun__BE2ACD6E3C187E2F");

            entity.Property(e => e.AccountNumber).ValueGeneratedNever();
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SbTransactionv>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__SbTransa__55433A6B1F2EEFE1");

            entity.Property(e => e.TransactionId).ValueGeneratedNever();
            entity.Property(e => e.TransactionType)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.AccountNumberNavigation).WithMany(p => p.SbTransactionvs)
                .HasForeignKey(d => d.AccountNumber)
                .HasConstraintName("FK__SbTransac__Accou__44CA3770");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
