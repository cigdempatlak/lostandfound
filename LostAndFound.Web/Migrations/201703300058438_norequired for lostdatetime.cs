namespace LostAndFound.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class norequiredforlostdatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LostItemReports", "FoundDateInUtc", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LostItemReports", "FoundDateInUtc", c => c.DateTime(nullable: false));
        }
    }
}
