using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SelfLearning.Models
{
    public class DepartmentTrack
    {
        [Key]
        public int Id { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<DepartmentTicket> DepartmentTicket { get; set; }
    }
}