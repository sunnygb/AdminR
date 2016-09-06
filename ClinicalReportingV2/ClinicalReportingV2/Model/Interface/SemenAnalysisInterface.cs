using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalReporting.Data.Services
{
    public interface ISemenAnalysesRepository
    {
       Task<SemenAnalysis> AddSemenAnalysisAsync(SemenAnalysis semenanalysis);
       Task<List< SemenAnalysis>> GetAllSemenAnalysisAsync();
       Task<SemenAnalysis> FindSemenAnalysisAsync(long id);
       Task<SemenAnalysis> UpdateSemenAnalysisAsync(SemenAnalysis semenanalysis);
       Task RemoveSemenAnalysisAsync(long id); 
       
       Task<SemenAnalysis> GetSemenAnalysisWithChildrenAsync(long id);
       Task<SemenAnalysis> SaveSemenAnalysisAsync(SemenAnalysis semenanalysis);
    }
}