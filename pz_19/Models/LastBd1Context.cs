using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace pz_19;

public partial class LastBd1Context : DbContext
{
    public LastBd1Context()
    {
    }

    public LastBd1Context(DbContextOptions<LastBd1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<HomeTech> HomeTeches { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<SpecialistsType> SpecialistsTypes { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<TechnicianComment> TechnicianComments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Server=192.168.147.54;Database=_LastBD1;User Id=is;Password=1;TrustServerCertificate=true;");
        => optionsBuilder.UseSqlServer("Server=localhost;Database=PizzaDB;Trusted_Connection=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Clients__E67E1A049193CE9B");

            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Type).HasMaxLength(20);
        });

        modelBuilder.Entity<HomeTech>(entity =>
        {
            entity.HasKey(e => e.HomeTechId).HasName("PK__HomeTech__40030073D5369607");

            entity.ToTable("HomeTech");

            entity.Property(e => e.HomeTechId).HasColumnName("homeTechID");
            entity.Property(e => e.HomeTechModel)
                .HasMaxLength(150)
                .HasColumnName("homeTechModel");
            entity.Property(e => e.HomeTechType)
                .HasMaxLength(100)
                .HasColumnName("homeTechType");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Requests__33A8519A9DBA9486");

            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.CompletionDate).HasColumnType("datetime");
            entity.Property(e => e.FaultType).HasMaxLength(100);
            entity.Property(e => e.HomeTechId).HasColumnName("homeTechID");
            entity.Property(e => e.RequestDate).HasColumnType("datetime");
            entity.Property(e => e.SpecialistId).HasColumnName("SpecialistID");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Client).WithMany(p => p.Requests)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Requests__Client__44FF419A");

            entity.HasOne(d => d.HomeTech).WithMany(p => p.Requests)
                .HasForeignKey(d => d.HomeTechId)
                .HasConstraintName("FK__Requests__homeTe__4316F928");

            entity.HasOne(d => d.Specialist).WithMany(p => p.Requests)
                .HasForeignKey(d => d.SpecialistId)
                .HasConstraintName("FK__Requests__Specia__440B1D61");

            entity.HasOne(d => d.Status).WithMany(p => p.Requests)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__Requests__Status__45F365D3");
        });

        modelBuilder.Entity<SpecialistsType>(entity =>
        {
            entity.HasKey(e => e.SpecialistId).HasName("PK__Speciali__7092080EE93105DD");

            entity.ToTable("SpecialistsType");

            entity.Property(e => e.SpecialistId).HasColumnName("SpecialistID");
            entity.Property(e => e.Type).HasMaxLength(20);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Statuses__C8EE20438CA8FFAE");

            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.StatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<TechnicianComment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__Technici__C3B4DFAAB12DD296");

            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.SpecialistId).HasColumnName("SpecialistID");

            entity.HasOne(d => d.Request).WithMany(p => p.TechnicianComments)
                .HasForeignKey(d => d.RequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Technicia__Reque__49C3F6B7");

            entity.HasOne(d => d.Specialist).WithMany(p => p.TechnicianComments)
                .HasForeignKey(d => d.SpecialistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Technicia__Speci__48CFD27E");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC929FEBB2");

            entity.HasIndex(e => e.Login, "UQ__Users__5E55825B3265591E").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.SpecialistId).HasColumnName("SpecialistID");

            entity.HasOne(d => d.Client).WithMany(p => p.Users)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__ClientID__403A8C7D");

            entity.HasOne(d => d.Specialist).WithMany(p => p.Users)
                .HasForeignKey(d => d.SpecialistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__Specialis__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
