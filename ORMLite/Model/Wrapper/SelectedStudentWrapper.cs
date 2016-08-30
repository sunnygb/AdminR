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
    public partial class SelectedStudentW : ValidateModelCommon
    {
        public SelectedStudentW(SelectedStudent selectedstudent)
        {
           this._selectedstudentid = selectedstudent.SelectedStudentId;
           
           this._studentregisterationnumber = selectedstudent.StudentRegisterationNumber;
           
           this._aggregate = selectedstudent.Aggregate;
           
           this._courseid = selectedstudent.CourseId;
           
           this._cgpatext = selectedstudent.CGPAText;
           
           this._sgpa = selectedstudent.Sgpa;
           
           this._departmentid = selectedstudent.DepartmentID;
           
           
           // One To One
           if(selectedstudent.Student !=null)
           {
               this._selectedstudentmemberw = new StudentW(
               selectedstudent.Student);
           }
           // One To One
           if(selectedstudent.Department !=null)
           {
               this._departmentw = new DepartmentW(
               selectedstudent.Department);
           }
           // One To One
           if(selectedstudent.Course !=null)
           {
               this._coursew = new CourseW(
               selectedstudent.Course);
           }

        }
        
        public SelectedStudentW(){}
        
        private System.Int64 _selectedstudentid;
        public  System.Int64  selectedstudentid
        {
           get { return _selectedstudentid; }
           set { ChangeNvalidate(ref  _selectedstudentid,value); }
        }
        private System.String _studentregisterationnumber;
        public  System.String  studentregisterationnumber
        {
           get { return _studentregisterationnumber; }
           set { ChangeNvalidate(ref  _studentregisterationnumber,value); }
        }
        private System.Double _aggregate;
        public  System.Double  aggregate
        {
           get { return _aggregate; }
           set { ChangeNvalidate(ref  _aggregate,value); }
        }
        private System.Int64 _courseid;
        public  System.Int64  courseid
        {
           get { return _courseid; }
           set { ChangeNvalidate(ref  _courseid,value); }
        }
        private System.String _cgpatext;
        public  System.String  cgpatext
        {
           get { return _cgpatext; }
           set { ChangeNvalidate(ref  _cgpatext,value); }
        }
        private System.String _sgpa;
        public  System.String  sgpa
        {
           get { return _sgpa; }
           set { ChangeNvalidate(ref  _sgpa,value); }
        }
        private System.Int64 _departmentid;
        public  System.Int64  departmentid
        {
           get { return _departmentid; }
           set { ChangeNvalidate(ref  _departmentid,value); }
        }
        
        // One To One
        private StudentW _selectedstudentmemberw;
        public  StudentW  selectedstudentmemberw
        {
           get { return _selectedstudentmemberw; }
           set { ChangeNvalidate(ref _selectedstudentmemberw,value); }
        }
        // One To One
        private DepartmentW _departmentw;
        public  DepartmentW  departmentw
        {
           get { return _departmentw; }
           set { ChangeNvalidate(ref _departmentw,value); }
        }
        // One To One
        private CourseW _coursew;
        public  CourseW  coursew
        {
           get { return _coursew; }
           set { ChangeNvalidate(ref _coursew,value); }
        }
        
        
    }
}