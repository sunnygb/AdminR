using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinical_Reporting.Model;
using System.Data.Entity;

namespace Clinical_Reporting.Services.Implementations
{
    class BloodgroupRepository : IBloodGroupRepository
    {
        private DatabaseContainer _context = new DatabaseContainer();
        public async Task<BloodGroup> AddBloodGroupAsync(BloodGroup bloodGroup)
        {

            _context.BloodGroups.Add(bloodGroup);
            await _context.SaveChangesAsync();
            return bloodGroup;
        }

        public async Task DeleteBloodGrouptAsync(long bloodGroup_ID)
        {
            var bloodGroup = _context.BloodGroups.FirstOrDefault(x => x.SerialNo == bloodGroup_ID);
            if (bloodGroup != null)
                _context.BloodGroups.Remove(bloodGroup);
            await _context.SaveChangesAsync();

        }

        public async Task<List<BloodGroup>> GetAllBloodGroupAsync()
        {
            return await _context.BloodGroups.ToListAsync();
        }

        public async Task<List<BloodGroup>> GetBloodGroupAsync(long patientID)
        {
            return await _context.BloodGroups.Where(x => x.PatientID == patientID).ToListAsync();
        }

        public async Task<BloodGroup> UpdateBloodGroupAsync(BloodGroup bloodGroup)
        {
            if(!_context.BloodGroups.Any(x=> x.SerialNo == bloodGroup.SerialNo))
            {
                _context.BloodGroups.Attach(bloodGroup);
            }
            _context.Entry(bloodGroup).State = EntityState.Modified;
          await  _context.SaveChangesAsync();
            return bloodGroup;
        }
    }
}