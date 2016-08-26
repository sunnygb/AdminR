using AdmissionAndResult.ViewModel;
using AdmissionAndResult.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AdmissionAndResult
{
    class MainwindowViewModel : ViewModelBase
    {

        private AdmitFormViewModel _admitVM = new AdmitFormViewModel();
        private AgentFormViewModel _agentVM = new AgentFormViewModel();
        private MeriListViewModel _meritVM = new MeriListViewModel();
        private SearchViewModel _searchVM = new SearchViewModel();
        private StudentverifyingForm _verifyingForm = new StudentverifyingForm();
       



        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel { get { return _currentViewModel; } set { Set(() => CurrentViewModel, ref _currentViewModel, value); } }

        private MainHeader _header;
        public MainHeader MainHeader { get { return _header; } set { Set(() => MainHeader, ref _header, value); } }

        public RelayCommand<string> navigationCommand { get; private set; }

        public MainwindowViewModel()
        {
            navigationCommand = new RelayCommand<string>(navigateTo);
            this._header = new MainHeader();
        }

        private void navigateTo(string destination)
        {
            switch (destination)
            {
                case "admission":
                    CurrentViewModel = _admitVM;
                    break;

                case "search":
                    CurrentViewModel = _searchVM;
                    break;
                case "agent":
                    CurrentViewModel = _agentVM;
                    break;
                case "merit":
                    CurrentViewModel = _meritVM;
                    break;
            }
        }

    }
}
























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

