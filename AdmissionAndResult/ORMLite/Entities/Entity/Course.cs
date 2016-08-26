using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.DataAnnotations;

namespace AdmissionAndResult.Data
{



    public partial class Course
    {
    
        public Course()
        {
            CourceSelectedStudents = new List<SelectedStudent>();
        }

        [PrimaryKey]
        [AutoIncrement]  
        [Alias("Course_Id")]
        public long CourseId { get; set; }

        [Alias("Course_Name")]
        public string CourseName { get; set; }

        [Alias("Student_Id")]
        public long StudentId { get; set; }

        [Ignore]
        public virtual Student Student { get; set; }
        [Ignore]
        public virtual List<SelectedStudent> CourceSelectedStudents { get; set; }
         [Ignore]
         public bool IsNew
         {
                get
                {
         
                  return this.CourseId == default(int);
         
                }
                
          }
          [Ignore]
          public bool IsDeleted { get; set; }
    }
}