using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Clinical_Reporting.Model;

namespace Clinical_Reporting.Services.Implementations
{
    class SerologyRepository : ISerologyRepository
    {
        private DatabaseContainer _context = new DatabaseContainer();
        public async Task<Serology> AddSerologyAsync(Serology serology)
        {
            _context.Serologies.Add(serology);
            await _context.SaveChangesAsync();
            return serology;
        }

        public async Task DeleteSerologyAsync(long serologyID)
        {
            var serology = _context.Serologies.FirstOrDefault(x => x.SerialNo ==serologyID );
            if (serology != null)
                _context.Serologies.Remove(serology);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Serology>> GetAllSerologyAsync()
        {
            return await _context.Serologies.ToListAsync();
        }

        public async Task<List<Serology>> GetSerologyAsync(long patientID)
        {
            return await _context.Serologies.Where(x => x.PatientID == patientID).ToListAsync();
        }

        public async Task<Serology> UpdateSerologyAsync(Serology serology)
        {
            if (!_context.Serologies.Any(x => x.SerialNo == serology.SerialNo))
                _context.Serologies.Attach(serology);
            _context.Entry(serology).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return serology;
        }
    }
}
