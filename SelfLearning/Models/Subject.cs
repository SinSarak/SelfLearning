using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SelfLearning.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}