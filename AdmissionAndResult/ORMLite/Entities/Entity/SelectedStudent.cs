using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.DataAnnotations;

namespace AdmissionAndResult.Data
{



    public partial class SelectedStudent
    {
    
        public SelectedStudent()
        {
        }

        [PrimaryKey]
        [AutoIncrement]  
        [Alias("Selected_Student_Id")]
        public long SelectedStudentId { get; set; }
        [PrimaryKey]
        [AutoIncrement]  
        [Alias("Student_Registeration_Number")]
        public string StudentRegisterationNumber { get; set; }

        [Alias("Aggregate")]
        public double? Aggregate { get; set; }

        [Alias("Cource_Id")]
        public long? CourceId { get; set; }

        [Alias("CGPA Text")]
        public string CGPAText { get; set; }

        [Alias("SGPA")]
        public string Sgpa { get; set; }

        [Alias("Department_ID")]
        public long DepartmentID { get; set; }
        [PrimaryKey]
        [AutoIncrement]  
        [Alias("Student_Id")]
        public long StudentId { get; set; }

        [Ignore]
        public virtual Department Department { get; set; }
        [Ignore]
        public virtual Course CourceCourse { get; set; }
        [Ignore]
        public virtual Student Student { get; set; }
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