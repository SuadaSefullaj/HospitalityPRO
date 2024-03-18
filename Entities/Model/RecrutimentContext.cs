using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Models
{
    public partial class RecrutimentContext : DbContext
    {
        public RecrutimentContext()
        {
        }

        public RecrutimentContext(DbContextOptions<RecrutimentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Certificate> Certificates { get; set; } = null!;
        public virtual DbSet<Education> Educations { get; set; } = null!;
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MARINELA;Database=Recrutiment;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.ToTable("Certificate");

                entity.Property(e => e.CertificateId)
                    .ValueGeneratedNever()
                    .HasColumnName("CertificateID");

                entity.Property(e => e.CertificateName).HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.ToTable("Education");

                entity.Property(e => e.EducationId).ValueGeneratedNever();

                entity.Property(e => e.AcademicProfile).HasMaxLength(50);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.SchoolName).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.JobId)
                    .ValueGeneratedNever()
                    .HasColumnName("JobID");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.JobName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Position).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.ProjectId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProjectID");

                entity.Property(e => e.ProjectName).HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("RoleID");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(500);

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasMany(d => d.Certificates)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserCertificate",
                        l => l.HasOne<Certificate>().WithMany().HasForeignKey("CertificateId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserCerti__Certi__5629CD9C"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserCerti__UserI__571DF1D5"),
                        j =>
                        {
                            j.HasKey("UserId", "CertificateId").HasName("PK__UserCert__1C3746D2D381CC8B");

                            j.ToTable("UserCertificate");

                            j.IndexerProperty<Guid>("UserId").HasColumnName("UserID");

                            j.IndexerProperty<Guid>("CertificateId").HasColumnName("CertificateID");
                        });

                entity.HasMany(d => d.Educations)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserEducation",
                        l => l.HasOne<Education>().WithMany().HasForeignKey("EducationId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserEduca__Educa__5EBF139D"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserEduca__UserI__5DCAEF64"),
                        j =>
                        {
                            j.HasKey("UserId", "EducationId").HasName("PK__UserEduc__53332F2C3C8D55CE");

                            j.ToTable("UserEducation");

                            j.IndexerProperty<Guid>("UserId").HasColumnName("UserID");
                        });

                entity.HasMany(d => d.Jobs)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserJob",
                        l => l.HasOne<Job>().WithMany().HasForeignKey("JobId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserJobs__JobID__5AEE82B9"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserJobs__UserID__59FA5E80"),
                        j =>
                        {
                            j.HasKey("UserId", "JobId").HasName("PK__UserJobs__27DEA5A2C401AE5D");

                            j.ToTable("UserJobs");

                            j.IndexerProperty<Guid>("UserId").HasColumnName("UserID");

                            j.IndexerProperty<Guid>("JobId").HasColumnName("JobID");
                        });

                entity.HasMany(d => d.Projects)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserProject",
                        l => l.HasOne<Project>().WithMany().HasForeignKey("ProjectId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserProje__Proje__45F365D3"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserProje__UserI__4316F928"),
                        j =>
                        {
                            j.HasKey("UserId", "ProjectId").HasName("PK__UserProj__00E96741A08F8388");

                            j.ToTable("UserProject");

                            j.IndexerProperty<Guid>("UserId").HasColumnName("UserID");

                            j.IndexerProperty<Guid>("ProjectId").HasColumnName("ProjectID");
                        });

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserRole",
                        l => l.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserRole__RoleId__34C8D9D1"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserRole__UserID__33D4B598"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId").HasName("PK__UserRole__AF27604DD1B396FE");

                            j.ToTable("UserRole");

                            j.IndexerProperty<Guid>("UserId").HasColumnName("UserID");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
