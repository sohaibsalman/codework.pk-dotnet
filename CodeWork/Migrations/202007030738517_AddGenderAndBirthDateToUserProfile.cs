namespace CodeWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenderAndBirthDateToUserProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserProfiles", "Gender", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "Gender");
            DropColumn("dbo.UserProfiles", "DateOfBirth");
        }
    }
}
