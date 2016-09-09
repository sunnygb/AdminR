using ClinicalReporting.Data;
using ClinicalReporting.Data.Repository;
using ClinicalReporting.Data.Services;
using ClinicalReporting.Data.Wrapper;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.Unity;
using ServiceStack.OrmLite;
using System.Collections.ObjectModel;
using System.Windows;

namespace ClinicalReporting.ViewModel
{
    internal class AddPatientViewModel : ViewModelBase
    {
        private readonly IDoctorsRepository _repoDoc;
        private readonly IPatientsRepository _repoPatient;
        private ObservableCollection<Doctor> _doctors;
        private PatientW _patient;

        private string _selectedDoctor;

        [InjectionConstructor]
        public AddPatientViewModel(PatientRepository pRepo, DoctorRepository docRepo)
        {
            _repoPatient = pRepo;
            _repoDoc = docRepo;
            SaveCommand = new RelayCommand(Savebtn);
            _patient = new PatientW(new Patient());
            _selectedDoctor = "";
        }

        public string SelectedDoctor
        {
            get { return _selectedDoctor; }

            set { Set(() => SelectedDoctor, ref _selectedDoctor, value); }
        }

        public PatientW Patient
        {
            get { return _patient; }

            set { Set(() => Patient, ref _patient, value); }
        }

        public ObservableCollection<Doctor> Doctors
        {
            get { return _doctors; }

            set { Set(() => Doctors, ref _doctors, value); }
        }

        public RelayCommand SaveCommand { get; private set; }

        public void Savebtn()
        {
            MessageBox.Show("Saved");
        }

        public async void LoadAsync()
        {
            Doctors = new ObservableCollection<Doctor>(await _repoDoc.GetAllDoctorAsync());
            _patient.PatientID =
                await
                _repoPatient.DbFactory.Open()
                            .ScalarAsync<long>("Select seq from sqlite_sequence where name=@name;",
                                               new {name = "Patient"});
        }
    }
}