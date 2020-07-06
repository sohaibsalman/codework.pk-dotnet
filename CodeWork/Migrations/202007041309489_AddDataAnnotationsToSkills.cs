namespace CodeWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotationsToSkills : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserSkills", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserSkills", "Name", c => c.String());
        }
    }
}
