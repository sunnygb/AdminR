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
        Task<List<SemenAnalysi>> GetSemenAnalysisAsync(long patientID);
        Task<SemenAnalysi> AddSemenAnalysisAsync(SemenAnalysi semenAnalysis);
        Task<SemenAnalysi> UpdateSemenAnalysisAsync(SemenAnalysi semenAnalysis);
        Task DeleteSemenAnalysisAsync(long semenAnalysisID);
    }
}
