using System;
using System.Collections.Generic;
using System.Text;

namespace AdmissionAndResult.Data
{



    public partial class Department
    {
    
        public Department()
        {
            SelectedStudents = new List<SelectedStudent>();
        }

        public long DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public long StudentStrength { get; set; }
        public string HODName { get; set; }
        public string Location { get; set; }

        public virtual List<SelectedStudent> SelectedStudents { get; set; }

         public bool IsNew
         {
                get
                {
         
                  return this.DepartmentID == default(int);
         
                }
                
          }
          public bool IsDeleted { get; set; }
    }
}