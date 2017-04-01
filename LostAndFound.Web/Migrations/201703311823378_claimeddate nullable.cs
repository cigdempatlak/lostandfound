namespace LostAndFound.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class claimeddatenullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LostItemReports", "CaseClosedDateUTC", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LostItemReports", "CaseClosedDateUTC", c => c.DateTime(nullable: false));
        }
    }
}
