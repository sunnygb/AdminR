using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Clinical_Reporting.Model;

namespace Clinical_Reporting.Services.Implementations
{
    class SemenAnalysisRepository : ISemenAnalysisRepository
    {
        private DatabaseContainer _context = new DatabaseContainer();
        public async Task<SemenAnalysi> AddSemenAnalysisAsync(SemenAnalysi semenAnalysis)
        {
            _context.SemenAnalysis.Add(semenAnalysis);
            await _context.SaveChangesAsync();
            return semenAnalysis;
        }

        public async Task DeleteSemenAnalysisAsync(long semenAnalysisID)
        {
            var semenAnalysis = _context.SemenAnalysis.FirstOrDefault(x => x.SerialNo ==semenAnalysisID );
            if (semenAnalysis != null)
                _context.SemenAnalysis.Remove(semenAnalysis);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SemenAnalysi>> GetAllSemenAnalysisAsync()
        {
            return await _context.SemenAnalysis.ToListAsync();
        }

        public async Task<List<SemenAnalysi>> GetSemenAnalysisAsync(long patientID)
        {
            return await _context.SemenAnalysis.Where(x => x.PatientID == patientID).ToListAsync();
        }

        public async Task<SemenAnalysi> UpdateSemenAnalysisAsync(SemenAnalysi semenAnalysis)
        {
            if (!_context.SemenAnalysis.Any(x => x.SerialNo == semenAnalysis.SerialNo))
                _context.SemenAnalysis.Attach(semenAnalysis);
            _context.Entry(semenAnalysis).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return semenAnalysis;
        }
    }
}
