using AdmissionAndResult.ViewModel;
using AdmissionAndResult.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionAndResult
{
    class MainwindowViewModel: ViewModelBase
    {

        private AdmitFormViewModel _admitVM = new AdmitFormViewModel();
        private AgentFormViewModel _agentVM = new AgentFormViewModel();
        private DetailFormViewModel _detailVM = new DetailFormViewModel(new Object());
        private MeriListViewModel _meritVM = new MeriListViewModel();
        private SearchViewModel _searchVM = new SearchViewModel();
        public Object CurrentViewModel { get; set; }



    






















        //private AdmitFormViewModel _admitVM;
        //AdmitForm admitForm;
        //public MainwindowViewModel()
        //{
        //    _admitVM = new AdmitFormViewModel();
        //    SubmitCommand = new RelayCommand(searchNavigation) {


        //    };
        //}

        //public RelayCommand SubmitCommand { get; private set; }

        //public void searchNavigation()
        //{
        //    admitForm = new AdmitForm();
        //    admitForm.DataContext = _admitVM;

        //}
    }
}
