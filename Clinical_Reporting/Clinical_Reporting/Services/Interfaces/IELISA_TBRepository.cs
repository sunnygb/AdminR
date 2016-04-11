using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinical_Reporting.Model;

namespace Clinical_Reporting.Services
{
    interface IELISA_TBRepository
    {
        Task<List<ELISA_TB>> GetAllELISA_TBAsync();
        Task<List<ELISA_TB>> GetELISA_TBAsync(long patientID);
        Task<ELISA_TB> AddELISA_TBAsync(ELISA_TB eLISA_TB);
        Task<ELISA_TB> UpdateAsync(ELISA_TB eLISA_TB);
        Task DeleteELISA_TBAsync(long eLISA_TB_ID);
    }
}
