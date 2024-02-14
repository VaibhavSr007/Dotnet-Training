using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EfcoreEx.Models;

public partial class Ace52024Context : DbContext
{
    public Ace52024Context()
    {
    }

    public Ace52024Context(DbContextOptions<Ace52024Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Aryan> Aryans { get; set; }

    public virtual DbSet<Avika> Avikas { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Fpstudent> Fpstudents { get; set; }

    public virtual DbSet<Harshit> Harshits { get; set; }

    public virtual DbSet<Jayendra> Jayendras { get; set; }

    public virtual DbSet<Jivanshu> Jivanshus { get; set; }

    public virtual DbSet<Kartik> Kartiks { get; set; }

    public virtual DbSet<Kush> Kushes { get; set; }

    public virtual DbSet<Pragati> Pragatis { get; set; }

    public virtual DbSet<Prerna> Prernas { get; set; }

    public virtual DbSet<Sandhya> Sandhyas { get; set; }

    public virtual DbSet<Sanskriti> Sanskritis { get; set; }

    public virtual DbSet<Stud> Studs { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Student007> Student007s { get; set; }

    public virtual DbSet<StudentDb> StudentDbs { get; set; }

    public virtual DbSet<Studenttt> Studenttts { get; set; }

    public virtual DbSet<Studentttt> Studentttts { get; set; }

    public virtual DbSet<Studenttttt> Studenttttts { get; set; }

    public virtual DbSet<Suhasini> Suhasinis { get; set; }

    public virtual DbSet<Suhasininew> Suhasininews { get; set; }

    public virtual DbSet<Suhasinitable> Suhasinitables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DEVSQL.Corp.local;Database=ACE 5- 2024;Trusted_Connection=True;encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aryan>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__aryan__DDDFDD36A8A3380C");

            entity.ToTable("aryan");

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

        modelBuilder.Entity<Avika>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__avika__DDDFDD36C4D1AF1A");

            entity.ToTable("avika");

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

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__employee__DDDFDD361B1D6E6A");

            entity.ToTable("employee");

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

        modelBuilder.Entity<Fpstudent>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__Fpstuden__DDDFDD363121B9DB");

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

        modelBuilder.Entity<Harshit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__harshit__3213E83FAA22F92F");

            entity.ToTable("harshit");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("first_name");
        });

        modelBuilder.Entity<Jayendra>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Jayendra");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Jivanshu>(entity =>
        {
            entity.HasKey(e => e.Eid).HasName("PK__jivanshu__D9509F6DF8E8E366");

            entity.ToTable("jivanshu");

            entity.Property(e => e.Eid)
                .ValueGeneratedNever()
                .HasColumnName("eid");
            entity.Property(e => e.Doj).HasColumnName("doj");
            entity.Property(e => e.Ename)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ename");
        });

        modelBuilder.Entity<Kartik>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__kartik__CA195950483E7AEB");

            entity.ToTable("kartik");

            entity.Property(e => e.Sid)
                .ValueGeneratedNever()
                .HasColumnName("SId");
            entity.Property(e => e.Sname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SName");
        });

        modelBuilder.Entity<Kush>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__kush__DDDFDD36992B3749");

            entity.ToTable("kush");

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

        modelBuilder.Entity<Pragati>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__pragati__DDDFDD36539475D8");

            entity.ToTable("pragati");

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

        modelBuilder.Entity<Prerna>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__Prerna__DDDFDD36204B8DCB");

            entity.ToTable("Prerna");

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

        modelBuilder.Entity<Sandhya>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__Sandhya__DDDFDD36D4582238");

            entity.ToTable("Sandhya");

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

        modelBuilder.Entity<Sanskriti>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__sanskrit__DDDFDD365FAABCAC");

            entity.ToTable("sanskriti");

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

        modelBuilder.Entity<Stud>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__stud__DDDFDD3692EC07E2");

            entity.ToTable("stud");

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

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__student__DDDFDD3626AAB5A7");

            entity.ToTable("student");

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

        modelBuilder.Entity<StudentDb>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__studentD__DDDFDD363C7A8192");

            entity.ToTable("studentDB");

            entity.Property(e => e.Sid)
                .ValueGeneratedNever()
                .HasColumnName("sid");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Sname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        modelBuilder.Entity<Studenttt>(entity =>
        {
            entity.HasKey(e => e.Sid).HasName("PK__studentt__DDDFDD36046BBB59");

            entity.ToTable("studenttt");

            entity.Property(e => e.Sid)
                .ValueGeneratedNever()
                .HasColumnName("sid");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Sname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        modelBuilder.Entity<Studentttt>(entity =>
        {
            entity.HasKey(e => e.Siiid).HasName("PK__studentt__3DBE29A1BBC3441F");

            entity.ToTable("studentttt");

            entity.Property(e => e.Siiid)
                .ValueGeneratedNever()
                .HasColumnName("siiid");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Sname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        modelBuilder.Entity<Studenttttt>(entity =>
        {
            entity.HasKey(e => e.Siiid).HasName("PK__studentt__3DBE29A1E0962EC7");

            entity.ToTable("studenttttt");

            entity.Property(e => e.Siiid)
                .ValueGeneratedNever()
                .HasColumnName("siiid");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Marks).HasColumnName("marks");
            entity.Property(e => e.Sname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sname");
        });

        modelBuilder.Entity<Suhasini>(entity =>
        {
            entity.HasKey(e => e.Empid).HasName("PK__Suhasini__AF4CE865B4F45413");

            entity.ToTable("Suhasini");

            entity.Property(e => e.Empid)
                .ValueGeneratedNever()
                .HasColumnName("empid");
            entity.Property(e => e.Empname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("empname");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        modelBuilder.Entity<Suhasininew>(entity =>
        {
            entity.HasKey(e => e.Empid).HasName("PK__Suhasini__AF4CE865B5D05F55");

            entity.ToTable("Suhasininew");

            entity.Property(e => e.Empid)
                .ValueGeneratedNever()
                .HasColumnName("empid");
            entity.Property(e => e.Empname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("empname");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        modelBuilder.Entity<Suhasinitable>(entity =>
        {
            entity.HasKey(e => e.Empid).HasName("PK__Suhasini__AF4CE865DE4625E0");

            entity.ToTable("Suhasinitable");

            entity.Property(e => e.Empid)
                .ValueGeneratedNever()
                .HasColumnName("empid");
            entity.Property(e => e.Empname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("empname");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
