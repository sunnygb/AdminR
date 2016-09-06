using ClinicalReporting.ViewModel;
using ClinicalReporting.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ClinicalReportingV2;

namespace ClinicalReporting
{
    class MainwindowViewModel : ViewModelBase
    {

        private AddPatientViewModel _addpatientVM = new AddPatientViewModel();
        private SearchViewModel _searchVM = new SearchViewModel();
        private BackupViewModel _backupVM = new BackupViewModel();
        private SettingsViewModel _settingsVM = new SettingsViewModel();
        private ThemesViewModel _themesVM = new ThemesViewModel();
       



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
                case "addpatient":
                    CurrentViewModel = _addpatientVM;
                    break;

                case "search":
                    CurrentViewModel = _searchVM;
                    break;
                case "backup":
                    CurrentViewModel = _backupVM;
                    break;
                case "settings":
                    CurrentViewModel = _settingsVM;
                    break;
                case "themes":
                    CurrentViewModel = _themesVM;
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

