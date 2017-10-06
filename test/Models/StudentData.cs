using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class StudentData
    {
        [Key]
        public long student_id{get;set;}
        
        [Required]
        [DisplayName("Student Name")]
        public string student_name { get; set; }
    }
}