using AdmissionAndResult.Data.Wrapper;
using ServiceStack.DataAnnotations;
using System.Collections.Generic;
namespace AdmissionAndResult.Data
{


    [Alias("Course")]
    public partial class Course
    {
        
        public Course()
        {
            SelectedStudents = new List<SelectedStudent>();
        }
        
        public Course(CourseW coursew)
        {
           this.CourseId = coursew.CourseId;
           this.CourseName = coursew.CourseName;
           this.StudentId = coursew.StudentId;
           
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