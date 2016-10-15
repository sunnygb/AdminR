
using ClinicalReporting.Model;
using GalaSoft.MvvmLight;
using System;

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
