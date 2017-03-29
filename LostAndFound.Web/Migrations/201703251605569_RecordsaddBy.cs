namespace LostAndFound.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecordsaddBy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Guid(nullable: false, identity: true),
                        Active = c.Boolean(nullable: false),
                        DateCreatedUTC = c.DateTime(nullable: false),
                        Notes = c.String(maxLength: 1000),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.LocationId);
            
            CreateTable(
                "dbo.LostItemReports",
                c => new
                    {
                        LostReportItemId = c.Guid(nullable: false, identity: true),
                        ItemName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 2048),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(),
                        LostDateTimeUTC = c.DateTime(nullable: false),
                        IPAdress = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                        DateCreatedUTC = c.DateTime(nullable: false),
                        Notes = c.String(maxLength: 1024),
                        LostItemType_TypeOfItemId = c.Guid(nullable: false),
                        LostLocation_LocationId = c.Guid(),
                        RecordEnteredBy_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.LostReportItemId)
                .ForeignKey("dbo.TypeOfItems", t => t.LostItemType_TypeOfItemId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LostLocation_LocationId)
                .ForeignKey("dbo.AspNetUsers", t => t.RecordEnteredBy_Id)
                .Index(t => t.LostItemType_TypeOfItemId)
                .Index(t => t.LostLocation_LocationId)
                .Index(t => t.RecordEnteredBy_Id);
            
            CreateTable(
                "dbo.TypeOfItems",
                c => new
                    {
                        TypeOfItemId = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Active = c.Boolean(nullable: false),
                        DateCreatedUTC = c.DateTime(nullable: false),
                        Notes = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.TypeOfItemId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Email = c.String(maxLength: 256),
                        JoinDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        CreatedBy_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.CreatedBy_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.LostItems",
                c => new
                    {
                        LostItemId = c.Guid(nullable: false, identity: true),
                        Active = c.Boolean(nullable: false),
                        DateCreatedUTC = c.DateTime(nullable: false),
                        Notes = c.String(maxLength: 1000),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 2048),
                        FoundDateInUtc = c.DateTime(nullable: false),
                        ReasonCaseClosed = c.String(maxLength: 2048),
                        CaseClosedBy_Id = c.Guid(),
                        FoundLocation_LocationId = c.Guid(nullable: false),
                        LostItemType_TypeOfItemId = c.Guid(nullable: false),
                        RecordEnteredBy_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.LostItemId)
                .ForeignKey("dbo.AspNetUsers", t => t.CaseClosedBy_Id)
                .ForeignKey("dbo.Locations", t => t.FoundLocation_LocationId, cascadeDelete: true)
                .ForeignKey("dbo.TypeOfItems", t => t.LostItemType_TypeOfItemId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.RecordEnteredBy_Id)
                .Index(t => t.CaseClosedBy_Id)
                .Index(t => t.FoundLocation_LocationId)
                .Index(t => t.LostItemType_TypeOfItemId)
                .Index(t => t.RecordEnteredBy_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.LostItems", "RecordEnteredBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.LostItems", "LostItemType_TypeOfItemId", "dbo.TypeOfItems");
            DropForeignKey("dbo.LostItems", "FoundLocation_LocationId", "dbo.Locations");
            DropForeignKey("dbo.LostItems", "CaseClosedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.LostItemReports", "RecordEnteredBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.LostItemReports", "LostLocation_LocationId", "dbo.Locations");
            DropForeignKey("dbo.LostItemReports", "LostItemType_TypeOfItemId", "dbo.TypeOfItems");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.LostItems", new[] { "RecordEnteredBy_Id" });
            DropIndex("dbo.LostItems", new[] { "LostItemType_TypeOfItemId" });
            DropIndex("dbo.LostItems", new[] { "FoundLocation_LocationId" });
            DropIndex("dbo.LostItems", new[] { "CaseClosedBy_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "CreatedBy_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.LostItemReports", new[] { "RecordEnteredBy_Id" });
            DropIndex("dbo.LostItemReports", new[] { "LostLocation_LocationId" });
            DropIndex("dbo.LostItemReports", new[] { "LostItemType_TypeOfItemId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.LostItems");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TypeOfItems");
            DropTable("dbo.LostItemReports");
            DropTable("dbo.Locations");
        }
    }
}
