using System;
using System.Collections.Generic;
using System.Text;

namespace AdmissionAndResult.Data
{



    public partial class Course
    {
    
        public Course()
        {
            CourceSelectedStudents = new List<SelectedStudent>();
        }

        public long CourseId { get; set; }
        public string CourseName { get; set; }
        public long StudentId { get; set; }

        public virtual Student Student { get; set; }
        public virtual List<SelectedStudent> CourceSelectedStudents { get; set; }

         public bool IsNew
         {
                get
                {
         
                  return this.CourseId == default(int);
         
                }
                
          }
          public bool IsDeleted { get; set; }
    }
}