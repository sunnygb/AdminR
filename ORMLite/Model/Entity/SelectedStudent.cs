using ServiceStack.DataAnnotations;

namespace AdmissionAndResult.Data
{


    [Alias("Selected_Student")]
    public partial class SelectedStudent
    {
        
        public SelectedStudent()
        {
        }

        [PrimaryKey]
        [AutoIncrement]  
        [Alias("Selected_Student_Id")]
        public long SelectedStudentId { get; set; }

        [Alias("Student_Registeration_Number")]
        public string StudentRegisterationNumber { get; set; }

        [Alias("Aggregate")]
        public double? Aggregate { get; set; }

        [Alias("Course_Id")]
        public long? CourseId { get; set; }

        [Alias("CGPA Text")]
        public string CGPAText { get; set; }

        [Alias("SGPA")]
        public string Sgpa { get; set; }

        [Alias("Department_ID")]
        public long DepartmentID { get; set; }

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