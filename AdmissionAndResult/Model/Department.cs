using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using AdmissionAndResult.Model.Wrapper;

namespace AdmissionAndResult.Model
{
    [Table("Department")]
    class Department
    {
        public Department(DepartmentW department)
        {
           
            this.Department_ID=department.Department_ID  ;
            this.Department_Name=department.Department_Name ;
            this.HOD_Name=department.HOD_Name  ;
            this.Location=department.Location  ;
            
            this.Student_Id= department.Student_Id  ;
            this.Student_Strength=department.Student_Strength  ;
        }

        public Department() { }
        [Key]
        public long Department_ID { get; set; }
        public long Student_Id { get; set; }
        public string Department_Name { get; set; }
        public long Student_Strength { get; set; }
        public string HOD_Name { get; set; }
        public string Location { get; set; }

    }
}
