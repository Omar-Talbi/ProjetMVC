using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProjetMVC.Models;

public partial class Companyg2Context : DbContext
{
  
    public Companyg2Context(DbContextOptions<Companyg2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-9VFPG88\\MSSQLSERVER1;Database=companyg2;Integrated Security=True;Trust Server Certificate=yes");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F11E651A409");

            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Designation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.JoiningDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdserviceNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Idservice)
                .HasConstraintName("FK_Employees_Services");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Idservice);

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
