using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeWork.Models
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<UserEducation> UserEducations { get; set; }
        public DbSet<UserJobExperience> UserJobExperiences { get; set; }
        public DbSet<UserSkills> UserSkills { get; set; }

        public DbSet<DegreeTitle> DegreeTitles { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<SkillLevel> SkillLevels { get; set; }

        public ApplicationDbContext(): base("CodeWork")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, CodeWork.Migrations.Configuration>());
        }
    }
}