using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Clinical_Reporting.Model;

namespace Clinical_Reporting.Services.Implementations
{
    class UrineExaminationRepository : IUrineExaminationRepository
 
    {
        private DatabaseContainer _context = new DatabaseContainer();
        public async Task<UrineExamination> AddUrineExaminationAsync(UrineExamination urineExamination)
        {
            _context.UrineExaminations.Add(urineExamination);
            await _context.SaveChangesAsync();
            return urineExamination;
        }

        public async Task DeleteUrineExaminationAsync(long urineExaminationID)
        {
            var urineExamination = _context.UrineExaminations.FirstOrDefault(x => x.SerialNo ==urineExaminationID );
            if (urineExamination != null)
                _context.UrineExaminations.Remove(urineExamination);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UrineExamination>> GetAllUrineExaminationAsync()
        {
            return await _context.UrineExaminations.ToListAsync();
        }

        public async Task<List<UrineExamination>> GetUrineExaminationAsync(long patientID)
        {
            return await _context.UrineExaminations.Where(x => x.PatientID == patientID).ToListAsync();
        }

        public async Task<UrineExamination> UpdateUrineExaminationAsync(UrineExamination urineExamination)
        {
            if (!_context.UrineExaminations.Any(x => x.SerialNo == urineExamination.SerialNo))
                _context.UrineExaminations.Attach(urineExamination);
            _context.Entry(urineExamination).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return urineExamination;
        }
    }
}
