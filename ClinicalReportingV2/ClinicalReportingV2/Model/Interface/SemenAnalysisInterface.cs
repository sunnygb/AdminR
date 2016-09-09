using ServiceStack.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicalReporting.Data.Services
{
    public interface ISemenAnalysesRepository
    {
        IDbConnectionFactory DbFactory { get; set; }
        Task<SemenAnalysis> AddSemenAnalysisAsync(SemenAnalysis semenanalysis);
        Task<List<SemenAnalysis>> GetAllSemenAnalysisAsync();
        Task<SemenAnalysis> FindSemenAnalysisAsync(long id);
        Task<SemenAnalysis> UpdateSemenAnalysisAsync(SemenAnalysis semenanalysis);
        Task RemoveSemenAnalysisAsync(long id);

        Task<SemenAnalysis> GetSemenAnalysisWithChildrenAsync(long id);
        Task<SemenAnalysis> SaveSemenAnalysisAsync(SemenAnalysis semenanalysis);
    }
}