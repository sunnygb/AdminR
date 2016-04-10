using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinical_Reporting.Model;

namespace Clinical_Reporting.Services
{
    interface IELISA_HCVRepository
    {
        Task<List<ELISA_HCV>> GetAllELISA_HCVAsync();
        Task<List<ELISA_HCV>> GetELISA_HCVAsync(long PatientID);
        Task<ELISA_HCV> AddELISA_HCVAsync(ELISA_HCV eLISA_HCV);
        Task<ELISA_HCV> UpdateELISA_HCVAsync(ELISA_HCV eLISA_HCV);
        Task DeleteELISA_HCVAsync(long eLISA_HCV_ID);
    }
}
