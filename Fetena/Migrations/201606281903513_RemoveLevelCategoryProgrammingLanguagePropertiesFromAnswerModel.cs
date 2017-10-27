namespace Fetena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveLevelCategoryProgrammingLanguagePropertiesFromAnswerModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Answers", "ProgrammingLanguage");
            DropColumn("dbo.Answers", "Level");
            DropColumn("dbo.Answers", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "Category", c => c.String());
            AddColumn("dbo.Answers", "Level", c => c.String());
            AddColumn("dbo.Answers", "ProgrammingLanguage", c => c.String());
        }
    }
}
