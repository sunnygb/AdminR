using AdmissionAndResult.ViewModel;
using AdmissionAndResult.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace AdmissionAndResult
{
    public class MainwindowViewModel : ViewModelBase
    {

        private StudentAdmitViewModel _admitVM = new StudentAdmitViewModel();
        private VerifyingAgentViewModel _agentVM = new VerifyingAgentViewModel();
        private MeriListViewModel _meritVM = new MeriListViewModel();
        private StudentSearchViewModel _studentSearchVm = new StudentSearchViewModel();
        private StudentverifyingReport _verifyingReport = new StudentverifyingReport();
       



        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel { get { return _currentViewModel; } set { Set(() => CurrentViewModel, ref _currentViewModel, value); } }

        private MainHeaderView _headerView;
        public MainHeaderView MainHeaderView { get { return _headerView; } set { Set(() => MainHeaderView, ref _headerView, value); } }

        public RelayCommand<string> navigationCommand { get; private set; }

        public MainwindowViewModel()
        {
            navigationCommand = new RelayCommand<string>(navigateTo);
            this._headerView = new MainHeaderView();
        }

        private void navigateTo(string destination)
        {
            switch (destination)
            {
                case "admission":
                    CurrentViewModel = _admitVM;
                    break;

                case "search":
                    CurrentViewModel = _studentSearchVm;
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
//StudentAdmitView admitForm;
//public MainwindowViewModel()
//{
//    _admitVM = new AdmitFormViewModel();
//    SubmitCommand = new RelayCommand(searchNavigation) {


//    };
//}

//public RelayCommand SubmitCommand { get; private set; }

//public void searchNavigation()
//{
//    admitForm = new StudentAdmitView();
//    admitForm.DataContext = _admitVM;

//}

