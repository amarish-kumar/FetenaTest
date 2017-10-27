namespace Fetena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateAddedAndDateModifiedPropertiesToAllModels1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "DateModified", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Answers", "DateModified");
        }
    }
}
