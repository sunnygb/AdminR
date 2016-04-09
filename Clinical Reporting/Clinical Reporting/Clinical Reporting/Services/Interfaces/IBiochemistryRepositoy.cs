using Clinical_Reporting.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinical_Reporting.Services
{
    interface IBiochemistryRepositoy
    {
        Task<List<Biochemistry>> GetAllBiochemistryAsync();
        Task<Biochemistry> GetBiochemistryAsync(long PatientID);
        Task<Biochemistry> AddBiochemistryAsync(Biochemistry patient);
        Task<Biochemistry> UpdateBiochemistryAsync(Biochemistry patient);
        Task DeleteBiochemistryAsync(long patientID);
        


    }
}
