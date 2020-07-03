namespace CodeWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnotationsToUserProfileTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserProfiles", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.UserProfiles", "ProfilePicture", c => c.String(maxLength: 127));
            AlterColumn("dbo.UserProfiles", "Summary", c => c.String(maxLength: 1023));
            AlterColumn("dbo.UserProfiles", "ContactNumber", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.UserProfiles", "Location", c => c.String(nullable: false, maxLength: 127));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserProfiles", "Location", c => c.String());
            AlterColumn("dbo.UserProfiles", "ContactNumber", c => c.String());
            AlterColumn("dbo.UserProfiles", "Summary", c => c.String());
            AlterColumn("dbo.UserProfiles", "ProfilePicture", c => c.String());
            AlterColumn("dbo.UserProfiles", "Name", c => c.String());
        }
    }
}
