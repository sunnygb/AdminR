using Clinical_Reporting.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinical_Reporting.ViewModel

{
    public class PatientViewModel:ViewModelBase
    {
        private Patient _patient = new Patient();

        public Patient patient
        {

            get { return _patient; }

            set
            {
                Set(() => patient, ref _patient, value);
            }
        }
    }
}
