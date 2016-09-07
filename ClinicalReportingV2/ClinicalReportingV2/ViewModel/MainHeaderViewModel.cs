using ClinicalReporting.Data;
using ClinicalReporting.Data.Services;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicalReporting.Data.Wrapper;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Collections;
using System.Reflection;



namespace ClinicalReporting.ViewModel
{



    class MainHeaderViewModel:ViewModelBase
    {
        private IPatientsRepository _repo;
        public MainHeaderViewModel(IPatientsRepository repo)
        {
            _repo = repo;
            
            


        }
        private ObservableCollection<PatientW> _patients= new ObservableCollection<PatientW>();
        public ObservableCollection<PatientW> Patients
        {

            get { return _patients; }

            set
            {
                Set(() => _patients, ref _patients, value);
            }
        }
        


        
    }

    }

