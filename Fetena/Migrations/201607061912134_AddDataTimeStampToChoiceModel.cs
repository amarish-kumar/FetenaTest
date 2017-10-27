namespace Fetena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataTimeStampToChoiceModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Choices", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Choices", "DateModified", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Choices", "DateModified");
            DropColumn("dbo.Choices", "DateAdded");
        }
    }
}
