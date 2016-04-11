using Clinical_Reporting.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinical_Reporting.ViewModel
{
    public class DoctorViewModel:ViewModelBase
    {
        
        private Doctor _doctor = new Doctor();
        public Doctor doctor
        {
            get { return _doctor; }

            set
            {
                Set(() => doctor, ref _doctor, value);
            }

        }
    }
}
