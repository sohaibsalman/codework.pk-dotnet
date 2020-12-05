using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace codework_api.Models
{
    public partial class CodeWorkContext : DbContext
    {
        public CodeWorkContext()
        {
        }

        public CodeWorkContext(DbContextOptions<CodeWorkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Degree> Degrees { get; set; }
        public virtual DbSet<Field> Fields { get; set; }
        public virtual DbSet<Institution> Institutions { get; set; }
        public virtual DbSet<SkillType> SkillTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserEducation> UserEducations { get; set; }
        public virtual DbSet<UserExperience> UserExperiences { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<UserSkill> UserSkills { get; set; }
        public virtual DbSet<WorkIndustry> WorkIndustries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-BFHGHRM\\SQLEXPRESS; Initial Catalog=CodeWork.pk; Integrated Security=True; ConnectRetryCount=0");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Guid).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Degree>(entity =>
            {
                entity.Property(e => e.Guid).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Field>(entity =>
            {
                entity.Property(e => e.Guid).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Institution>(entity =>
            {
                entity.Property(e => e.Guid).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<SkillType>(entity =>
            {
                entity.Property(e => e.Guid).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Contact).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Guid).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.ProfilePicture).IsUnicode(false);

                entity.Property(e => e.Summary).IsUnicode(false);
            });

            modelBuilder.Entity<UserEducation>(entity =>
            {
                entity.Property(e => e.Guid).IsUnicode(false);

                entity.Property(e => e.Location).IsUnicode(false);

                entity.HasOne(d => d.Degree)
                    .WithMany(p => p.UserEducations)
                    .HasForeignKey(d => d.DegreeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Education_Degree");

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.UserEducations)
                    .HasForeignKey(d => d.FieldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Education_Field");

                entity.HasOne(d => d.Institution)
                    .WithMany(p => p.UserEducations)
                    .HasForeignKey(d => d.InstitutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Education_Institution");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserEducations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Education_User");
            });

            modelBuilder.Entity<UserExperience>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Guid).IsUnicode(false);

                entity.Property(e => e.JobTitle).IsUnicode(false);

                entity.Property(e => e.Location).IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.UserExperiences)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Experience_Company");

                entity.HasOne(d => d.Industry)
                    .WithMany(p => p.UserExperiences)
                    .HasForeignKey(d => d.IndustryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Experience_Work_Industry");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserExperiences)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Experience_User");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.Property(e => e.Guid).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Login_User");
            });

            modelBuilder.Entity<UserSkill>(entity =>
            {
                entity.Property(e => e.Guid).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.SkillType)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.SkillTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Skills_Skill_Type");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSkills)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Skills_User");
            });

            modelBuilder.Entity<WorkIndustry>(entity =>
            {
                entity.Property(e => e.Guid).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
