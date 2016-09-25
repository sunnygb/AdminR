using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ClinicalReporting.Model;
using ClinicalReporting.Model.Repository;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ClinicalReporting.ViewModel
{
    public class SearchViewModel : ViewModelBase
    {
        private readonly IPatientsRepository _repoPatient;
        private List<Patient> _patientList;
        private ObservableCollection<Patient> _patients;
        public ObservableCollection<Patient> Patients
        {
            get { return _patients; }
            set { Set(() => Patients, ref _patients, value); }
        }

        private Int64 _patientId;

        public Int64 PatientId
        {
            get { return _patientId; }
            set { Set(() => PatientId, ref _patientId, value); }
        }

        private string _searchPatient;

        public string SearchPatient
        {
            get { return _searchPatient; }
            set { Set(() => SearchPatient, ref _searchPatient, value); }
        }

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