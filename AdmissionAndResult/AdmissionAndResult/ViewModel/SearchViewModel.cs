using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Dapper.Contrib.Extensions;
using AdmissionAndResult.Model;
using AdmissionAndResult.Services;
using AdmissionAndResult.Model.Wrapper;

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

          
            
           
            
        }
        
        public Student student
        {

            get { return _selectedStudent; }

            set
            {
                Set(() => student, ref _selectedStudent, value);
            }
        }
        public VerifyingAgentW selectedagent
        {

            get { return _selectedAgent; }

            set
            {
                Set(() => selectedagent, ref _selectedAgent, value);
            }
        }

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

    }
}
