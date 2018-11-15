using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SelfLearning.Models
{
    //https://stackoverflow.com/questions/7050404/create-code-first-many-to-many-with-additional-fields-in-association-table
    public class DepartmentTicket
    {
        [Key,Column(Order = 0)]
        public int DeparmentTrickId { get; set; }
        [Key,Column(Order = 1)]
        public int RegisterTicketId { get; set; }

        public virtual DepartmentTrack DepartmentTrack { get; set; }
        public virtual RegisterTicket RegisterTicket { get;set;}
        
        public bool Approved { get; set;}
    }
}