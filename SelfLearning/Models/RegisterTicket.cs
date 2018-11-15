using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SelfLearning.Models
{
    public class RegisterTicket
    {
        [Key]
        public int Id { get; set; }
        public int TicketId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        
        [ForeignKey("TicketId")] 
        public Ticket Ticket { get; set; }

        public virtual ICollection<DepartmentTicket> DepartmentTicket { get; set; }
    }
}