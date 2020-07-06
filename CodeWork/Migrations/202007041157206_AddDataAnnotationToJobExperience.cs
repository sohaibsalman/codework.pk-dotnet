namespace CodeWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotationToJobExperience : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserJobExperiences", "JobTitle", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.UserJobExperiences", "CompanyName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.UserJobExperiences", "Location", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserJobExperiences", "Location", c => c.String());
            AlterColumn("dbo.UserJobExperiences", "CompanyName", c => c.String());
            AlterColumn("dbo.UserJobExperiences", "JobTitle", c => c.String());
        }
    }
}
