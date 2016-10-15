using AdmissionAndResult.Data.Services;
using System.Collections.ObjectModel;
using System.Linq;

namespace AdmissionAndResult.Data.Wrapper
{
    public partial class CourseW : CommonWrapper<Course>
    {
        public CourseW(Course courseModel):base(courseModel)
        {
           
           InitializeComplexProperties(courseModel);
           InitializeCollectionProperties(courseModel);
           
           
        }
        
        private void InitializeCollectionProperties(Course courseModel)
        {
           // One To Many
           if(courseModel.SelectedStudents !=null)
           {
              this._selectedstudentsw = new ObservableCollection<SelectedStudentW>(
              courseModel.SelectedStudents.Select(e=>new SelectedStudentW(e)));
              RegisterCollection(_selectedstudentsw,courseModel.SelectedStudents);
           }
        }
        
        private void InitializeComplexProperties(Course courseModel)
        {
        
           // One To One
           if(courseModel.Student !=null)
           {
               this.StudentW = new StudentW(
               courseModel.Student);
           }
           
        }
          
        public CourseW():base(null){}
        
        private System.Int64 _courseid;
        public  System.Int64  CourseId
        {
           get { return GET(ref _courseid); }
           set { SET(ref  _courseid,value); }
        }
        private System.String _coursename;
        public  System.String  CourseName
        {
           get { return GET(ref _coursename); }
           set { SET(ref  _coursename,value); }
        }
        private System.Int64 _studentid;
        public  System.Int64  StudentId
        {
           get { return GET(ref _studentid); }
           set { SET(ref  _studentid,value); }
        }
        
        // One To One
        private StudentW _studentw;
        public  StudentW  StudentW
        { 
           get { return _studentw; } 
           set { _studentw = value;
           if(!Equals(_studentw,Model.Student))
           {Model.Student = _studentw.Model;};}
        }
        
        // One To Many
        private ObservableCollection<SelectedStudentW> _selectedstudentsw;
        public  ObservableCollection<SelectedStudentW>  SelectedStudentsW
        { 
          get { return _selectedstudentsw; }
          set { _selectedstudentsw = value; }
        }
        
        
    }
}