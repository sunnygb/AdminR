﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace SystemDB.Data.Entities
{



    public partial class Student
    {
        public Student()
        {
            SelectedSelectedStudents = new List<SelectedStudent>();
            Departments = new List<Department>();
            Courses = new List<Course>();
            VerifyingAgents = new List<VerifyingAgent>();
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

        public virtual List<SelectedStudent> SelectedSelectedStudents { get; set; }
        public virtual List<Department> Departments { get; set; }
        public virtual List<Course> Courses { get; set; }
        public virtual List<VerifyingAgent> VerifyingAgents { get; set; }
        public virtual Qualification Qualification { get; set; }

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