using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GalaSoft.MvvmLight;
using Clinical_Reporting.ViewModel;
using Clinical_Reporting.Model;
using GalaSoft.MvvmLight.Command;
using Clinical_Reporting.View;
using System.Collections.ObjectModel;
using Clinical_Reporting.Services.Implementations;
using Clinical_Reporting.Services;
using System.Data.SQLite;
using System.Windows;

namespace Clinical_Reporting.ViewModel
{
    public class AddPatientViewModel : ViewModelBase
    {

        #region PrivateFeilds
        private Patient _patient;
        private Doctor _selectedDoctor;
        private bool _isMale;
        private ObservableCollection<Doctor> _doctors;
        private IDoctorRepository _repoDoc = new DoctorRepository();
        private IPatientRepository _repoPatient = new PatientRepository();
        #endregion

       
        #region Constructor
        public AddPatientViewModel()
        {
            SaveCommand = new RelayCommand(Savebtn);
            patient = new Patient();
            patient.PatientID = (long)GetNextIDAsync().Result;
            doctors = new ObservableCollection<Doctor>(_repoDoc.GetAllDoctorsAsync().Result);
            _selectedDoctor = doctors.First();


        }
        #endregion

        #region GetterSetters
        public Doctor selectedDoctor { get { return _selectedDoctor; } set { _selectedDoctor = value; } }
        public Patient patient
        {

            get { return _patient; }

            set
            {
                Set(() => patient, ref _patient, value);
            }
        }
        
        public ObservableCollection<Doctor> doctors
        {
            get { return _doctors; }

            set
            {
                Set(() => doctors, ref _doctors, value);
            }

        }
        public RelayCommand SaveCommand { get; private set; }
        public bool IsMale { get { return _isMale; }set { _isMale = value; } }
        #endregion


        #region OtherFunctions
        public void Savebtn()
        {
            Console.WriteLine("Save Button Clicked");

            _patient.Doctor = _selectedDoctor;
            _repoPatient.AddPatientAsync(_patient);
            MessageBox.Show("Patient successfully Saved");
        }
        public async Task<long> GetNextIDAsync()
        {
            long nextID;
            using (SQLiteConnection con = new SQLiteConnection("Data Source=./ProjectDB.db3;Version=3"))
            {
                con.Open();
                using (SQLiteCommand command = new SQLiteCommand("select seq from sqlite_sequence where name='Patient'", con))
                {
                    using (  SQLiteDataReader  reader  =(SQLiteDataReader) await command.ExecuteReaderAsync())
                    {

                        reader.Read();
                        nextID = Int32.Parse(reader[0].ToString()) + 1;

                    }
                }
                con.Close();

            }
            return nextID;

        } 
        #endregion


    }
}
