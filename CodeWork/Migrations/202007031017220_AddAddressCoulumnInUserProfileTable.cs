namespace CodeWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressCoulumnInUserProfileTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "Address", c => c.String(maxLength: 511));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "Address");
        }
    }
}
