using Clinical_Reporting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinical_Reporting.Services
{
    interface IPatientRepository
    {
        Task<List<Patient>> GetAllPatientsAsync();
        Task<List<Patient>> GetPatientAsync(long DoctorID);
        Task<Patient> AddPatientAsync(Patient patient);
        Task<Patient> UpdatePatientAsync(Patient patient);
        Task DeletePatientAsync(long patientID);
       
    }
}
