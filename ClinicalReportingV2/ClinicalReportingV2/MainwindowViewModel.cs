using ClinicalReporting.ViewModel;
using ClinicalReporting.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ClinicalReporting.Data;
using ClinicalReporting.Data.Services;
using Microsoft.Practices.Unity;
using ClinicalReporting.Data.Services;
using ClinicalReporting.Data.Repository;

namespace ClinicalReporting
{
    class MainwindowViewModel : ViewModelBase
    {

        private AddPatientViewModel _addpatientVM;
        private SearchViewModel _searchVM = new SearchViewModel();
        private BackupViewModel _backupVM = new BackupViewModel();
        private SettingsViewModel _settingsVM = new SettingsViewModel();
        private ThemesViewModel _themesVM = new ThemesViewModel();
        private MainHeaderViewModel _header;



        private ViewModelBase _currentViewModel;

        public MainwindowViewModel()
        {
            navigationCommand = new RelayCommand<string>(navigateTo);
            this._header = ContainerHelper.Container.Resolve<MainHeaderViewModel>();
            this._addpatientVM = ContainerHelper.Container.Resolve<AddPatientViewModel>();
          
        }

        public ViewModelBase CurrentViewModel { get { return _currentViewModel; } set { Set(() => CurrentViewModel, ref _currentViewModel, value); } }
        public MainHeaderViewModel MainHeader { get { return _header; } set { Set(() => MainHeader, ref _header, value); } }
        public RelayCommand<string> navigationCommand { get; private set; }

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

