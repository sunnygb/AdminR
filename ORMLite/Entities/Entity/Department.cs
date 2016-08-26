using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.DataAnnotations;

namespace AdmissionAndResult.Data
{



    public partial class Department
    {
    
        public Department()
        {
            SelectedStudents = new List<SelectedStudent>();
        }

        [PrimaryKey]
        [AutoIncrement]  
        [Alias("Department_ID")]
        public long DepartmentID { get; set; }

        [Alias("Department_Name")]
        public string DepartmentName { get; set; }

        [Alias("Student_Strength")]
        public long StudentStrength { get; set; }

        [Alias("HOD_Name")]
        public string HODName { get; set; }

        [Alias("Location")]
        public string Location { get; set; }

        [Ignore]
        public virtual List<SelectedStudent> SelectedStudents { get; set; }
         [Ignore]
         public bool IsNew
         {
                get
                {
         
                  return this.DepartmentID == default(int);
         
                }
                
          }
          [Ignore]
          public bool IsDeleted { get; set; }
    }
}