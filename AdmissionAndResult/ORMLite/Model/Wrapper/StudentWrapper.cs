using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using AdmissionAndResult.Data;
using AdmissionAndResult.Data.Services;
using AdmissionAndResult.Data.Wrapper;

namespace AdmissionAndResult.Data.Wrapper
{
    public partial class StudentW : ValidateModelCommon
    {
        public StudentW(Student student)
        {
           this._studentid = student.StudentId;
           
           this._studentname = student.StudentName;
           
           this._studentemail = student.StudentEmail;
           
           this._fathername = student.FatherName;
           
           this._fathermonthlyincome = student.FatherMonthlyIncome;
           
           this._fatheroccupation = student.FatherOccupation;
           
           this._postaladdress = student.PostalAddress;
           
           this._permanentaddress = student.PermanentAddress;
           
           this._dateofbirth = student.DateOfBirth;
           
           this._nicno = student.NICNo;
           
           this._bloodgroup = student.BloodGroup;
           
           this._phonenumber = student.PhoneNumber;
           
           this._residentalphonenumber = student.ResidentalPhoneNumber;
           
           this._date = student.Date;
           
           this._fathersnumber = student.FathersNumber;
           
           
           // One To Many
           if(student.Courses !=null)
           {
              this._coursesw = new ObservableCollection<CourseW>(
              student.Courses.Select(e=>new CourseW(e)));
           }
           
           // One To Many
           if(student.VerifyingAgents !=null)
           {
              this._verifyingagentsw = new ObservableCollection<VerifyingAgentW>(
              student.VerifyingAgents.Select(e=>new VerifyingAgentW(e)));
           }
           
           // One To One
           if(student.Qualification !=null)
           {
               this._qualificationw = new QualificationW(
               student.Qualification);
           }
           // One To One
           if(student.SelectedSelectedStudent !=null)
           {
               this._selectedselectedstudentw = new SelectedStudentW(
               student.SelectedSelectedStudent);
           }

        }
        
        public StudentW(){}
        
        private System.Int64 _studentid;
        public  System.Int64  studentid
        {
           get { return _studentid; }
           set { ChangeNvalidate(ref  _studentid,value); }
        }
        private System.String _studentname;
        public  System.String  studentname
        {
           get { return _studentname; }
           set { ChangeNvalidate(ref  _studentname,value); }
        }
        private System.String _studentemail;
        public  System.String  studentemail
        {
           get { return _studentemail; }
           set { ChangeNvalidate(ref  _studentemail,value); }
        }
        private System.String _fathername;
        public  System.String  fathername
        {
           get { return _fathername; }
           set { ChangeNvalidate(ref  _fathername,value); }
        }
        private System.String _fathermonthlyincome;
        public  System.String  fathermonthlyincome
        {
           get { return _fathermonthlyincome; }
           set { ChangeNvalidate(ref  _fathermonthlyincome,value); }
        }
        private System.String _fatheroccupation;
        public  System.String  fatheroccupation
        {
           get { return _fatheroccupation; }
           set { ChangeNvalidate(ref  _fatheroccupation,value); }
        }
        private System.String _postaladdress;
        public  System.String  postaladdress
        {
           get { return _postaladdress; }
           set { ChangeNvalidate(ref  _postaladdress,value); }
        }
        private System.String _permanentaddress;
        public  System.String  permanentaddress
        {
           get { return _permanentaddress; }
           set { ChangeNvalidate(ref  _permanentaddress,value); }
        }
        private System.String _dateofbirth;
        public  System.String  dateofbirth
        {
           get { return _dateofbirth; }
           set { ChangeNvalidate(ref  _dateofbirth,value); }
        }
        private System.String _nicno;
        public  System.String  nicno
        {
           get { return _nicno; }
           set { ChangeNvalidate(ref  _nicno,value); }
        }
        private System.String _bloodgroup;
        public  System.String  bloodgroup
        {
           get { return _bloodgroup; }
           set { ChangeNvalidate(ref  _bloodgroup,value); }
        }
        private System.String _phonenumber;
        public  System.String  phonenumber
        {
           get { return _phonenumber; }
           set { ChangeNvalidate(ref  _phonenumber,value); }
        }
        private System.String _residentalphonenumber;
        public  System.String  residentalphonenumber
        {
           get { return _residentalphonenumber; }
           set { ChangeNvalidate(ref  _residentalphonenumber,value); }
        }
        private System.String _date;
        public  System.String  date
        {
           get { return _date; }
           set { ChangeNvalidate(ref  _date,value); }
        }
        private System.String _fathersnumber;
        public  System.String  fathersnumber
        {
           get { return _fathersnumber; }
           set { ChangeNvalidate(ref  _fathersnumber,value); }
        }
        
        // One To Many
        private ObservableCollection<CourseW> _coursesw;
        public  ObservableCollection<CourseW>  coursesw
        {
           get { return _coursesw; }
           set { ChangeNvalidate(ref _coursesw,value); }
        }
        // One To Many
        private ObservableCollection<VerifyingAgentW> _verifyingagentsw;
        public  ObservableCollection<VerifyingAgentW>  verifyingagentsw
        {
           get { return _verifyingagentsw; }
           set { ChangeNvalidate(ref _verifyingagentsw,value); }
        }
        // One To One
        private QualificationW _qualificationw;
        public  QualificationW  qualificationw
        {
           get { return _qualificationw; }
           set { ChangeNvalidate(ref _qualificationw,value); }
        }
        // One To One
        private SelectedStudentW _selectedselectedstudentw;
        public  SelectedStudentW  selectedselectedstudentw
        {
           get { return _selectedselectedstudentw; }
           set { ChangeNvalidate(ref _selectedselectedstudentw,value); }
        }
        
        
    }
}