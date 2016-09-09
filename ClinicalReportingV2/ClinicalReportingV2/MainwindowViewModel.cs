using ClinicalReporting.Data.Services;
using ClinicalReporting.ViewModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.Unity;

namespace ClinicalReporting
{
    public class MainwindowViewModel : ViewModelBase
    {
        private readonly AddPatientViewModel _addpatientVm;
        private readonly BackupViewModel _backupVm = new BackupViewModel();
        private readonly SearchViewModel _searchVm = new SearchViewModel();
        private readonly SettingsViewModel _settingsVm = new SettingsViewModel();
        private readonly ThemesViewModel _themesVm = new ThemesViewModel();


        private ViewModelBase _currentViewModel;
        private MainHeaderViewModel _header;

        public MainwindowViewModel()
        {
            NavigationCommand = new RelayCommand<string>(NavigateTo);
            _header = ContainerHelper.Container.Resolve<MainHeaderViewModel>();
            _addpatientVm = ContainerHelper.Container.Resolve<AddPatientViewModel>();
        }

        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { Set(() => CurrentViewModel, ref _currentViewModel, value); }
        }

        public MainHeaderViewModel MainHeader
        {
            get { return _header; }
            set { Set(() => MainHeader, ref _header, value); }
        }

        public RelayCommand<string> NavigationCommand { get; private set; }

        private void NavigateTo(string destination)
        {
            switch (destination)
            {
                case "addpatient":
                    CurrentViewModel = _addpatientVm;
                    break;

                case "search":
                    CurrentViewModel = _searchVm;
                    break;
                case "backup":
                    CurrentViewModel = _backupVm;
                    break;
                case "settings":
                    CurrentViewModel = _settingsVm;
                    break;
                case "themes":
                    CurrentViewModel = _themesVm;
                    break;
            }
        }
    }
}