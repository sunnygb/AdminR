using System;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;
using ClinicalReporting.Data.Services;
using System.Text;
using ClinicalReporting.Data.Repository;
using ClinicalReporting.Data;
using ClinicalReporting.Data.Wrapper;
using System.Collections.ObjectModel;
using System.Windows;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using Microsoft.Practices.Unity;
using System.Threading.Tasks;


namespace ClinicalReporting.ViewModel
{
    class AddPatientViewModel: ViewModelBase
    {



        private IDoctorsRepository _repoDoc;
        private IPatientsRepository _repoPatient;

        [InjectionConstructor]
        public AddPatientViewModel(PatientRepository pRepo,DoctorRepository docRepo)
        {
            _repoPatient = pRepo;
            _repoDoc = docRepo;
            SaveCommand = new RelayCommand(Savebtn);
            _patient = new PatientW(new Patient());
            _selectedDoctor = "";
            
        }

        private string _selectedDoctor;
        public string SelectedDoctor
        {
            get { return _selectedDoctor; }

            set
            {
                Set(() => SelectedDoctor, ref _selectedDoctor, value);
            }
        }

        private PatientW _patient;
        public PatientW Patient
        {

            get { return _patient; }

            set
            {
                Set(() => Patient, ref _patient, value);
            }
        }

        private ObservableCollection<Doctor> _doctors;
        public ObservableCollection<Doctor> doctors
        {
            get { return _doctors; }

            set
            {
                Set(() => doctors, ref _doctors, value);
            }

        }

        public RelayCommand SaveCommand { get; private set; }
        public  void Savebtn()
        {

            MessageBox.Show("Saved");
        }
        public async void LoadAsync()
        {
            this.doctors = new ObservableCollection<Doctor>(await _repoDoc.GetAllDoctorAsync());
            this._patient.PatientID = await this._repoPatient.DbFactory.Open().ScalarAsync<long>("Select seq from sqlite_sequence where name=@name;", new {name="Patient"});
        }

    }

}

