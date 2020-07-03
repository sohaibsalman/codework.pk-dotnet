namespace CodeWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUserProfileAndDependentTables1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfilePicture = c.String(),
                        Summary = c.String(),
                        ContactNumber = c.String(),
                        Location = c.String(),
                        HasCompletedProfile = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DegreeTitles", t => t.DegreeTitleId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_Id)
                .Index(t => t.DegreeTitleId)
                .Index(t => t.UserProfile_Id);
            
            CreateTable(
                "dbo.DegreeTitles",
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Industries", t => t.IndustryId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_Id)
                .Index(t => t.IndustryId)
                .Index(t => t.UserProfile_Id);
            
            CreateTable(
                "dbo.Industries",
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SkillLevels", t => t.SkillLevel_Id)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_Id)
                .Index(t => t.SkillLevel_Id)
                .Index(t => t.UserProfile_Id);
            
            CreateTable(
                "dbo.SkillLevels",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfiles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserSkills", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.UserSkills", "SkillLevel_Id", "dbo.SkillLevels");
            DropForeignKey("dbo.UserJobExperiences", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.UserJobExperiences", "IndustryId", "dbo.Industries");
            DropForeignKey("dbo.UserEducations", "UserProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.UserEducations", "DegreeTitleId", "dbo.DegreeTitles");
            DropIndex("dbo.UserSkills", new[] { "UserProfile_Id" });
            DropIndex("dbo.UserSkills", new[] { "SkillLevel_Id" });
            DropIndex("dbo.UserJobExperiences", new[] { "UserProfile_Id" });
            DropIndex("dbo.UserJobExperiences", new[] { "IndustryId" });
            DropIndex("dbo.UserEducations", new[] { "UserProfile_Id" });
            DropIndex("dbo.UserEducations", new[] { "DegreeTitleId" });
            DropIndex("dbo.UserProfiles", new[] { "UserId" });
            DropTable("dbo.SkillLevels");
            DropTable("dbo.UserSkills");
            DropTable("dbo.Industries");
            DropTable("dbo.UserJobExperiences");
            DropTable("dbo.DegreeTitles");
            DropTable("dbo.UserEducations");
            DropTable("dbo.UserProfiles");
        }
    }
}
