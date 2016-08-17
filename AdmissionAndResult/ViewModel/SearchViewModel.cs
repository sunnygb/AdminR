using AdmissionAndResult.Model;
using AdmissionAndResult.Model.Wrapper;
using AdmissionAndResult.Services;
using Dapper.Contrib.Extensions;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace AdmissionAndResult.ViewModel
{
    class SearchViewModel : ViewModelBase
    {
     
        
        private long _VerifiedMatric;
        private  long _VerifiedFsc;
        private long _VerifiedNts;
        private long _verifiedGat;
        private ObservableCollection<VerifyingAgentW> _agents = new ObservableCollection<VerifyingAgentW>();
        private ObservableCollection<StudentW> _students = new ObservableCollection<StudentW>();
        private Student _selectedStudent;
        private VerifyingAgentW _selectedAgent;

         public SearchViewModel()
        {
            searchFunction();
            SearchCommand = new RelayCommand(searchFunction);
         
           _selectedStudent = new Student();
             _selectedAgent = new VerifyingAgentW();
             _detailCommand = new RelayCommand<object>(showDetail);
            

          
            
           
            
        }

         private RelayCommand<object> _detailCommand;
         public RelayCommand detailCommand
         {
             get;
             private set;
         }


         private object _selectedItem;
         public object SelectedItem
         {

             get { return _selectedItem; }

             set
             {
                 Set(() => SelectedItem, ref _selectedItem, value);
             }
         }



         public Student student
         {

             get { return _selectedStudent; }

             set
             {
                 Set(() => student, ref _selectedStudent, value);
             }
         }
        //public VerifyingAgentW selectedagent
        //{

        //    get { return _selectedAgent; }

        //    set
        //    {
        //        Set(() => selectedagent, ref _selectedAgent, value);
        //    }
        //}

        public ObservableCollection<StudentW> students
        {
            get { return _students; }

            set
            {
                Set(() => students, ref _students, value);
            }
        }
       
            public RelayCommand SearchCommand { get; private set; }



        public void searchFunction()
        {
            
            var students = Sqlite.GetConnection().GetAll<Student>();
            foreach( var student in students)
            {
                _students.Add(new StudentW(student));
            }
        }

        public void showDetail(object obj)
        {
            //Convert.ChangeType(template, typeof(Template));
            //if (template == SelectedTemplate)
            //{
            //    _ESTContext.Templates.Remove(SelectedTemplate);
            //} 
        }

    }
}
