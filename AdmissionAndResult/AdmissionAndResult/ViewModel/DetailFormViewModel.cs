using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

using AdmissionAndResult.Model;

namespace AdmissionAndResult.ViewModel
{
    class DetailFormViewModel : ViewModelBase
    {
        private Student _student;
       

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
            
            _student = new Student();
        }






        public void Search()
        {
            
        }
    }
}
