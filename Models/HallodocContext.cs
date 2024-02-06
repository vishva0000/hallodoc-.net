using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace hallodoc.Models;

public partial class HallodocContext : DbContext
{
    public HallodocContext()
    {
    }

    public HallodocContext(DbContextOptions<HallodocContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Adminregion> Adminregions { get; set; }

    public virtual DbSet<Aspnetrole> Aspnetroles { get; set; }

    public virtual DbSet<Aspnetuser> Aspnetusers { get; set; }

    public virtual DbSet<Aspnetuserrole> Aspnetuserroles { get; set; }

    public virtual DbSet<Blockrequest> Blockrequests { get; set; }

    public virtual DbSet<Businestype> Businestypes { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Adminid).HasName("admin_pkey");

            entity.ToTable("admin");

            entity.Property(e => e.Adminid)
                .ValueGeneratedNever()
                .HasColumnName("adminid");
            entity.Property(e => e.Address1)
                .HasMaxLength(500)
                .HasColumnName("address1");
            entity.Property(e => e.Address2)
                .HasMaxLength(500)
                .HasColumnName("address2");
            entity.Property(e => e.Altphone)
                .HasMaxLength(20)
                .HasColumnName("altphone");
            entity.Property(e => e.Aspnetuserid)
                .HasMaxLength(128)
                .HasColumnName("aspnetuserid");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.Createdby)
                .HasMaxLength(128)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .HasColumnName("firstname");
            entity.Property(e => e.Isdeleted)
                .HasColumnType("bit(1)")
                .HasColumnName("isdeleted");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .HasColumnName("lastname");
            entity.Property(e => e.Mobile)
                .HasMaxLength(20)
                .HasColumnName("mobile");
            entity.Property(e => e.Modifiedby)
                .HasMaxLength(128)
                .HasColumnName("modifiedby");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Regionid).HasColumnName("regionid");
            entity.Property(e => e.Roleid).HasColumnName("roleid");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Zip)
                .HasMaxLength(10)
                .HasColumnName("zip");

            entity.HasOne(d => d.Aspnetuser).WithMany(p => p.AdminAspnetusers)
                .HasForeignKey(d => d.Aspnetuserid)
                .HasConstraintName("admin_aspnetuserid_fkey");

            entity.HasOne(d => d.ModifiedbyNavigation).WithMany(p => p.AdminModifiedbyNavigations)
                .HasForeignKey(d => d.Modifiedby)
                .HasConstraintName("admin_modifiedby_fkey");
        });

        modelBuilder.Entity<Adminregion>(entity =>
        {
            entity.HasKey(e => e.Adminregionid).HasName("adminregion_pkey");

            entity.ToTable("adminregion");

            entity.Property(e => e.Adminregionid)
                .ValueGeneratedNever()
                .HasColumnName("adminregionid");
            entity.Property(e => e.Adminid).HasColumnName("adminid");
            entity.Property(e => e.Regionid).HasColumnName("regionid");

            entity.HasOne(d => d.Admin).WithMany(p => p.Adminregions)
                .HasForeignKey(d => d.Adminid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("adminregion_adminid_fkey");

            entity.HasOne(d => d.Region).WithMany(p => p.Adminregions)
                .HasForeignKey(d => d.Regionid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("adminregion_regionid_fkey");
        });

        modelBuilder.Entity<Aspnetrole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("aspnetroles_pkey");

            entity.ToTable("aspnetroles");

            entity.Property(e => e.Id)
                .HasMaxLength(128)
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(256)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Aspnetuser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("aspnetusers_pkey");

            entity.ToTable("aspnetusers");

            entity.Property(e => e.Id)
                .HasMaxLength(128)
                .HasColumnName("id");
            entity.Property(e => e.Accessfailedcount).HasColumnName("accessfailedcount");
            entity.Property(e => e.Corepasswordhash)
                .HasColumnType("character varying")
                .HasColumnName("corepasswordhash");
            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .HasColumnName("email");
            entity.Property(e => e.Emailconfirmed)
                .HasColumnType("bit(1)")
                .HasColumnName("emailconfirmed");
            entity.Property(e => e.Hashversion).HasColumnName("hashversion");
            entity.Property(e => e.Ip)
                .HasMaxLength(20)
                .HasColumnName("ip");
            entity.Property(e => e.Lockoutenabled)
                .HasColumnType("bit(1)")
                .HasColumnName("lockoutenabled");
            entity.Property(e => e.Lockoutenddateutc)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("lockoutenddateutc");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Passwordhash)
                .HasColumnType("character varying")
                .HasColumnName("passwordhash");
            entity.Property(e => e.Phonenumber)
                .HasColumnType("character varying")
                .HasColumnName("phonenumber");
            entity.Property(e => e.Phonenumberconfirmed)
                .HasColumnType("bit(1)")
                .HasColumnName("phonenumberconfirmed");
            entity.Property(e => e.Securitystamp)
                .HasColumnType("character varying")
                .HasColumnName("securitystamp");
            entity.Property(e => e.Twofactorenabled)
                .HasColumnType("bit(1)")
                .HasColumnName("twofactorenabled");
            entity.Property(e => e.Username)
                .HasMaxLength(256)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Aspnetuserrole>(entity =>
        {
            entity.HasKey(e => new { e.Userid, e.Roleid }).HasName("aspnetuserroles_pkey");

            entity.ToTable("aspnetuserroles");

            entity.Property(e => e.Userid)
                .HasMaxLength(128)
                .HasColumnName("userid");
            entity.Property(e => e.Roleid)
                .HasMaxLength(128)
                .HasColumnName("roleid");

            entity.HasOne(d => d.User).WithMany(p => p.Aspnetuserroles)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_userid");
        });

        modelBuilder.Entity<Blockrequest>(entity =>
        {
            entity.HasKey(e => e.Blockrequestid).HasName("blockrequests_pkey");

            entity.ToTable("blockrequests");

            entity.Property(e => e.Blockrequestid)
                .ValueGeneratedNever()
                .HasColumnName("blockrequestid");
            entity.Property(e => e.Createddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createddate");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Ip)
                .HasMaxLength(20)
                .HasColumnName("ip");
            entity.Property(e => e.Isactive)
                .HasColumnType("bit(1)")
                .HasColumnName("isactive");
            entity.Property(e => e.Modifieddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("modifieddate");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(50)
                .HasColumnName("phonenumber");
            entity.Property(e => e.Reason)
                .HasColumnType("character varying")
                .HasColumnName("reason");
            entity.Property(e => e.Requestid)
                .HasMaxLength(50)
                .HasColumnName("requestid");
        });

        modelBuilder.Entity<Businestype>(entity =>
        {
            entity.HasKey(e => e.Businesstypeid).HasName("businestype_pkey");

            entity.ToTable("businestype");

            entity.Property(e => e.Businesstypeid)
                .ValueGeneratedNever()
                .HasColumnName("businesstypeid");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.Regionid).HasName("region_pkey");

            entity.ToTable("region");

            entity.Property(e => e.Regionid)
                .ValueGeneratedNever()
                .HasColumnName("regionid");
            entity.Property(e => e.Abbreviation)
                .HasMaxLength(50)
                .HasColumnName("abbreviation");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
