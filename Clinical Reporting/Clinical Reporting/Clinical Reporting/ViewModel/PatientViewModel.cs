using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Patient
{
   public class PatientViewModel:INotifyPropertyChanged
    {

        public string SelectedDoctor { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
