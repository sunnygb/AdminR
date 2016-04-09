using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clinical_Reporting.Model;
using Clinical_Reporting.Services;
using System.Data.Entity;
using System.Linq;

namespace Clinical_Reporting.Services.Implementations
{
    class PatientRepository : IPatientRepository
    {
        DatabaseContainer _context = new DatabaseContainer();
        public async Task<Patient> AddPatientAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient;
      
        }

        public Task DeletePatientAsync(long patientID)
        {
            return null;
        }

        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            return await _context.Patients.ToListAsync();

        }

        public async Task<List<Patient>> GetPatientAsync(long DoctorID)
        {
            return await _context.Patients.Where(x => x.Ref_by == DoctorID).ToListAsync();
        }

        public async Task<Patient> UpdatePatientAsync(Patient patient)
        {
            if (!_context.Patients.Any(x => x.PatientID == patient.PatientID)) { 
                _context.Patients.Attach(patient);
            }
            _context.Entry(patient).State = EntityState.Modified;
           await _context.SaveChangesAsync();
            return patient;


        }

    }

}

