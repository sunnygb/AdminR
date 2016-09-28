using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;
using ClinicalReporting.Model;
using ClinicalReporting.Model.Repository;
using ClinicalReporting.Model.Wrapper;
using ClinicalReporting.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using  System.Linq;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Threading;
using Microsoft.Practices.ServiceLocation;

namespace ClinicalReporting.ViewModel
{
    public class SearchViewModel : ViewModelBase
    {
        private readonly IPatientsRepository _repoPatient;
        
        private ObservableCollection<Patient> _patients;


        private ICollectionView _patientView;

        public ICollectionView PatientView
        {
            get { return _patientView; }
        }
        

        private Patient _patienTests;

        public Patient PatientTests
        {
            get
            {
                return _patienTests;
            }
            set
            {
                Set(() => PatientTests, ref _patienTests, value);
            }
        }

        private async void GetPatientChild(long selectePatientId)
        {


            //ThreadPool.QueueUserWorkItem(
            //    o =>
            //    {
            //        var tests =
            //            new PatientW(_repoPatient.GetWithChildren(selectePatientId));

            //        DispatcherHelper.CheckBeginInvokeOnUI(
            //            () => PatientTests = tests);


            //    });
                
                       PatientTests =
                           await _repoPatient.GetPatientWithChildrenAsync(selectePatientId);
                
                
            
            
        }


        public SearchViewModel()
        {
           


              _repoPatient = ServiceLocator.Current.GetInstance<IPatientsRepository>();
            _patientView = CollectionViewSource.GetDefaultView(_repoPatient.GetAllPatientAsync().Result);
            
                SearchName = "Abdullah Farooq";
            PatientTests = _repoPatient.GetWithChildren(1);
        }



        private Int64 _patientId;

        public Int64 PatientId
        {
            get { return _patientId; }
            set { Set(() => PatientId, ref _patientId, value);
            GetPatientChild(_patientId);
            }
        }

        private string _searchName;

        public string SearchName
        {
            get { return _searchName; }
            set { Set(() => SearchName, ref _searchName, value);

                PatientTests = null;
                _patientView.Refresh();
               
            }
        }


        [PreferredConstructor]
        public SearchViewModel(IPatientsRepository repository)
        {
            _repoPatient = repository;
            DetailCommand = new RelayCommand<Int64>(NavigateTo);
            AddNewTest = new RelayCommand<string>(addNewTest);
        }

        private void NavigateTo(Int64 patientId)
        {
            
        }
        public void addNewTest(string testName)
        {
            MessageBox.Show("Funtion Passed");
            switch (testName)
            {
                case "blood":

                    break;
                case "bio":

                    break;
                case "hbs":

                    break;

                case "hcv":

                    break;
                case "tb":

                    break;
                case "hae":

                    break;
                case "ser":

                    break;
                case "sem":

                    break;


            }
        }

        public RelayCommand<Int64> DetailCommand { get; private set; }

        public RelayCommand<string> AddNewTest {get; private set; }


        public async Task LoadAsync()
        {
           
            _patientView = CollectionViewSource.GetDefaultView(await _repoPatient.GetAllPatientAsync());
            _patientView.Filter += PatientFilter;
            
        }

        private bool PatientFilter(object obj)
        {
            if (string.IsNullOrEmpty(SearchName))
            {
                return true;
            }
            
            Patient pat = obj as Patient;
            return pat.Name.ToLower().Contains(_searchName.ToLower());
        }
    }
}