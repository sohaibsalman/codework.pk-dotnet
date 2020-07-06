namespace CodeWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotationsToUserEducation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserEducations", "FieldOfStudy", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.UserEducations", "InstitutionName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.UserEducations", "Location", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.UserEducations", "Grade", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserEducations", "Grade", c => c.Double(nullable: false));
            AlterColumn("dbo.UserEducations", "Location", c => c.String());
            AlterColumn("dbo.UserEducations", "InstitutionName", c => c.String());
            DropColumn("dbo.UserEducations", "FieldOfStudy");
        }
    }
}
