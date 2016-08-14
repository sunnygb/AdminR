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
        private Student _student;
        private Selected_Student _selectedStudent;
        private long _VerifiedMatric;
        private  long _VerifiedFsc;
        private long _VerifiedNts;
        private long _verifiedGat;
        private ObservableCollection<Selected_Student> selectedstudents;
        private ObservableCollection<Student> _students;
        SQLiteConnection conn;

         public SearchViewModel()
        {
            searchFunction();
            SearchCommand = new RelayCommand(searchFunction);
            Student student = new Student();
             Selected_Student selectedStudent=new Selected_Student();
          
            
           
            
        }
        
        public Student student
        {

            get { return _student; }

            set
            {
                Set(() => student, ref _student, value);
            }
        }
        public Selected_Student selectedstudent
        {

            get { return _selectedStudent; }

            set
            {
                Set(() => selectedstudent, ref _selectedStudent, value);
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
