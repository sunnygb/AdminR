using AdmissionAndResult.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionAndResult.ViewModel
{
    class MainwindowViewModel
    {
        private AdmitFormViewModel _admitVM;
        AdmitForm admitForm;
        public MainwindowViewModel()
        {
            _admitVM = new AdmitFormViewModel();
            SubmitCommand = new RelayCommand(searchNavigation) {


            };
        }

        public RelayCommand SubmitCommand { get; private set; }

        public void searchNavigation()
        {
            admitForm = new AdmitForm();
            admitForm.DataContext = _admitVM;
            
        }
    }
}
