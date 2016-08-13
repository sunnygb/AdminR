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
        private ObservableCollection<Student> students;
        SQLiteConnection conn;

         public SearchViewModel()
        {
            conn = new SQLiteConnection("Data Source=" + Environment.CurrentDirectory + "\\SystemDB.db");
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
                Set(() => _selectedStudent, ref _selectedStudent, value);
            }
        }
        public RelayCommand SearchCommand { get; private set; }



        public void searchFunction()
        {

        }

    }
}
