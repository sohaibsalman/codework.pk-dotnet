namespace CodeWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnotationsToUserTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 127));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 127));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 127));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String());
            AlterColumn("dbo.Users", "Name", c => c.String());
        }
    }
}
