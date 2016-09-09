using ServiceStack.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicalReporting.Data.Services
{
    public interface IDoctorsRepository
    {
        IDbConnectionFactory DbFactory { get; set; }
        Task<Doctor> AddDoctorAsync(Doctor doctor);
        Task<List<Doctor>> GetAllDoctorAsync();
        Task<Doctor> FindDoctorAsync(long id);
        Task<Doctor> UpdateDoctorAsync(Doctor doctor);
        Task RemoveDoctorAsync(long id);

        Task<Doctor> GetDoctorWithChildrenAsync(long id);
        Task<Doctor> SaveDoctorAsync(Doctor doctor);
    }
}