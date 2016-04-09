using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinical_Reporting.Model;

namespace Clinical_Reporting.Services
{
    interface ISemenAnalysisRepository
    {
        Task<List<SemenAnalysi>> GetAllSemenAnalysisAsync();
        Task<SemenAnalysi> GetSemenAnalysisAsync(long PatientID);
        Task<SemenAnalysi> AddSemenAnalysisAsync(SemenAnalysi SemenAnalysis);
        Task<SemenAnalysi> UpdateSemenAnalysisAsync(SemenAnalysi SemenAnalysis);
        Task DeleteSemenAnalysisAsync(long SemenAnalysisID);
    }
}
