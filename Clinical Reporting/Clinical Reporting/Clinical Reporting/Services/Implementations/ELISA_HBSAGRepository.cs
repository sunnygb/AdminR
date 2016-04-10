using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinical_Reporting.Model;
using System.Data.Entity;

namespace Clinical_Reporting.Services.Implementations
{
    class ELISA_HBSAGRepository : IELISA_HBSAGRepositoy

    {
        private DatabaseContainer _context = new DatabaseContainer();
        public async Task<ELISA_HBSAG> AddELISA_HBSAGAsync(ELISA_HBSAG eLISA_HBSAG)
        {
            _context.ELISA_HBSAG.Add(eLISA_HBSAG);
           await _context.SaveChangesAsync();
            return eLISA_HBSAG;
        }

        public async Task DeleteELISA_HBSAGAsync(long eLISA_HBSAG_ID)
        {
            var eLISA_HBSAG = _context.ELISA_HBSAG.FirstOrDefault(x => x.SerialNo == eLISA_HBSAG_ID);
            if (eLISA_HBSAG != null)
             _context.ELISA_HBSAG.Remove(eLISA_HBSAG);
           await _context.SaveChangesAsync();
            
            
 }

        public async Task<List<ELISA_HBSAG>> GetAllELISA_HBSAGAsync()
        {
            return await _context.ELISA_HBSAG.ToListAsync();
        }

        public async Task<List<ELISA_HBSAG>> GetELISA_HBSAGAsync(long patientID)
        {
            return await _context.ELISA_HBSAG.Where(x => x.PatientID == patientID).ToListAsync();
        }

        public async Task<ELISA_HBSAG> UpdateELISA_HBSAGAsync(ELISA_HBSAG eLISA_HBSAG)
        {
            if (!_context.ELISA_HBSAG.Any(x => x.SerialNo == eLISA_HBSAG.SerialNo))
                _context.ELISA_HBSAG.Attach(eLISA_HBSAG);
            _context.Entry(eLISA_HBSAG).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return eLISA_HBSAG;

         }
    }
}
