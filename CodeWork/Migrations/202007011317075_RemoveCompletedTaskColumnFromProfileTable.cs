namespace CodeWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCompletedTaskColumnFromProfileTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserProfiles", "HasCompletedProfile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfiles", "HasCompletedProfile", c => c.Boolean(nullable: false));
        }
    }
}
