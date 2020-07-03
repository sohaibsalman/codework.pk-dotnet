namespace CodeWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNameColumnFromUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "Name", c => c.String());
            DropColumn("dbo.Users", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.UserProfiles", "Name");
        }
    }
}
