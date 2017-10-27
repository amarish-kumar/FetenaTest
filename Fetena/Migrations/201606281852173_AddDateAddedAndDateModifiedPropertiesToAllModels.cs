namespace Fetena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateAddedAndDateModifiedPropertiesToAllModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quizs", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Categories", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Categories", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Languages", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Languages", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Levels", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Levels", "DateModified", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Levels", "DateModified");
            DropColumn("dbo.Levels", "DateAdded");
            DropColumn("dbo.Languages", "DateModified");
            DropColumn("dbo.Languages", "DateAdded");
            DropColumn("dbo.Categories", "DateModified");
            DropColumn("dbo.Categories", "DateAdded");
            DropColumn("dbo.Quizs", "DateModified");
        }
    }
}
