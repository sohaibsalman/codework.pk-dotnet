namespace CodeWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserAndUserProfileTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserProfiles", "UserId", "dbo.Users");
            DropIndex("dbo.UserProfiles", new[] { "UserId" });
            AddColumn("dbo.Users", "Profile_Id", c => c.Int());
            CreateIndex("dbo.Users", "Profile_Id");
            AddForeignKey("dbo.Users", "Profile_Id", "dbo.UserProfiles", "Id");
            DropColumn("dbo.UserProfiles", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfiles", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Users", "Profile_Id", "dbo.UserProfiles");
            DropIndex("dbo.Users", new[] { "Profile_Id" });
            DropColumn("dbo.Users", "Profile_Id");
            CreateIndex("dbo.UserProfiles", "UserId");
            AddForeignKey("dbo.UserProfiles", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
