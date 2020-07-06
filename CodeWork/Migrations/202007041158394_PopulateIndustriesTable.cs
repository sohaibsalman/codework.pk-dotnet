namespace CodeWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateIndustriesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Industries (Id, Name) VALUES (1, 'Web Design')");
            Sql("INSERT INTO Industries (Id, Name) VALUES (2, 'Web Development')");
            Sql("INSERT INTO Industries (Id, Name) VALUES (3, 'Desktop Development')");
            Sql("INSERT INTO Industries (Id, Name) VALUES (4, 'Mobile Development')");
            Sql("INSERT INTO Industries (Id, Name) VALUES (5, 'Embedded Development')");
            Sql("INSERT INTO Industries (Id, Name) VALUES (6, 'Computer Networking')");
            Sql("INSERT INTO Industries (Id, Name) VALUES (7, 'AI')");
            Sql("INSERT INTO Industries (Id, Name) VALUES (8, 'Data Science')");
            Sql("INSERT INTO Industries (Id, Name) VALUES (9, 'Block Chain')");
            Sql("INSERT INTO Industries (Id, Name) VALUES (10, 'IoT')");
            Sql("INSERT INTO Industries (Id, Name) VALUES (11, 'Cloud Computing')");
        }
        
        public override void Down()
        {
        }
    }
}
