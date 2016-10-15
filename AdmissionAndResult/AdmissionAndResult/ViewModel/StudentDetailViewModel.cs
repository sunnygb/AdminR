
using ClinicalReporting.Model;
using GalaSoft.MvvmLight;
using System;

namespace AdmissionAndResult.ViewModel
{
    class StudentDetailViewModel : ViewModelBase
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

        public StudentDetailViewModel(Object student)
        {
            
            _student = new Student();
        }






        public void Search()
        {
            
        }
    }
}
