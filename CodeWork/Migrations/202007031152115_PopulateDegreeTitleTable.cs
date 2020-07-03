namespace CodeWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDegreeTitleTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO DegreeTitles (Id, Name) VALUES (1, 'Non-Matriculation')");
            Sql("INSERT INTO DegreeTitles (Id, Name) VALUES (2, 'Matriculation/O-Level')");
            Sql("INSERT INTO DegreeTitles (Id, Name) VALUES (3, 'Intermediate/A-Level')");
            Sql("INSERT INTO DegreeTitles (Id, Name) VALUES (4, 'BS')");
            Sql("INSERT INTO DegreeTitles (Id, Name) VALUES (5, 'BSc')");
            Sql("INSERT INTO DegreeTitles (Id, Name) VALUES (6, 'MS')");
            Sql("INSERT INTO DegreeTitles (Id, Name) VALUES (7, 'MSc')");
            Sql("INSERT INTO DegreeTitles (Id, Name) VALUES (8, 'MPhil')");
            Sql("INSERT INTO DegreeTitles (Id, Name) VALUES (9, 'PHD')");
            Sql("INSERT INTO DegreeTitles (Id, Name) VALUES (10, 'Diploma')");
            Sql("INSERT INTO DegreeTitles (Id, Name) VALUES (11, 'Certificate')");
            Sql("INSERT INTO DegreeTitles (Id, Name) VALUES (12, 'Short Course')");
        }
        
        public override void Down()
        {
        }
    }
}
