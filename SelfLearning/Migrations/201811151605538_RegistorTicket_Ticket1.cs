namespace SelfLearning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegistorTicket_Ticket1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegisterTickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskDetail = c.String(),
                        Priority = c.Int(nullable: false),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TicketRegisterTickets",
                c => new
                    {
                        Ticket_Id = c.Int(nullable: false),
                        RegisterTicket_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ticket_Id, t.RegisterTicket_Id })
                .ForeignKey("dbo.Tickets", t => t.Ticket_Id, cascadeDelete: true)
                .ForeignKey("dbo.RegisterTickets", t => t.RegisterTicket_Id, cascadeDelete: true)
                .Index(t => t.Ticket_Id)
                .Index(t => t.RegisterTicket_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketRegisterTickets", "RegisterTicket_Id", "dbo.RegisterTickets");
            DropForeignKey("dbo.TicketRegisterTickets", "Ticket_Id", "dbo.Tickets");
            DropIndex("dbo.TicketRegisterTickets", new[] { "RegisterTicket_Id" });
            DropIndex("dbo.TicketRegisterTickets", new[] { "Ticket_Id" });
            DropTable("dbo.TicketRegisterTickets");
            DropTable("dbo.Tickets");
            DropTable("dbo.RegisterTickets");
        }
    }
}
