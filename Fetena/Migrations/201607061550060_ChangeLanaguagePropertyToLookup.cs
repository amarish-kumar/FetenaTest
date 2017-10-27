namespace Fetena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLanaguagePropertyToLookup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quizs", "LanguageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Quizs", "LanguageId");
            AddForeignKey("dbo.Quizs", "LanguageId", "dbo.Languages", "Id", cascadeDelete: true);
            DropColumn("dbo.Quizs", "ProgrammingLanguage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Quizs", "ProgrammingLanguage", c => c.String(nullable: false, maxLength: 255));
            DropForeignKey("dbo.Quizs", "LanguageId", "dbo.Languages");
            DropIndex("dbo.Quizs", new[] { "LanguageId" });
            DropColumn("dbo.Quizs", "LanguageId");
        }
    }
}
