using System;
using System.Collections.Generic;
using LojistaPro.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LojistaPro.Data;

public partial class AuthContext : IdentityDbContext<AuthUser, Role, string>
{
    public AuthContext()
    {
    }

    public AuthContext(DbContextOptions<AuthContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuthUserRole> AuthUserRoles { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AuthUserRole>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.AuthUserId, e.RoleId });
            entity.ToTable("AuthUserRole");
            entity.Property(e => e.CriadoEm).HasColumnType("datetime");
            entity.Property(e => e.CriadoPor).HasColumnType("datetime");

            entity.HasOne(d => d.Role)
                .WithMany(p => p.AuthUserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.AuthUser)
                .WithMany(p => p.AuthUserRoles)
                .HasForeignKey(d => d.AuthUserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("AspNetRoles");
            entity.Property(e => e.CriadoEm).HasColumnType("datetime");
            entity.Property(e => e.CriadoPor).HasColumnType("datetime");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
