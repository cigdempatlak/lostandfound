namespace LostAndFound.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class claimedbyfields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LostItemReports", "ClaimerFirstName", c => c.String(maxLength: 100));
            AddColumn("dbo.LostItemReports", "ClaimerLastName", c => c.String(maxLength: 100));
            AddColumn("dbo.LostItemReports", "ClaimerEmail", c => c.String(maxLength: 100));
            AddColumn("dbo.LostItemReports", "CaseClosedDateUTC", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LostItemReports", "CaseClosedDateUTC");
            DropColumn("dbo.LostItemReports", "ClaimerEmail");
            DropColumn("dbo.LostItemReports", "ClaimerLastName");
            DropColumn("dbo.LostItemReports", "ClaimerFirstName");
        }
    }
}
