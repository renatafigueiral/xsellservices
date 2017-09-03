namespace XSellServices.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActionCalls",
                c => new
                    {
                        ActionCallID = c.Int(nullable: false, identity: true),
                        ActionExecuteDate = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        ActionTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActionCallID)
                .ForeignKey("dbo.ActionTypes", t => t.ActionTypeID, cascadeDelete: true)
                .Index(t => t.ActionTypeID);
            
            CreateTable(
                "dbo.ActionTypes",
                c => new
                    {
                        ActionTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ActionTypeID);
            
            CreateTable(
                "dbo.Calls",
                c => new
                    {
                        CallID = c.Int(nullable: false, identity: true),
                        Phone = c.String(),
                        IsOutboundCall = c.Boolean(nullable: false),
                        IsValidDataProtection = c.Boolean(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        LeadID = c.Int(nullable: false),
                        CallStatusID = c.Int(nullable: false),
                        ActionCallID = c.Int(),
                    })
                .PrimaryKey(t => t.CallID)
                .ForeignKey("dbo.ActionCalls", t => t.ActionCallID)
                .ForeignKey("dbo.CallStatus", t => t.CallStatusID, cascadeDelete: true)
                .ForeignKey("dbo.Leads", t => t.LeadID, cascadeDelete: true)
                .Index(t => t.LeadID)
                .Index(t => t.CallStatusID)
                .Index(t => t.ActionCallID);
            
            CreateTable(
                "dbo.CallStatus",
                c => new
                    {
                        CallStatusID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.CallStatusID);
            
            CreateTable(
                "dbo.Leads",
                c => new
                    {
                        LeadID = c.Int(nullable: false, identity: true),
                        RenewalDate = c.DateTime(nullable: false),
                        PortfolioCode = c.String(nullable: false),
                        ProductTypeID = c.Int(nullable: false),
                        InsurerID = c.Int(),
                        RankingID = c.Int(),
                    })
                .PrimaryKey(t => t.LeadID)
                .ForeignKey("dbo.Insurers", t => t.InsurerID)
                .ForeignKey("dbo.ProductTypes", t => t.ProductTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Rankings", t => t.RankingID)
                .Index(t => t.ProductTypeID)
                .Index(t => t.InsurerID)
                .Index(t => t.RankingID);
            
            CreateTable(
                "dbo.Insurers",
                c => new
                    {
                        InsurerID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        RelayCode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.InsurerID);
            
            CreateTable(
                "dbo.LeadNotesTracks",
                c => new
                    {
                        LeadNotesTrackID = c.Int(nullable: false, identity: true),
                        Note = c.String(nullable: false, maxLength: 300),
                        DateTime = c.DateTime(nullable: false),
                        LeadID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LeadNotesTrackID)
                .ForeignKey("dbo.Leads", t => t.LeadID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.LeadID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        WindowsUser = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.LeadStatusTracks",
                c => new
                    {
                        LeadStatusTrackID = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        LeadID = c.Int(nullable: false),
                        UserImplementerID = c.Int(nullable: false),
                        UserAssignedID = c.Int(),
                        LeadStatusID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LeadStatusTrackID)
                .ForeignKey("dbo.Leads", t => t.LeadID, cascadeDelete: true)
                .ForeignKey("dbo.LeadStatus", t => t.LeadStatusID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserAssignedID)
                .ForeignKey("dbo.Users", t => t.UserImplementerID, cascadeDelete: true)
                .Index(t => t.LeadID)
                .Index(t => t.UserImplementerID)
                .Index(t => t.UserAssignedID)
                .Index(t => t.LeadStatusID);
            
            CreateTable(
                "dbo.LeadStatus",
                c => new
                    {
                        LeadStatusID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.LeadStatusID);
            
            CreateTable(
                "dbo.PolicyCodes",
                c => new
                    {
                        PolicyCodeID = c.Int(nullable: false),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PolicyCodeID)
                .ForeignKey("dbo.LeadStatusTracks", t => t.PolicyCodeID)
                .Index(t => t.PolicyCodeID);
            
            CreateTable(
                "dbo.Reasons",
                c => new
                    {
                        ReasonID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ReasonID);
            
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        ProductTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        RelayCode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProductTypeID);
            
            CreateTable(
                "dbo.Rankings",
                c => new
                    {
                        RankingID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.RankingID);
            
            CreateTable(
                "dbo.ReasonLeadStatusTracks",
                c => new
                    {
                        Reason_ReasonID = c.Int(nullable: false),
                        LeadStatusTrack_LeadStatusTrackID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Reason_ReasonID, t.LeadStatusTrack_LeadStatusTrackID })
                .ForeignKey("dbo.Reasons", t => t.Reason_ReasonID, cascadeDelete: true)
                .ForeignKey("dbo.LeadStatusTracks", t => t.LeadStatusTrack_LeadStatusTrackID, cascadeDelete: true)
                .Index(t => t.Reason_ReasonID)
                .Index(t => t.LeadStatusTrack_LeadStatusTrackID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Leads", "RankingID", "dbo.Rankings");
            DropForeignKey("dbo.Leads", "ProductTypeID", "dbo.ProductTypes");
            DropForeignKey("dbo.LeadStatusTracks", "UserImplementerID", "dbo.Users");
            DropForeignKey("dbo.LeadStatusTracks", "UserAssignedID", "dbo.Users");
            DropForeignKey("dbo.ReasonLeadStatusTracks", "LeadStatusTrack_LeadStatusTrackID", "dbo.LeadStatusTracks");
            DropForeignKey("dbo.ReasonLeadStatusTracks", "Reason_ReasonID", "dbo.Reasons");
            DropForeignKey("dbo.PolicyCodes", "PolicyCodeID", "dbo.LeadStatusTracks");
            DropForeignKey("dbo.LeadStatusTracks", "LeadStatusID", "dbo.LeadStatus");
            DropForeignKey("dbo.LeadStatusTracks", "LeadID", "dbo.Leads");
            DropForeignKey("dbo.LeadNotesTracks", "UserID", "dbo.Users");
            DropForeignKey("dbo.LeadNotesTracks", "LeadID", "dbo.Leads");
            DropForeignKey("dbo.Leads", "InsurerID", "dbo.Insurers");
            DropForeignKey("dbo.Calls", "LeadID", "dbo.Leads");
            DropForeignKey("dbo.Calls", "CallStatusID", "dbo.CallStatus");
            DropForeignKey("dbo.Calls", "ActionCallID", "dbo.ActionCalls");
            DropForeignKey("dbo.ActionCalls", "ActionTypeID", "dbo.ActionTypes");
            DropIndex("dbo.ReasonLeadStatusTracks", new[] { "LeadStatusTrack_LeadStatusTrackID" });
            DropIndex("dbo.ReasonLeadStatusTracks", new[] { "Reason_ReasonID" });
            DropIndex("dbo.PolicyCodes", new[] { "PolicyCodeID" });
            DropIndex("dbo.LeadStatusTracks", new[] { "LeadStatusID" });
            DropIndex("dbo.LeadStatusTracks", new[] { "UserAssignedID" });
            DropIndex("dbo.LeadStatusTracks", new[] { "UserImplementerID" });
            DropIndex("dbo.LeadStatusTracks", new[] { "LeadID" });
            DropIndex("dbo.LeadNotesTracks", new[] { "UserID" });
            DropIndex("dbo.LeadNotesTracks", new[] { "LeadID" });
            DropIndex("dbo.Leads", new[] { "RankingID" });
            DropIndex("dbo.Leads", new[] { "InsurerID" });
            DropIndex("dbo.Leads", new[] { "ProductTypeID" });
            DropIndex("dbo.Calls", new[] { "ActionCallID" });
            DropIndex("dbo.Calls", new[] { "CallStatusID" });
            DropIndex("dbo.Calls", new[] { "LeadID" });
            DropIndex("dbo.ActionCalls", new[] { "ActionTypeID" });
            DropTable("dbo.ReasonLeadStatusTracks");
            DropTable("dbo.Rankings");
            DropTable("dbo.ProductTypes");
            DropTable("dbo.Reasons");
            DropTable("dbo.PolicyCodes");
            DropTable("dbo.LeadStatus");
            DropTable("dbo.LeadStatusTracks");
            DropTable("dbo.Users");
            DropTable("dbo.LeadNotesTracks");
            DropTable("dbo.Insurers");
            DropTable("dbo.Leads");
            DropTable("dbo.CallStatus");
            DropTable("dbo.Calls");
            DropTable("dbo.ActionTypes");
            DropTable("dbo.ActionCalls");
        }
    }
}
