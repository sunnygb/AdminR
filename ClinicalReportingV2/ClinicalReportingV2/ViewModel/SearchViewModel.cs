using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
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
        private List<Patient> _patientList;
        private ObservableCollection<Patient> _patients;

        

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
                _patientList = _repoPatient.GetAllPatient();
                Patients = new ObservableCollection<Patient>(_patientList);

                SearchName = "Abdullah Farooq";
            PatientTests = _repoPatient.GetWithChildren(1);
        }

        public ObservableCollection<Patient> Patients
        {
            get { return _patients; }
            set { Set(() => Patients, ref _patients, value); }
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
            if (!IsInDesignMode)
            {
                SearchTests(_searchName);
            }
               
            }
        }

        private  void SearchTests(string _searchName)
        {
            PatientTests = null;
            if (string.IsNullOrEmpty(_searchName))
            {
                
                Patients = new ObservableCollection<Patient>(_patientList);
            }
            else
            {
                Patients = new ObservableCollection<Patient>(_patientList.Where(x => x.Name.ToLower().Contains(_searchName.ToLower())));
            }
            
        }

        [PreferredConstructor]
        public SearchViewModel(IPatientsRepository repository)
        {
            _repoPatient = repository;
            DetailCommand = new RelayCommand<Int64>(NavigateTo);
        }

        private void NavigateTo(Int64 patientId)
        {
            
        }

        public RelayCommand<Int64> DetailCommand { get; private set; }


        public async Task LoadAsync()
        {
            _patientList = await _repoPatient.GetAllPatientAsync();
            Patients = new ObservableCollection<Patient>(_patientList);
        }

    }
}