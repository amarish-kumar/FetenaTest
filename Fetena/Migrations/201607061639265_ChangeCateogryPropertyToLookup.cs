namespace Fetena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCateogryPropertyToLookup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quizs", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Quizs", "CategoryId");
            AddForeignKey("dbo.Quizs", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            DropColumn("dbo.Quizs", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Quizs", "Category", c => c.String(nullable: false, maxLength: 255));
            DropForeignKey("dbo.Quizs", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Quizs", new[] { "CategoryId" });
            DropColumn("dbo.Quizs", "CategoryId");
        }
    }
}
