using ClinicalReporting.Data.Services;
using GalaSoft.MvvmLight;

namespace ClinicalReporting.ViewModel
{
    internal class SearchViewModel : ViewModelBase
    {
        private IPatientsRepository _repoPatient;


        //public async void LoadAsync()
        //{
        //    _patientList = await _repoPatient.DbFactory.Open().SelectAsync<Patient>("SELECT PatientID, Name FROM Patient");
        //    this.Patients = new ObservableCollection<Patient>(_patientList);
        //}
    }
}