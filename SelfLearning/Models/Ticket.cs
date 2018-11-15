using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfLearning.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string TaskDetail { get; set; }
        public int Priority { get; set; }
        public string status { get; set; }

    }
}