namespace Fetena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateLevel : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Levels(Name) VALUES('Basic')");
            Sql("INSERT INTO Levels(Name) VALUES('Intermediate')");
            Sql("INSERT INTO Levels(Name) VALUES('Advanced')");
        }
        
        public override void Down()
        {
        }
    }
}
