using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace firstapi.Models;

public partial class Ace52024Context : DbContext
{
    public Ace52024Context()
    {
    }

    public Ace52024Context(DbContextOptions<Ace52024Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Student007> Student007s { get; set; }

    public virtual DbSet<VsBookingDetail> VsBookingDetails { get; set; }

    public virtual DbSet<VsCustomer> VsCustomers { get; set; }

    public virtual DbSet<VsFlight> VsFlights { get; set; }

    public virtual DbSet<VsSearch> VsSearches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DEVSQL.Corp.local;Database=ACE 5- 2024;Trusted_Connection=True;encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student007>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__student0__DDDFDD36718934E4");

            entity.ToTable("student007");

            entity.Property(e => e.Sid)
                .ValueGeneratedNever()
                .HasColumnName("sid");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Sname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        modelBuilder.Entity<VsBookingDetail>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__vsBookin__73951AED946A1520");

            entity.ToTable("vsBookingDetail");

            entity.Property(e => e.TravelDate).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.VsBookingDetails)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__vsBooking__Custo__278EDA44");

            entity.HasOne(d => d.Flight).WithMany(p => p.VsBookingDetails)
                .HasForeignKey(d => d.FlightId)
                .HasConstraintName("FK__vsBooking__Fligh__269AB60B");
        });

        modelBuilder.Entity<VsCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__vsCustom__A4AE64D8509155DE");

            entity.ToTable("vsCustomer");

            entity.Property(e => e.CustomerEmail)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CustomerPass)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VsFlight>(entity =>
        {
            entity.HasKey(e => e.FlightId).HasName("PK__vsFlight__8A9E14EE5F356E91");

            entity.ToTable("vsFlight");

            entity.Property(e => e.Dest)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FlightName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Src)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VsSearch>(entity =>
        {
            entity.HasKey(e => e.SearchId).HasName("PK__vsSearch__21C535F477799F27");

            entity.ToTable("vsSearch");

            entity.Property(e => e.SearchDest)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SearchSrc)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
