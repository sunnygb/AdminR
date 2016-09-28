using System.Diagnostics;
using ClinicalReporting.Services;
using ClinicalReporting.ViewModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;

namespace ClinicalReporting
{
    public class MainwindowViewModel : ViewModelBase
    {

        #region

        #endregion
        private  AddPatientViewModel _addpatientVm;
        private SearchViewModel _searchVm;

        private readonly BackupViewModel _backupVm = new BackupViewModel();
        private readonly SettingsViewModel _settingsVm = new SettingsViewModel();
        private readonly ThemesViewModel _themesVm = new ThemesViewModel();


        
        private SearchViewModel _header;
        private readonly IFrameNavigation _navigation;
        
        public MainwindowViewModel(IFrameNavigation navigation)
        {
            _navigation = navigation;
            NavigationCommand = new RelayCommand<string>(NavigateTo);
            _addpatientVm = ServiceLocator.Current.GetInstance<AddPatientViewModel>();
            _searchVm = ServiceLocator.Current.GetInstance<SearchViewModel>();
            
        }

        public AddPatientViewModel AddPatientViewModel
        {
            get { return _addpatientVm; }
            set { Set(() => AddPatientViewModel, ref _addpatientVm, value); }
        }
        public SearchViewModel SearchViewModel
        {
            get { return _searchVm; }
            set { Set(() => SearchViewModel, ref _searchVm, value); }
        }


        public RelayCommand<string> NavigationCommand { get; private set; }

        private void NavigateTo(string destination)
        {
            switch (destination)
            {
                case "addpatient":
                    _navigation.SetMainFrame(ViewList.PatientView, "MainFrame");
                    break;

                case "search":
                    //CurrentViewModel = _searchVm;
                    _navigation.SetMainFrame(ViewList.SearchView, "MainFrame");
                    
                    
                    break;
                case "backup":
                    
                    break;
                case "settings":
                    
                    break;
                case "themes":
                   
                    break;
            }
        }
        public async void LoadAsync()
        {
            Trace.WriteLine("Async Method Started");
            _navigation.SetMainFrame(ViewList.HeaderView, "HeaderFrame");
            await _addpatientVm.LoadAsync();
            await _searchVm.LoadAsync();
        }
    }
}