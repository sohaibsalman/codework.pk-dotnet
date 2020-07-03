namespace CodeWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserProfileTableColumns : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserEducations", "DegreeTitleId", "dbo.DegreeTitles");
            DropForeignKey("dbo.UserEducations", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.UserJobExperiences", "IndustryId", "dbo.Industries");
            DropForeignKey("dbo.UserJobExperiences", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.UserSkills", "SkillLevel_Id", "dbo.SkillLevels");
            DropForeignKey("dbo.UserSkills", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.Users", "UserProfileId", "dbo.UserProfiles");
            DropIndex("dbo.Users", new[] { "UserProfileId" });
            DropIndex("dbo.UserEducations", new[] { "DegreeTitleId" });
            DropIndex("dbo.UserEducations", new[] { "UserProfile_Id" });
            DropIndex("dbo.UserJobExperiences", new[] { "IndustryId" });
            DropIndex("dbo.UserJobExperiences", new[] { "UserProfile_Id" });
            DropIndex("dbo.UserSkills", new[] { "SkillLevel_Id" });
            DropIndex("dbo.UserSkills", new[] { "UserProfile_Id" });
            DropColumn("dbo.Users", "HasCompletedProfile");
            DropColumn("dbo.Users", "UserProfileId");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.UserEducations");
            DropTable("dbo.DegreeTitles");
            DropTable("dbo.UserJobExperiences");
            DropTable("dbo.Industries");
            DropTable("dbo.UserSkills");
            DropTable("dbo.SkillLevels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SkillLevels",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserSkills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SkillLevel_Id = c.Byte(),
                        UserProfile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Industries",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserJobExperiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                        CompanyName = c.String(),
                        IndustryId = c.Byte(nullable: false),
                        Location = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        IsCurrentlyWorking = c.Boolean(nullable: false),
                        UserProfile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DegreeTitles",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserEducations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DegreeTitleId = c.Byte(nullable: false),
                        InstitutionName = c.String(),
                        Location = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Grade = c.Double(nullable: false),
                        UserProfile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfilePicture = c.String(),
                        Summary = c.String(),
                        ContactNumber = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "UserProfileId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "HasCompletedProfile", c => c.Boolean(nullable: false));
            CreateIndex("dbo.UserSkills", "UserProfile_Id");
            CreateIndex("dbo.UserSkills", "SkillLevel_Id");
            CreateIndex("dbo.UserJobExperiences", "UserProfile_Id");
            CreateIndex("dbo.UserJobExperiences", "IndustryId");
            CreateIndex("dbo.UserEducations", "UserProfile_Id");
            CreateIndex("dbo.UserEducations", "DegreeTitleId");
            CreateIndex("dbo.Users", "UserProfileId");
            AddForeignKey("dbo.Users", "UserProfileId", "dbo.UserProfiles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserSkills", "UserProfile_Id", "dbo.UserProfiles", "Id");
            AddForeignKey("dbo.UserSkills", "SkillLevel_Id", "dbo.SkillLevels", "Id");
            AddForeignKey("dbo.UserJobExperiences", "UserProfile_Id", "dbo.UserProfiles", "Id");
            AddForeignKey("dbo.UserJobExperiences", "IndustryId", "dbo.Industries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserEducations", "UserProfile_Id", "dbo.UserProfiles", "Id");
            AddForeignKey("dbo.UserEducations", "DegreeTitleId", "dbo.DegreeTitles", "Id", cascadeDelete: true);
        }
    }
}
