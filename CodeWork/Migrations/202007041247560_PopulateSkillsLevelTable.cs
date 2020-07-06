namespace CodeWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateSkillsLevelTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO SkillLevels (Id, Name) VALUES (1, 'Beginner')");
            Sql("INSERT INTO SkillLevels (Id, Name) VALUES (2, 'Intermediate')");
            Sql("INSERT INTO SkillLevels (Id, Name) VALUES (3, 'Advanced')");
        }
        
        public override void Down()
        {
        }
    }
}
