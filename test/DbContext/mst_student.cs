//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace test.DbContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
    
    public partial class mst_student
    {
        public mst_student()
        {
            this.mst_subjectmarks = new HashSet<mst_subjectmarks>();
        }
        [DisplayName("Id")]
        public long student_id { get; set; }
        
        [DisplayName("Student Name")]
        [Required]
        public string student_name { get; set; }
    
        public virtual ICollection<mst_subjectmarks> mst_subjectmarks { get; set; }
    }
}