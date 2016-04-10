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
        Task<List<Biochemistry>> GetBiochemistryAsync(long patientID);
        Task<Biochemistry> AddBiochemistryAsync(Biochemistry biochemistry);
        Task<Biochemistry> UpdateBiochemistryAsync(Biochemistry biochemistry);
        Task DeleteBiochemistryAsync(long biochemistryID);
        


    }
}
