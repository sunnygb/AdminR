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
    public partial class CourseW : ValidateModelCommon
    {
        public CourseW(Course course)
        {
           this._courseid = course.CourseId;
           
           this._coursename = course.CourseName;
           
           this._studentid = course.StudentId;
           
           
           // One To One
           if(course.Student !=null)
           {
               this._studentw = new StudentW(
               course.Student);
           }
           // One To Many
           if(course.SelectedStudents !=null)
           {
              this._selectedstudentsw = new ObservableCollection<SelectedStudentW>(
              course.SelectedStudents.Select(e=>new SelectedStudentW(e)));
           }
           

        }
        
        public CourseW(){}
        
        private System.Int64 _courseid;
        public  System.Int64  courseid
        {
           get { return _courseid; }
           set { ChangeNvalidate(ref  _courseid,value); }
        }
        private System.String _coursename;
        public  System.String  coursename
        {
           get { return _coursename; }
           set { ChangeNvalidate(ref  _coursename,value); }
        }
        private System.Int64 _studentid;
        public  System.Int64  studentid
        {
           get { return _studentid; }
           set { ChangeNvalidate(ref  _studentid,value); }
        }
        
        // One To One
        private StudentW _studentw;
        public  StudentW  studentw
        {
           get { return _studentw; }
           set { ChangeNvalidate(ref _studentw,value); }
        }
        // One To Many
        private ObservableCollection<SelectedStudentW> _selectedstudentsw;
        public  ObservableCollection<SelectedStudentW>  selectedstudentsw
        {
           get { return _selectedstudentsw; }
           set { ChangeNvalidate(ref _selectedstudentsw,value); }
        }
        
        
    }
}