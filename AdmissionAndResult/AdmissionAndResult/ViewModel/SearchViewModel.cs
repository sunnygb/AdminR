using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Dapper.Contrib.Extensions;

namespace AdmissionAndResult.ViewModel
{
    class SearchViewModel : ViewModelBase
    {
       
        
        private long _VerifiedMatric;
        private  long _VerifiedFsc;
        private long _VerifiedNts;
        private long _verifiedGat;
        private ObservableCollection<Verifying_Agent> _agents;
        private ObservableCollection<Student> _students;
        private Student _selectedStudent;
        private Verifying_Agent _selectedAgent;

         public SearchViewModel()
        {
            searchFunction();
            SearchCommand = new RelayCommand(searchFunction);
         
           _selectedStudent = new Student();
             _selectedAgent = new Verifying_Agent();

          
            
           
            
        }
        
        public Student student
        {

            get { return _selectedStudent; }

            set
            {
                Set(() => student, ref _selectedStudent, value);
            }
        }
        public Verifying_Agent selectedagent
        {

            get { return _selectedAgent; }

            set
            {
                Set(() => selectedagent, ref _selectedAgent, value);
            }
        }

        public ObservableCollection<Student> students
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
            
            this.students = new ObservableCollection<Student>(Sqlite.getConnection().GetAll<Student>());
        }

    }
}
