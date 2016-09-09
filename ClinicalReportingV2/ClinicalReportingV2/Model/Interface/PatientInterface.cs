using ServiceStack.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicalReporting.Data.Services
{
    public interface IPatientsRepository
    {
        IDbConnectionFactory DbFactory { get; set; }
        Task<Patient> AddPatientAsync(Patient patient);
        Task<List<Patient>> GetAllPatientAsync();
        Task<Patient> FindPatientAsync(long id);
        Task<Patient> UpdatePatientAsync(Patient patient);
        Task RemovePatientAsync(long id);

        Task<Patient> GetPatientWithChildrenAsync(long id);
        Task<Patient> SavePatientAsync(Patient patient);
    }
}