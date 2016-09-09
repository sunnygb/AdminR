using ClinicalReporting.Data;
using ClinicalReporting.Data.Services;
using GalaSoft.MvvmLight;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ClinicalReporting.ViewModel
{
    public class MainHeaderViewModel : ViewModelBase
    {
        private readonly IPatientsRepository _repoPatient;
        private Patient _patientID;
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
                filterPatient(_searchPatient);
            }
        }

        public Patient PatientID
        {
            get { return _patientID; }

            set { Set(() => PatientID, ref _patientID, value); }
        }

        public async void LoadAsync()
        {
            _patientList =
                await _repoPatient.DbFactory.Open().SelectAsync<Patient>("SELECT PatientID, Name FROM Patient");
            Patients = new ObservableCollection<Patient>(_patientList);
            //var pa = await _repoPatient.DbFactory.Open().SelectAsync<Patient>("SELECT PatientID, Name FROM Patient");
            //pa.ForEach(x => this.Patients.Add(x));
        }

        private void filterPatient(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                Patients = new ObservableCollection<Patient>(_patientList);
                return;
            }
            else
            {
                Patients =
                    new ObservableCollection<Patient>(_patientList.Where(c => c.Name.ToLower().Contains(key.ToLower())));
            }
        }
    }
}