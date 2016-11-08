using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NA.ParkingLot.Web.Core;
using NA.ParkingLot.Web.Core.Domain;

namespace NA.ParkingLot.Web.Persistence
{
    public class ParkingLotContext : DbContext
    {
        public ParkingLotContext(DbContextOptions<ParkingLotContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasIndex(e => e.AdminId)
                    .HasName("IX_Admin_Id");

                entity.Property(e => e.AdminId).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.AdminId)
                    .HasConstraintName("FK_dbo.Companies_dbo.AspNetUsers_Admin_Id");
            });

            modelBuilder.Entity<ParkingLotArea>(entity =>
            {
                entity.HasIndex(e => e.ParkingLotId)
                    .HasName("IX_ParkingLotAreas_ParkingLotId");

                entity.Property(e => e.Latitude).HasColumnType("decimal");

                entity.Property(e => e.Longitude).HasColumnType("decimal");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                entity.HasOne(d => d.ParkingLot)
                    .WithMany(p => p.ParkingLotAreas)
                    .HasForeignKey(d => d.ParkingLotId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_ParkingLotAreas_ParkingLots");
            });

            modelBuilder.Entity<NA.ParkingLot.Web.Core.Domain.ParkingLot>(entity =>
            {
                entity.HasIndex(e => e.CompanyId)
                    .HasName("IX_Company_Id");

                entity.Property(e => e.Latitude).HasColumnType("decimal");

                entity.Property(e => e.Longitude).HasColumnType("decimal");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.ParkingLots)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_ParkingLots_Companies");
            });

            modelBuilder.Entity<Slot>(entity =>
            {
                entity.HasIndex(e => e.ParkingLotAreaId)
                    .HasName("IX_Slots_ParkingLotAreaId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_User_Id");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.ParkingLotArea)
                    .WithMany(p => p.Slots)
                    .HasForeignKey(d => d.ParkingLotAreaId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Slots_ParkingLotAreas");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Slots)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.Slots_dbo.AspNetUsers_User_Id");
            });
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<ParkingLotArea> ParkingLotAreas { get; set; }
        public virtual DbSet<NA.ParkingLot.Web.Core.Domain.ParkingLot> ParkingLots { get; set; }
        public virtual DbSet<Slot> Slots { get; set; }
    }
}