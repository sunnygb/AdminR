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


namespace ClinicalReporting.ViewModel
{
    class AddPatientViewModel: ViewModelBase
    {



        private IDoctorsRepository _repoDoc;
        private IPatientsRepository _repoPatient;

        public AddPatientViewModel(PatientRepository pRepo,DoctorRepository docRepo)
        {
            _repoPatient = pRepo;
            _repoDoc = docRepo;
            _repoDoc.DbFactory = CreateConnection();
            _repoPatient.DbFactory = CreateConnection();
            SaveCommand = new RelayCommand(Savebtn);
            _patient = new PatientW(new Patient());
            _selectedDoctor = "";
            this._doctors = new ObservableCollection<DoctorW>(_repoDoc.GetAllDoctorAsync().Result.Select(e => new DoctorW(e)));
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

        private ObservableCollection<DoctorW> _doctors;
        public ObservableCollection<DoctorW> doctors
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
        public IDbConnectionFactory CreateConnection()
        {
            String connectionString =Environment.CurrentDirectory + "\\DataBase.db";
            var db = new OrmLiteConnectionFactory(connectionString, SqliteDialect.Provider);
            return db;
        }
    }

}

