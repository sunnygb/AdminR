using System;
using System.Collections.Generic;
using System.Text;

namespace AdmissionAndResult.Data
{



    public partial class Student
    {
    
        public Student()
        {
            Courses = new List<Course>();
            VerifyingAgents = new List<VerifyingAgent>();
            SelectedStudents = new List<SelectedStudent>();
        }

        public long StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string FatherName { get; set; }
        public string FatherMonthlyIncome { get; set; }
        public string FatherOccupation { get; set; }
        public string PostalAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string DateOfBirth { get; set; }
        public string NICNo { get; set; }
        public string BloodGroup { get; set; }
        public string PhoneNumber { get; set; }
        public string ResidentalPhoneNumber { get; set; }
        public string Date { get; set; }
        public string FathersNumber { get; set; }

        public virtual List<Course> Courses { get; set; }
        public virtual List<VerifyingAgent> VerifyingAgents { get; set; }
        public virtual Qualification Qualification { get; set; }
        public virtual List<SelectedStudent> SelectedStudents { get; set; }

         public bool IsNew
         {
                get
                {
         
                  return this.StudentId == default(int);
         
                }
                
          }
          public bool IsDeleted { get; set; }
    }
}