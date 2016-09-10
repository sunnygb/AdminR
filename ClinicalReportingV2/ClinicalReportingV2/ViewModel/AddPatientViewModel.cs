using System.Collections.ObjectModel;
using System.Windows;
using ClinicalReporting.Model;
using ClinicalReporting.Model.Repository;
using ClinicalReporting.Model.Wrapper;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ServiceStack.OrmLite;

namespace ClinicalReporting.ViewModel
{
    internal class AddPatientViewModel : ViewModelBase
    {
        private readonly IDoctorsRepository _repoDoc;
        private readonly IPatientsRepository _repoPatient;
        private ObservableCollection<Doctor> _doctors;
        private PatientW _patient;

        private string _selectedDoctor;

        public AddPatientViewModel(IPatientsRepository pRepo, IDoctorsRepository docRepo)
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
                _repoPatient.Custom
                            .ScalarAsync<long>("Select seq from sqlite_sequence where name=@name;",
                                               new {name = "Patient"});
        }
    }
}