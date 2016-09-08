using ClinicalReporting.Data;
using ClinicalReporting.Data.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using ClinicalReporting.Data.Wrapper;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Collections;
using System.Reflection;
using ClinicalReporting.Data.Repository;
using ServiceStack.OrmLite;
using ClinicalReportingV2;
using System.Windows.Data;
using System.Windows.Threading;



namespace ClinicalReporting.ViewModel
{



    class MainHeaderViewModel:ViewModelBase
    {
        private IPatientsRepository _repoPatient;
        private IList<Patient> _patientList;
        public MainHeaderViewModel(IPatientsRepository repo)
        {
            _repoPatient = repo;
        }
        private ObservableCollection<Patient> _patients;
        public ObservableCollection<Patient> Patients
        {

            get { return _patients; }

            set
            {
                Set(() => Patients, ref _patients, value);

            }
        }
        public async void LoadAsync()
        {
            _patientList = await _repoPatient.DbFactory.Open().SelectAsync<Patient>("SELECT PatientID, Name FROM Patient");
            this.Patients =new ObservableCollection<Patient>(_patientList);
           //var pa = await _repoPatient.DbFactory.Open().SelectAsync<Patient>("SELECT PatientID, Name FROM Patient");
           //pa.ForEach(x => this.Patients.Add(x));
           
        }


        
    }

    }

