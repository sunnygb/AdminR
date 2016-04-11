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

namespace Clinical_Reporting.ViewModel
{
    public class AddPatientViewModel : ViewModelBase
    {
        private Patient _patient;
        private PatientViewModel patientVM;
        private DoctorViewModel doctorVM;
        
        private IDoctorRepository _repoDoc= new DoctorRepository();
        private IPatientRepository _repoPatient = new PatientRepository();
        public Patient patient
        {

            get { return _patient; }

            set
            {
                Set(() => patient, ref _patient, value);
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
            Console.WriteLine("Save Button Clicked");
            //if (IsInDesignModeStatic)
            //{
            //    return;
            //}
            //try
            //{
            //   doctors= await 



            //}
            //catch ( ArgumentException e ){

            
            
            
            //    Console.WriteLine(e.Message);
            //}
           
        }
        public AddPatientViewModel()
        {
            SaveCommand = new RelayCommand(Savebtn);
           patient= new Patient();
            patient.PatientID = GetNextID();
           doctors = new ObservableCollection <Doctor>(_repoDoc.GetAllDoctorsAsync().Result);
        

        }
        public long GetNextID()
        {
            long nextID;
            using (SQLiteConnection con = new SQLiteConnection("Data Source=C:/Users/Sunny/Documents/Visual Studio 2015/Projects/Clinical_Reporting/Clinical_Reporting/Database/ProjectDB.db3;Version=3"))
            {
                con.Open();
                using (SQLiteCommand command = new SQLiteCommand("select seq from sqlite_sequence where name='Patient'", con))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {

                        reader.Read();
                        nextID = Int32.Parse(reader[0].ToString()) + 1;

                    }
                }
                con.Close();

            }
            return nextID;

        }


    }
}
