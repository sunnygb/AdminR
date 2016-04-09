using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Clinical_Reporting.Model;


namespace Clinical_Reporting.Services.Implementations
{
    class DoctorRepository : IDoctorRepository
    {
        private DatabaseContainer _context = new DatabaseContainer();
        public async Task<Doctor> AddDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
          await  _context.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> GetDoctorAsync(long id)
        {
            return await _context.Doctors.FirstOrDefaultAsync(x => x.DoctorID == id);

        }

        public async Task<List<Doctor>> GetAllDoctorsAsync()
        {
           return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor> UpdateDoctorAsync(Doctor doctor)
        {
            if (_context.Doctors.Local.Any(x => x.DoctorID == doctor.DoctorID))
            {
                _context.Doctors.Attach(doctor);
            }
            _context.Entry(doctor).State = EntityState.Modified;
          await  _context.SaveChangesAsync();
            return doctor;

        }

        public async Task DeleteDoctorAsync(long doctorID)
        {
          var doctor=  _context.Doctors.FirstOrDefault(x => x.DoctorID == doctorID);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
            }
            
            await _context.SaveChangesAsync();

        }
    }
}
