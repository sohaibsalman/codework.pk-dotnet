namespace CodeWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSkillLevelIdToUserSkills : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserSkills", "SkillLevelId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserSkills", "SkillLevelId");
        }
    }
}
