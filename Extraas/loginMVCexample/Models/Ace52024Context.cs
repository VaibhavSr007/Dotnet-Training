using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace loginmvcex.Models;

public partial class Ace52024Context : DbContext
{
    public Ace52024Context()
    {
    }

    public Ace52024Context(DbContextOptions<Ace52024Context> options)
        : base(options)
    {
    }

    public virtual DbSet<UserVai> UserVais { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DEVSQL.Corp.local;Database=ACE 5- 2024;Trusted_Connection=True;encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserVai>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__UserVai__A9D1053584A2DC17");

            entity.ToTable("UserVai");

            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Pass)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
