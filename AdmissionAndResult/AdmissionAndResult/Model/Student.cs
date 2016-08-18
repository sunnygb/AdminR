
using Dapper.Contrib.Extensions;

namespace AdmissionAndResult.Model
{
    [Table("Student")]
    class Student
    {
        public Student(Student student)
        {
            this.Student_Id = student.Student_Id;
            this.Student_Name = student.Student_Name;
            this.Student_Email = student.Student_Email;
            this.Father_Name = student.Father_Name;
            this.Fathers_Number = student.Fathers_Number;
            this.Father_Monthly_Income = student.Father_Monthly_Income;
            this.Father_Occupation = student.Father_Occupation;
            this.Postal_Address = student.Postal_Address;
            this.Permanent_Address = student.Permanent_Address;
            this.Date_Of_Birth = student.Date_Of_Birth;
            this.NIC_No = student.NIC_No;
            this.Blood_Group = student.Blood_Group;
            this.Phone_Number = student.Phone_Number;
            this.Residental_Phone_Number = student.Residental_Phone_Number;
            this.Date = student.Date;
            this.Verified_Bachelor_CGPA = student.Verified_Bachelor_CGPA;
            this.Verified_FSC_Marks = student.Verified_FSC_Marks;
            this.Verified_GAT_Marks = student.Verified_GAT_Marks;
            this.Verified_Matric_Marks = student.Verified_Matric_Marks;
            this.Verified_NTS_Marks = student.Verified_NTS_Marks;
            //this.Image = student.Image;

        }

        public Student() { }
         [Key]
        public long Student_Id { get; set; }
        public string Student_Name { get; set; }
        public string Student_Email { get; set; }
        public string Father_Name { get; set; }
        public string Fathers_Number { get; set; }
        public string Father_Monthly_Income { get; set; }
        public string Father_Occupation { get; set; }
        public string Postal_Address { get; set; }
        public string Permanent_Address { get; set; }
        public string Date_Of_Birth { get; set; }
        public string NIC_No { get; set; }
        public string Blood_Group { get; set; }
        public string Phone_Number { get; set; }
        public string Residental_Phone_Number { get; set; }
        public string Date { get; set; }
        public long Verified_Matric_Marks { get; set; }
        public long Verified_FSC_Marks { get; set; }
        public long Verified_NTS_Marks { get; set; }
        public long Verified_GAT_Marks { get; set; }
        public long Verified_Bachelor_CGPA { get; set; }
        //public Image Image { get; set; }

    }
}
