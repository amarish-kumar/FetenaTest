namespace Fetena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLevelPropertyToLookup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quizs", "LevelId", c => c.Int(nullable: false));
            CreateIndex("dbo.Quizs", "LevelId");
            AddForeignKey("dbo.Quizs", "LevelId", "dbo.Levels", "Id", cascadeDelete: true);
            DropColumn("dbo.Quizs", "Level");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Quizs", "Level", c => c.String(nullable: false, maxLength: 255));
            DropForeignKey("dbo.Quizs", "LevelId", "dbo.Levels");
            DropIndex("dbo.Quizs", new[] { "LevelId" });
            DropColumn("dbo.Quizs", "LevelId");
        }
    }
}
