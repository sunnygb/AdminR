using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Model;

namespace AdmissionAndResult.ViewModel
{
    class DetailFormViewModel : ViewModelBase
    {
        private Student _student;
        SQLiteConnection conn;

        public Student student
        {

            get { return _student; }

            set
            {
                Set(() => student, ref _student, value);
            }
        }

        public DetailFormViewModel(Object student)
        {
            conn = new SQLiteConnection("Data Source=" + Environment.CurrentDirectory + "\\SystemDB.db");
            _student = new Student();
        }






        public void Search()
        {
            
        }
    }
}
