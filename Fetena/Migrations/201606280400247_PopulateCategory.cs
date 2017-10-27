namespace Fetena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategory : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories(Name) VALUES('Primitive Types')");
            Sql("INSERT INTO Categories(Name) VALUES('Expression')");
            Sql("INSERT INTO Categories(Name) VALUES('Non-Primitive Types')");
            Sql("INSERT INTO Categories(Name) VALUES('Control Flow')");
            Sql("INSERT INTO Categories(Name) VALUES('Arrays')");
            Sql("INSERT INTO Categories(Name) VALUES('Lists')");
            Sql("INSERT INTO Categories(Name) VALUES('Text')");
            Sql("INSERT INTO Categories(Name) VALUES('Files')");
            Sql("INSERT INTO Categories(Name) VALUES('Classes')");
            Sql("INSERT INTO Categories(Name) VALUES('Inheritance')");
            Sql("INSERT INTO Categories(Name) VALUES('Polymorphism')");
            Sql("INSERT INTO Categories(Name) VALUES('Interfaces')");
            Sql("INSERT INTO Categories(Name) VALUES('Generics')");
            Sql("INSERT INTO Categories(Name) VALUES('LINQ')");
            Sql("INSERT INTO Categories(Name) VALUES('Delegates')");
            Sql("INSERT INTO Categories(Name) VALUES('Events')");
            Sql("INSERT INTO Categories(Name) VALUES('Lambda Expressions')");
            Sql("INSERT INTO Categories(Name) VALUES('Nullable Types')");
            Sql("INSERT INTO Categories(Name) VALUES('Dynamics')");
            Sql("INSERT INTO Categories(Name) VALUES('Exception Handling')");
            Sql("INSERT INTO Categories(Name) VALUES('Asynchronous Programming')");
            Sql("INSERT INTO Categories(Name) VALUES('Collections')");
            Sql("INSERT INTO Categories(Name) VALUES('Concurrent Collections')");
            Sql("INSERT INTO Categories(Name) VALUES('Language Internals')");
            Sql("INSERT INTO Categories(Name) VALUES('Routing')");
            Sql("INSERT INTO Categories(Name) VALUES('Services')");
            Sql("INSERT INTO Categories(Name) VALUES('Directives')");
            Sql("INSERT INTO Categories(Name) VALUES('Controllers')");
            Sql("INSERT INTO Categories(Name) VALUES('Unit Testing')");
            Sql("INSERT INTO Categories(Name) VALUES('Design Patterns')");

        }
        
        public override void Down()
        {
        }
    }
}
