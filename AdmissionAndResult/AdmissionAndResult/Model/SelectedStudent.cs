using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using AdmissionAndResult.Model.Wrapper;

namespace AdmissionAndResult.Model
{
     [Table("Selected_Student")]
    class SelectedStudent
    {
         public SelectedStudent(SelectedStudentW selectedStudent)
         {
             this.Selected_Student_Id = selectedStudent.Selected_Student_Id;
             this.Student_Registeration_Number = selectedStudent.Student_Registeration_Number;
             this.Aggregate = selectedStudent.Aggregate;
             this.Cource_Id = selectedStudent.Cource_Id;
             this.CGPA_Text = selectedStudent.CGPA_Text;
             this.SGPA = selectedStudent.SGPA;
             this.Department_ID = selectedStudent.Department_ID;
         }
         public SelectedStudent() { }









        [Key]
        public long Selected_Student_Id { get; set; }
        [Key]
        public string Student_Registeration_Number { get; set; }
        public double Aggregate { get; set; }
        public long Cource_Id { get; set; }
        public string CGPA_Text { get; set; }
        public string SGPA { get; set; }
        public long Department_ID { get; set; }
    }
}
