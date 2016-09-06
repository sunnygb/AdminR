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


        private Doctor _selectedDoctor;
        public  IDoctorsRepository _repoDoc= new DoctorRepository();
        private IPatientsRepository _repoPatient = new PatientRepository();
        
        public AddPatientViewModel()
        {
            _repoDoc.DbFactory = CreateConnection();

            SaveCommand = new RelayCommand(Savebtn);
            _patient = new PatientW(new Patient());
            this._doctors = new ObservableCollection<DoctorW>(_repoDoc.GetAllDoctorAsync().Result.Select(e => new DoctorW(e)));
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

