using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinical_Reporting.Model;

namespace Clinical_Reporting.Services
{
    interface IELISA_HBSAGRepositoy
    {
        Task<List<ELISA_HBSAG>> GetAllELISA_HBSAGAsync();
        Task<List<ELISA_HBSAG>> GetELISA_HBSAGAsync(long patientID);
        Task<ELISA_HBSAG> AddELISA_HBSAGAsync(ELISA_HBSAG eLISA_HBSAG);
        Task<ELISA_HBSAG> UpdateELISA_HBSAGAsync(ELISA_HBSAG eLISA_HBSAG);
        Task DeleteELISA_HBSAGAsync(long eLISA_HBSAG_ID);
    }
}
