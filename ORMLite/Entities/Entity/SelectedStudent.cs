using System;
using System.Collections.Generic;
using System.Text;

namespace AdmissionAndResult.Data
{



    public partial class SelectedStudent
    {
    
        public SelectedStudent()
        {
        }

        public long SelectedStudentId { get; set; }
        public string StudentRegisterationNumber { get; set; }
        public double? Aggregate { get; set; }
        public long? CourceId { get; set; }
        public string CGPAText { get; set; }
        public string Sgpa { get; set; }
        public long DepartmentID { get; set; }
        public long StudentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Course CourceCourse { get; set; }
        public virtual Student Student { get; set; }

         public bool IsNew
         {
                get
                {
         
                  return this.SelectedStudentId == default(int);
         
                }
                
          }
          public bool IsDeleted { get; set; }
    }
}