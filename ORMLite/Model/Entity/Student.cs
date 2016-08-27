using ServiceStack.DataAnnotations;
using System.Collections.Generic;

namespace AdmissionAndResult.Data
{


    [Alias("Student")]
    public partial class Student
    {
        
        public Student()
        {

            Courses = new List<Course>();

            VerifyingAgents = new List<VerifyingAgent>();
        }

        [PrimaryKey]
        [AutoIncrement]  
        [Alias("Student_Id")]
        public long StudentId { get; set; }

        [Alias("Student_Name")]
        public string StudentName { get; set; }

        [Alias("Student_Email")]
        public string StudentEmail { get; set; }

        [Alias("Father_Name")]
        public string FatherName { get; set; }

        [Alias("Father_Monthly_Income")]
        public string FatherMonthlyIncome { get; set; }

        [Alias("Father_Occupation")]
        public string FatherOccupation { get; set; }

        [Alias("Postal_Address")]
        public string PostalAddress { get; set; }

        [Alias("Permanent_Address")]
        public string PermanentAddress { get; set; }

        [Alias("Date_Of_Birth")]
        public string DateOfBirth { get; set; }

        [Alias("NIC_No")]
        public string NICNo { get; set; }

        [Alias("Blood_Group")]
        public string BloodGroup { get; set; }

        [Alias("Phone_Number")]
        public string PhoneNumber { get; set; }

        [Alias("Residental_Phone_Number")]
        public string ResidentalPhoneNumber { get; set; }

        [Alias("Date")]
        public string Date { get; set; }

        [Alias("Fathers_Number")]
        public string FathersNumber { get; set; }

        [Ignore]
        public virtual List<Course> Courses { get; set; }
        [Ignore]
        public virtual List<VerifyingAgent> VerifyingAgents { get; set; }
        [Ignore]
        public virtual Qualification Qualification { get; set; }
        [Ignore]
        public virtual SelectedStudent SelectedSelectedStudent { get; set; }
         [Ignore]
         public bool IsNew
         {
                get
                {
         
                  return this.StudentId == default(int);
         
                }
                
          }
          [Ignore]
          public bool IsDeleted { get; set; }
    }
}