﻿using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Models;

public partial class CRUDOPERATIONContext : DbContext
{
    public CRUDOPERATIONContext(DbContextOptions<CRUDOPERATIONContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmpTable> EmpTables { get; set; }

    public virtual DbSet<SkillsTable> SkillsTables { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmpTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_EMP_ID");

            entity.ToTable("Emp_Table");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Designation)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Dob)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DOB");
            entity.Property(e => e.Email_Address)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Email_Address");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasMany(d => d.Skills).WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeeSkill",
                    r => r.HasOne<SkillsTable>().WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EmployeeS__Skill__60A75C0F"),
                    l => l.HasOne<EmpTable>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EmployeeS__Emplo__5FB337D6"),
                    j =>
                    {
                        j.HasKey("EmployeeId", "SkillId").HasName("PK__Employee__172A460902D99A0F");
                        j.ToTable("EmployeeSkills");
                    });
        });

        modelBuilder.Entity<SkillsTable>(entity =>
        {
            entity.ToTable("Skills_Table");

            entity.Property(e => e.Skills)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingGeneratedProcedures(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}