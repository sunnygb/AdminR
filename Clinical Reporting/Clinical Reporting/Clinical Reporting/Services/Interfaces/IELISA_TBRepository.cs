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
        Task<ELISA_TB> GetELISA_TBAsync(long PatientID);
        Task<ELISA_TB> AddELISA_TBAsync(ELISA_TB ELISA_TB);
        Task<ELISA_TB> UpdateAsync(ELISA_TB ELISA_TB);
        Task DeleteELISA_TBAsync(long ELISA_TB_ID);
    }
}
