﻿using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack.DataAnnotations;
using ClinicalReporting.Model.Wrapper;
namespace ClinicalReporting.Model
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
        [Alias("Student_Id")]
        public System.Int64 StudentId { get; set; }

        [Alias("Student_Name")]
        public System.String StudentName { get; set; }

        [Alias("Student_Email")]
        public System.String StudentEmail { get; set; }

        [Alias("Father_Name")]
        public System.String FatherName { get; set; }

        [Alias("Father_Monthly_Income")]
        public System.String FatherMonthlyIncome { get; set; }

        [Alias("Father_Occupation")]
        public System.String FatherOccupation { get; set; }

        [Alias("Postal_Address")]
        public System.String PostalAddress { get; set; }

        [Alias("Permanent_Address")]
        public System.String PermanentAddress { get; set; }

        [Alias("Date_Of_Birth")]
        public System.String DateOfBirth { get; set; }

        [Alias("NIC_No")]
        public System.String NICNo { get; set; }

        [Alias("Blood_Group")]
        public System.String BloodGroup { get; set; }

        [Alias("Phone_Number")]
        public System.String PhoneNumber { get; set; }

        [Alias("Residental_Phone_Number")]
        public System.String ResidentalPhoneNumber { get; set; }

        [Alias("Date")]
        public System.String Date { get; set; }

        [Alias("Fathers_Number")]
        public System.String FathersNumber { get; set; }

        [Ignore]
        public virtual List<Course> Courses { get; set; }
        [Ignore]
        public virtual List<VerifyingAgent> VerifyingAgents { get; set; }
        [Ignore]
        public virtual Qualification Qualification { get; set; }
        [Ignore]
        public virtual SelectedStudent SelectedStudent { get; set; }
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