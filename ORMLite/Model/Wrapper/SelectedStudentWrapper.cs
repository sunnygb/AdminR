using AdmissionAndResult.Data.Services;

namespace AdmissionAndResult.Data.Wrapper
{
    public partial class SelectedStudentW : CommonWrapper<SelectedStudent>
    {
        public SelectedStudentW(SelectedStudent selectedstudentModel):base(selectedstudentModel)
        {
           
           InitializeComplexProperties(selectedstudentModel);
           InitializeCollectionProperties(selectedstudentModel);
           
           
        }
        
        private void InitializeCollectionProperties(SelectedStudent selectedstudentModel)
        {
        }
        
        private void InitializeComplexProperties(SelectedStudent selectedstudentModel)
        {
        
           // One To One
           if(selectedstudentModel.Student !=null)
           {
               this.SelectedStudentMemberW = new StudentW(
               selectedstudentModel.Student);
           }
           // One To One
           if(selectedstudentModel.Department !=null)
           {
               this.DepartmentW = new DepartmentW(
               selectedstudentModel.Department);
           }
           // One To One
           if(selectedstudentModel.Course !=null)
           {
               this.CourseW = new CourseW(
               selectedstudentModel.Course);
           }
        }
          
        public SelectedStudentW():base(null){}
        
        private System.Int64 _selectedstudentid;
        public  System.Int64  SelectedStudentId
        {
           get { return GET(ref _selectedstudentid); }
           set { SET(ref  _selectedstudentid,value); }
        }
        private System.String _studentregisterationnumber;
        public  System.String  StudentRegisterationNumber
        {
           get { return GET(ref _studentregisterationnumber); }
           set { SET(ref  _studentregisterationnumber,value); }
        }
        private System.Double _aggregate;
        public  System.Double  Aggregate
        {
           get { return GET(ref _aggregate); }
           set { SET(ref  _aggregate,value); }
        }
        private System.Int64 _courseid;
        public  System.Int64  CourseId
        {
           get { return GET(ref _courseid); }
           set { SET(ref  _courseid,value); }
        }
        private System.String _cgpatext;
        public  System.String  CGPAText
        {
           get { return GET(ref _cgpatext); }
           set { SET(ref  _cgpatext,value); }
        }
        private System.String _sgpa;
        public  System.String  Sgpa
        {
           get { return GET(ref _sgpa); }
           set { SET(ref  _sgpa,value); }
        }
        private System.Int64 _departmentid;
        public  System.Int64  DepartmentID
        {
           get { return GET(ref _departmentid); }
           set { SET(ref  _departmentid,value); }
        }
        
        // One To One
        private StudentW _selectedstudentmemberw;
        public  StudentW  SelectedStudentMemberW
        { 
           get { return _selectedstudentmemberw; } 
           set { _selectedstudentmemberw = value;
           if(!Equals(_selectedstudentmemberw,Model.Student))
           {Model.Student = _selectedstudentmemberw.Model;};}
        }
        
        // One To One
        private DepartmentW _departmentw;
        public  DepartmentW  DepartmentW
        { 
           get { return _departmentw; } 
           set { _departmentw = value;
           if(!Equals(_departmentw,Model.Department))
           {Model.Department = _departmentw.Model;};}
        }
        
        // One To One
        private CourseW _coursew;
        public  CourseW  CourseW
        { 
           get { return _coursew; } 
           set { _coursew = value;
           if(!Equals(_coursew,Model.Course))
           {Model.Course = _coursew.Model;};}
        }
        
        
        
    }
}