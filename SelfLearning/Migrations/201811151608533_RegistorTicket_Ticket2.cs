namespace SelfLearning.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegistorTicket_Ticket2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TicketRegisterTickets", "Ticket_Id", "dbo.Tickets");
            DropForeignKey("dbo.TicketRegisterTickets", "RegisterTicket_Id", "dbo.RegisterTickets");
            DropIndex("dbo.TicketRegisterTickets", new[] { "Ticket_Id" });
            DropIndex("dbo.TicketRegisterTickets", new[] { "RegisterTicket_Id" });
            AddColumn("dbo.RegisterTickets", "TicketId", c => c.Int(nullable: false));
            CreateIndex("dbo.RegisterTickets", "TicketId");
            AddForeignKey("dbo.RegisterTickets", "TicketId", "dbo.Tickets", "Id", cascadeDelete: true);
            DropTable("dbo.TicketRegisterTickets");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TicketRegisterTickets",
                c => new
                    {
                        Ticket_Id = c.Int(nullable: false),
                        RegisterTicket_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ticket_Id, t.RegisterTicket_Id });
            
            DropForeignKey("dbo.RegisterTickets", "TicketId", "dbo.Tickets");
            DropIndex("dbo.RegisterTickets", new[] { "TicketId" });
            DropColumn("dbo.RegisterTickets", "TicketId");
            CreateIndex("dbo.TicketRegisterTickets", "RegisterTicket_Id");
            CreateIndex("dbo.TicketRegisterTickets", "Ticket_Id");
            AddForeignKey("dbo.TicketRegisterTickets", "RegisterTicket_Id", "dbo.RegisterTickets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TicketRegisterTickets", "Ticket_Id", "dbo.Tickets", "Id", cascadeDelete: true);
        }
    }
}
