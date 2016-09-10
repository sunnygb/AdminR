using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ClinicalReporting.Model;
using ClinicalReporting.Model.Repository;
using GalaSoft.MvvmLight;

namespace ClinicalReporting.ViewModel
{
    public class MainHeaderViewModel : ViewModelBase
    {
        private readonly IPatientsRepository _repoPatient;
        private Patient _patientId;
        private List<Patient> _patientList;

        private ObservableCollection<Patient> _patients;

        private string _searchPatient;

        public MainHeaderViewModel(IPatientsRepository repo)
        {
            _repoPatient = repo;
        }

        public ObservableCollection<Patient> Patients
        {
            get { return _patients; }

            set { Set(() => Patients, ref _patients, value); }
        }

        public string SearchPatient
        {
            get { return _searchPatient; }

            set
            {
                Set(() => SearchPatient, ref _searchPatient, value);
                FilterPatient(_searchPatient);
            }
        }

        public Patient PatientId
        {
            get { return _patientId; }

            set { Set(() => PatientId, ref _patientId, value); }
        }

        public async void LoadAsync()
        {
            _patientList =
                await _repoPatient.QueryAsync("SELECT PatientID, Name FROM Patient");
            Patients = new ObservableCollection<Patient>(_patientList);
            //var pa = await _repoPatient.DbFactory.Open().SelectAsync<Patient>("SELECT PatientID, Name FROM Patient");
            //pa.ForEach(x => this.Patients.Add(x));
        }

        private void FilterPatient(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                Patients = new ObservableCollection<Patient>(_patientList);
            }
            else
            {
                Patients =
                    new ObservableCollection<Patient>(_patientList.Where(c => c.Name.ToLower().Contains(key.ToLower())));
            }
        }
    }
}