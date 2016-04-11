using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinical_Reporting.Model;
using System.Data.Entity;

namespace Clinical_Reporting.Services.Implementations
{
    class BiochemistryRepositor : IBiochemistryRepositoy
    {
        private DatabaseContainer _context = new DatabaseContainer();
        public async Task<Biochemistry> AddBiochemistryAsync(Biochemistry biochemistry)
        {
            _context.Biochemistries.Add(biochemistry);
           await _context.SaveChangesAsync();
            return biochemistry;
        }

        public async Task DeleteBiochemistryAsync(long biochemistryID)
        {
            var biochemistry = _context.Biochemistries.FirstOrDefault(x => x.SerialNo == biochemistryID);
            if (biochemistry != null)
                _context.Biochemistries.Remove(biochemistry);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Biochemistry>> GetAllBiochemistryAsync()
        {
            return await _context.Biochemistries.ToListAsync();
        }

        public async Task<List<Biochemistry>> GetBiochemistryAsync(long patientID)
        {
          return await _context.Biochemistries.Where(x => x.PatientID == patientID).ToListAsync();
            
        }

        public async Task<Biochemistry> UpdateBiochemistryAsync(Biochemistry biochemistry)
        {
            if (!_context.Biochemistries.Any(x => x.SerialNo == biochemistry.SerialNo))
                _context.Biochemistries.Attach(biochemistry);
            _context.Entry(biochemistry).State = EntityState.Modified;
          await  _context.SaveChangesAsync();
            return biochemistry;
        }
    }
}
