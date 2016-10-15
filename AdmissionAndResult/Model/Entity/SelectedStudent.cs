using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.DataAnnotations;
using ClinicalReporting.Model.Wrapper;
namespace ClinicalReporting.Model
{


    [Alias("Selected_Student")]
    public partial class SelectedStudent
    {
        
        public SelectedStudent()
        {
        }
        

        [PrimaryKey]
        [Alias("Selected_Student_Id")]
        public System.Int64 SelectedStudentId { get; set; }

        [Alias("Student_Registeration_Number")]
        public System.String StudentRegisterationNumber { get; set; }

        [Alias("Aggregate")]
        public System.Double Aggregate { get; set; }

        [Alias("Course_Id")]
        public System.Int64 CourseId { get; set; }

        [Alias("CGPA Text")]
        public System.String CGPAText { get; set; }

        [Alias("SGPA")]
        public System.String Sgpa { get; set; }

        [Alias("Department_ID")]
        public System.Int64 DepartmentID { get; set; }

        [Ignore]
        public virtual Student Student { get; set; }
        [Ignore]
        public virtual Department Department { get; set; }
        [Ignore]
        public virtual Course Course { get; set; }
         [Ignore]
         public bool IsNew
         {
                get
                {
         
                  return this.SelectedStudentId == default(int);
         
                }
                
          }
          [Ignore]
          public bool IsDeleted { get; set; }
    }
}