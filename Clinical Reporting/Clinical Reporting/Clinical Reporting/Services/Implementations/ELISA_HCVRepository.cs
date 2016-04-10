using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinical_Reporting.Model;
using System.Data.Entity;

namespace Clinical_Reporting.Services.Implementations
{
    class ELISA_HCVRepository : IELISA_HCVRepository
    {
        private DatabaseContainer _context = new DatabaseContainer();
        public async Task<ELISA_HCV> AddELISA_HCVAsync(ELISA_HCV eLISA_HCV)
        {
            _context.ELISA_HCV.Add(eLISA_HCV);
            await _context.SaveChangesAsync();
            return eLISA_HCV;
        }

        public async Task DeleteELISA_HCVAsync(long eLISA_HCV_ID)
        {
            var eLISA_HCV = _context.ELISA_HCV.FirstOrDefault(x => x.SerialNo == eLISA_HCV_ID);
            if (eLISA_HCV != null)
                _context.ELISA_HCV.Remove(eLISA_HCV);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ELISA_HCV>> GetAllELISA_HCVAsync()
        {
            return await _context.ELISA_HCV.ToListAsync();
        }

        public async Task<List<ELISA_HCV>> GetELISA_HCVAsync(long PatientID)
        {
            return await _context.ELISA_HCV.Where(x => x.PatientID == PatientID).ToListAsync();
        }

        public async Task<ELISA_HCV> UpdateELISA_HCVAsync(ELISA_HCV eLISA_HCV)
        {
            if (!_context.ELISA_HCV.Any(x => x.SerialNo == eLISA_HCV.SerialNo))
                _context.ELISA_HCV.Attach(eLISA_HCV);
            _context.Entry(eLISA_HCV).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return eLISA_HCV;
        }
    }
}
