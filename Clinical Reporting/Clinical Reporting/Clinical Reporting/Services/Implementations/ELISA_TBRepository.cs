using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinical_Reporting.Model;
using System.Data.Entity;

namespace Clinical_Reporting.Services.Implementations
{
    class ELISA_TBRepository : IELISA_TBRepository
    {
        private DatabaseContainer _context = new DatabaseContainer();
        public async Task<ELISA_TB> AddELISA_TBAsync(ELISA_TB eLISA_TB)
        {
            _context.ELISA_TB.Add(eLISA_TB);
            await _context.SaveChangesAsync();
            return eLISA_TB;
        }

        public async Task DeleteELISA_TBAsync(long eLISA_TB_ID)
        {
            var eLISA_TB = _context.ELISA_TB.FirstOrDefault(x => x.SerialNo ==eLISA_TB_ID );
            if (eLISA_TB != null)
                _context.ELISA_TB.Remove(eLISA_TB);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ELISA_TB>> GetAllELISA_TBAsync()
        {
            return await _context.ELISA_TB.ToListAsync();
        }

        public async Task<List<ELISA_TB>> GetELISA_TBAsync(long patientID)
        {
            return await _context.ELISA_TB.Where(x => x.PatientID == patientID).ToListAsync();

        }

        public async Task<ELISA_TB> UpdateAsync(ELISA_TB eLISA_TB)
        {
            if (!_context.ELISA_TB.Any(x => x.SerialNo == eLISA_TB.SerialNo))
                _context.ELISA_TB.Attach(eLISA_TB);
            _context.Entry(eLISA_TB).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return eLISA_TB;
        }
    }
}
