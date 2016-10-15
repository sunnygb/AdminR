using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.DataAnnotations;
using ClinicalReporting.Model.Wrapper;
namespace ClinicalReporting.Model
{


    [Alias("Department")]
    public partial class Department
    {
        
        public Department()
        {
            SelectedStudents = new List<SelectedStudent>();
        }
        

        [PrimaryKey]
        [Alias("Department_ID")]
        public System.Int64 DepartmentID { get; set; }

        [Alias("Department_Name")]
        public System.String DepartmentName { get; set; }

        [Alias("Student_Strength")]
        public System.Int64 StudentStrength { get; set; }

        [Alias("HOD_Name")]
        public System.String HODName { get; set; }

        [Alias("Location")]
        public System.String Location { get; set; }

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