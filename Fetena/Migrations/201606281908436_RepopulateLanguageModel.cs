namespace Fetena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RepopulateLanguageModel : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Languages(Name) VALUES('AngularJS')");
            Sql("INSERT INTO Languages(Name) VALUES('Asp.NET')");
            Sql("INSERT INTO Languages(Name) VALUES('Backbone.js')");
            Sql("INSERT INTO Languages(Name) VALUES('Bootstrap')");
            Sql("INSERT INTO Languages(Name) VALUES('C')");
            Sql("INSERT INTO Languages(Name) VALUES('C++')");
            Sql("INSERT INTO Languages(Name) VALUES('C#')");
            Sql("INSERT INTO Languages(Name) VALUES('D3.js')");
            Sql("INSERT INTO Languages(Name) VALUES('Express.js')");
            Sql("INSERT INTO Languages(Name) VALUES('ExtJS')");
            Sql("INSERT INTO Languages(Name) VALUES('Java')");
            Sql("INSERT INTO Languages(Name) VALUES('JavaScript')");
            Sql("INSERT INTO Languages(Name) VALUES('JQuery')");
            Sql("INSERT INTO Languages(Name) VALUES('Node.js')");
            Sql("INSERT INTO Languages(Name) VALUES('Objective-C')");
            Sql("INSERT INTO Languages(Name) VALUES('PHP')");
            Sql("INSERT INTO Languages(Name) VALUES('Python')");
            Sql("INSERT INTO Languages(Name) VALUES('React.js')");
            Sql("INSERT INTO Languages(Name) VALUES('Ruby')");
            Sql("INSERT INTO Languages(Name) VALUES('Ruby on Rail')");
            Sql("INSERT INTO Languages(Name) VALUES('SQL')");
            Sql("INSERT INTO Languages(Name) VALUES('Swift')");
            Sql("INSERT INTO Languages(Name) VALUES('Visual Basic')");

        }
        
        public override void Down()
        {
        }
    }
}
