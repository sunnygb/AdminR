using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinical_Reporting.Model;
using System.Data.Entity;

namespace Clinical_Reporting.Services.Implementations
{
    
    class HaematologyRepository : IHaematologyRepository
    {
        private DatabaseContainer _context = new DatabaseContainer();
        public async Task<Haematology> AddHaematologyAsync(Haematology haematology)
        {
            _context.Haematologies.Add(haematology);
            await _context.SaveChangesAsync();
            return haematology;
        }

        public async Task DeleteHaematologyAsync(long haematologyID)
        {
            var haematology = _context.Haematologies.FirstOrDefault(x => x.SerialNo == haematologyID);
            if (haematology != null)
                _context.Haematologies.Remove(haematology);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Haematology>> GetAllHaematologyAsync()
        {
            return await _context.Haematologies.ToListAsync();
        }

        public async Task<List<Haematology>> GetHaematologyAsync(long patientID)
        {
            return await _context.Haematologies.Where(x => x.PatientID == patientID).ToListAsync();
        }

        public async Task<Haematology> UpdateHaematologyAsync(Haematology haematology)
        {
            if (!_context.Haematologies.Any(x => x.SerialNo == haematology.SerialNo))
                _context.Haematologies.Attach(haematology);
            _context.Entry(haematology).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return haematology;
        }
    }
}
