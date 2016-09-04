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
    public partial class StudentW : CommonWrapper<Student>
    {
        public StudentW(Student studentModel):base(studentModel)
        {
           
           InitializeComplexProperties(studentModel);
           InitializeCollectionProperties(studentModel);
           
           
        }
        
        private void InitializeCollectionProperties(Student studentModel)
        {
           // One To Many
           if(studentModel.Courses !=null)
           {
              this._coursesw = new ObservableCollection<CourseW>(
              studentModel.Courses.Select(e=>new CourseW(e)));
              RegisterCollection(_coursesw,studentModel.Courses);
           }
           // One To Many
           if(studentModel.VerifyingAgents !=null)
           {
              this._verifyingagentsw = new ObservableCollection<VerifyingAgentW>(
              studentModel.VerifyingAgents.Select(e=>new VerifyingAgentW(e)));
              RegisterCollection(_verifyingagentsw,studentModel.VerifyingAgents);
           }
        }
        
        private void InitializeComplexProperties(Student studentModel)
        {
        
           
           
           // One To One
           if(studentModel.Qualification !=null)
           {
               this.QualificationW = new QualificationW(
               studentModel.Qualification);
           }
           // One To One
           if(studentModel.SelectedStudent !=null)
           {
               this.SelectedSelectedStudentW = new SelectedStudentW(
               studentModel.SelectedStudent);
           }
        }
          
        public StudentW():base(null){}
        
        private System.Int64 _studentid;
        public  System.Int64  StudentId
        {
           get { return GET(ref _studentid); }
           set { SET(ref  _studentid,value); }
        }
        private System.String _studentname;
        public  System.String  StudentName
        {
           get { return GET(ref _studentname); }
           set { SET(ref  _studentname,value); }
        }
        private System.String _studentemail;
        public  System.String  StudentEmail
        {
           get { return GET(ref _studentemail); }
           set { SET(ref  _studentemail,value); }
        }
        private System.String _fathername;
        public  System.String  FatherName
        {
           get { return GET(ref _fathername); }
           set { SET(ref  _fathername,value); }
        }
        private System.String _fathermonthlyincome;
        public  System.String  FatherMonthlyIncome
        {
           get { return GET(ref _fathermonthlyincome); }
           set { SET(ref  _fathermonthlyincome,value); }
        }
        private System.String _fatheroccupation;
        public  System.String  FatherOccupation
        {
           get { return GET(ref _fatheroccupation); }
           set { SET(ref  _fatheroccupation,value); }
        }
        private System.String _postaladdress;
        public  System.String  PostalAddress
        {
           get { return GET(ref _postaladdress); }
           set { SET(ref  _postaladdress,value); }
        }
        private System.String _permanentaddress;
        public  System.String  PermanentAddress
        {
           get { return GET(ref _permanentaddress); }
           set { SET(ref  _permanentaddress,value); }
        }
        private System.String _dateofbirth;
        public  System.String  DateOfBirth
        {
           get { return GET(ref _dateofbirth); }
           set { SET(ref  _dateofbirth,value); }
        }
        private System.String _nicno;
        public  System.String  NICNo
        {
           get { return GET(ref _nicno); }
           set { SET(ref  _nicno,value); }
        }
        private System.String _bloodgroup;
        public  System.String  BloodGroup
        {
           get { return GET(ref _bloodgroup); }
           set { SET(ref  _bloodgroup,value); }
        }
        private System.String _phonenumber;
        public  System.String  PhoneNumber
        {
           get { return GET(ref _phonenumber); }
           set { SET(ref  _phonenumber,value); }
        }
        private System.String _residentalphonenumber;
        public  System.String  ResidentalPhoneNumber
        {
           get { return GET(ref _residentalphonenumber); }
           set { SET(ref  _residentalphonenumber,value); }
        }
        private System.String _date;
        public  System.String  Date
        {
           get { return GET(ref _date); }
           set { SET(ref  _date,value); }
        }
        private System.String _fathersnumber;
        public  System.String  FathersNumber
        {
           get { return GET(ref _fathersnumber); }
           set { SET(ref  _fathersnumber,value); }
        }
        
        // One To Many
        private ObservableCollection<CourseW> _coursesw;
        public  ObservableCollection<CourseW>  CoursesW
        { 
          get { return _coursesw; }
          set { _coursesw = value; }
        }
        // One To Many
        private ObservableCollection<VerifyingAgentW> _verifyingagentsw;
        public  ObservableCollection<VerifyingAgentW>  VerifyingAgentsW
        { 
          get { return _verifyingagentsw; }
          set { _verifyingagentsw = value; }
        }
        // One To One
        private QualificationW _qualificationw;
        public  QualificationW  QualificationW
        { 
           get { return _qualificationw; } 
           set { _qualificationw = value;
           if(!Equals(_qualificationw,Model.Qualification))
           {Model.Qualification = _qualificationw.Model;};}
        }
        
        // One To One
        private SelectedStudentW _selectedselectedstudentw;
        public  SelectedStudentW  SelectedSelectedStudentW
        { 
           get { return _selectedselectedstudentw; } 
           set { _selectedselectedstudentw = value;
           if(!Equals(_selectedselectedstudentw,Model.SelectedStudent))
           {Model.SelectedStudent = _selectedselectedstudentw.Model;};}
        }
        
        
        
    }
}