using AdmissionAndResult.Data.Services;
using System.Collections.ObjectModel;
using System.Linq;

namespace AdmissionAndResult.Data.Wrapper
{
    public partial class DepartmentW : CommonWrapper<Department>
    {
        public DepartmentW(Department departmentModel):base(departmentModel)
        {
           
           InitializeComplexProperties(departmentModel);
           InitializeCollectionProperties(departmentModel);
           
           
        }
        
        private void InitializeCollectionProperties(Department departmentModel)
        {
           // One To Many
           if(departmentModel.SelectedStudents !=null)
           {
              this._selectedstudentsw = new ObservableCollection<SelectedStudentW>(
              departmentModel.SelectedStudents.Select(e=>new SelectedStudentW(e)));
              RegisterCollection(_selectedstudentsw,departmentModel.SelectedStudents);
           }
        }
        
        private void InitializeComplexProperties(Department departmentModel)
        {
        
           
        }
          
        public DepartmentW():base(null){}
        
        private System.Int64 _departmentid;
        public  System.Int64  DepartmentID
        {
           get { return GET(ref _departmentid); }
           set { SET(ref  _departmentid,value); }
        }
        private System.String _departmentname;
        public  System.String  DepartmentName
        {
           get { return GET(ref _departmentname); }
           set { SET(ref  _departmentname,value); }
        }
        private System.Int64 _studentstrength;
        public  System.Int64  StudentStrength
        {
           get { return GET(ref _studentstrength); }
           set { SET(ref  _studentstrength,value); }
        }
        private System.String _hodname;
        public  System.String  HODName
        {
           get { return GET(ref _hodname); }
           set { SET(ref  _hodname,value); }
        }
        private System.String _location;
        public  System.String  Location
        {
           get { return GET(ref _location); }
           set { SET(ref  _location,value); }
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