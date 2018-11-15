using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SelfLearning.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string StudentName { get; set; }
        public int age { get; set; }
        public int SubjectId { get; set; }

        public Subject Subjects { get; set; }
    }

}