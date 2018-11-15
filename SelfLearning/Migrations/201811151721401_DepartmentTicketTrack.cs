namespace SelfLearning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartmentTicketTrack : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartmentTickets",
                c => new
                    {
                        DeparmentTrickId = c.Int(nullable: false),
                        RegisterTicketId = c.Int(nullable: false),
                        Approved = c.Boolean(nullable: false),
                        DepartmentTrack_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.DeparmentTrickId, t.RegisterTicketId })
                .ForeignKey("dbo.DepartmentTracks", t => t.DepartmentTrack_Id)
                .ForeignKey("dbo.RegisterTickets", t => t.RegisterTicketId, cascadeDelete: true)
                .Index(t => t.RegisterTicketId)
                .Index(t => t.DepartmentTrack_Id);
            
            CreateTable(
                "dbo.DepartmentTracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DepartmentTickets", "RegisterTicketId", "dbo.RegisterTickets");
            DropForeignKey("dbo.DepartmentTickets", "DepartmentTrack_Id", "dbo.DepartmentTracks");
            DropIndex("dbo.DepartmentTickets", new[] { "DepartmentTrack_Id" });
            DropIndex("dbo.DepartmentTickets", new[] { "RegisterTicketId" });
            DropTable("dbo.DepartmentTracks");
            DropTable("dbo.DepartmentTickets");
        }
    }
}
