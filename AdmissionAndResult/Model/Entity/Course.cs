using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.DataAnnotations;
using ClinicalReporting.Model.Wrapper;
namespace ClinicalReporting.Model
{


    [Alias("Course")]
    public partial class Course
    {
        
        public Course()
        {
            SelectedStudents = new List<SelectedStudent>();
        }
        

        [PrimaryKey]
        [Alias("Course_Id")]
        public System.Int64 CourseId { get; set; }

        [Alias("Course_Name")]
        public System.String CourseName { get; set; }

        [Alias("Student_Id")]
        public System.Int64 StudentId { get; set; }

        [Ignore]
        public virtual Student Student { get; set; }
        [Ignore]
        public virtual List<SelectedStudent> SelectedStudents { get; set; }
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