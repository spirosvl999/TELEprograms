using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC_Final.Models;

public partial class LabDBContext : DbContext
{
    public LabDBContext()
    {
    }

    public LabDBContext(DbContextOptions<LabDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<BillsCall> BillsCalls { get; set; }

    public virtual DbSet<Call> Calls { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    public virtual DbSet<Program> Programs { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-EFUUG9PQ;Database=mvc_db;Trusted_Connection=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.Property(e => e.AdminId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PK_bills");

            entity.Property(e => e.BillId).ValueGeneratedNever();

            entity.HasOne(d => d.PhoneNumberNavigation).WithMany(p => p.Bills)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bills_phones");
        });

        modelBuilder.Entity<BillsCall>(entity =>
        {
            entity.Property(e => e.BillId).ValueGeneratedNever();

            entity.HasOne(d => d.Bill).WithOne(p => p.BillsCall)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillsCalls_Bills");

            entity.HasOne(d => d.Call).WithMany(p => p.BillsCalls)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillsCalls_Calls");
        });

        modelBuilder.Entity<Call>(entity =>
        {
            entity.Property(e => e.CallId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.Property(e => e.ClientId).ValueGeneratedNever();

            entity.HasOne(d => d.PhoneNumberNavigation).WithMany(p => p.Clients)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_clients_phones");
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasOne(d => d.ProgramNameNavigation).WithMany(p => p.Phones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_phones_programs");
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.Property(e => e.SellerId).ValueGeneratedNever();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
