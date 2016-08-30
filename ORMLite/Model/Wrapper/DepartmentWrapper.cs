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
    public partial class DepartmentW : ValidateModelCommon
    {
        public DepartmentW(Department department)
        {
           this._departmentid = department.DepartmentID;
           
           this._departmentname = department.DepartmentName;
           
           this._studentstrength = department.StudentStrength;
           
           this._hodname = department.HODName;
           
           this._location = department.Location;
           
           
           // One To Many
           if(department.SelectedStudents !=null)
           {
              this._selectedstudentsw = new ObservableCollection<SelectedStudentW>(
              department.SelectedStudents.Select(e=>new SelectedStudentW(e)));
           }
           

        }
        
        public DepartmentW(){}
        
        private System.Int64 _departmentid;
        public  System.Int64  departmentid
        {
           get { return _departmentid; }
           set { ChangeNvalidate(ref  _departmentid,value); }
        }
        private System.String _departmentname;
        public  System.String  departmentname
        {
           get { return _departmentname; }
           set { ChangeNvalidate(ref  _departmentname,value); }
        }
        private System.Int64 _studentstrength;
        public  System.Int64  studentstrength
        {
           get { return _studentstrength; }
           set { ChangeNvalidate(ref  _studentstrength,value); }
        }
        private System.String _hodname;
        public  System.String  hodname
        {
           get { return _hodname; }
           set { ChangeNvalidate(ref  _hodname,value); }
        }
        private System.String _location;
        public  System.String  location
        {
           get { return _location; }
           set { ChangeNvalidate(ref  _location,value); }
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