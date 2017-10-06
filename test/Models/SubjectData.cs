using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace test.Models
{
    public class SubjectData
    {
        public long subject_id;
        public long student_id;

        [Required]
        public string subject_name;

        [Required]
        public decimal marks;

    }
}