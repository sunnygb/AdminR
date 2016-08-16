﻿using AdmissionAndResult.ViewModel;
using AdmissionAndResult.Views;
using AdmissionAndResult.Views.Header;
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
        private MainHeader _header= new MainHeader();
        private MeriListViewModel _meritVM = new MeriListViewModel();
        private SearchViewModel _searchVM = new SearchViewModel();
        private Object _currentViewModel;



        public Object CurrentViewModel { get { return _currentViewModel; } set { Set(() => CurrentViewModel, ref _currentViewModel, value); } }

        public RelayCommand<string> navigationCommand{ get; private set; }

       public  MainwindowViewModel()
        {
            navigationCommand = new RelayCommand<string>(navigateTo);
            
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
    
