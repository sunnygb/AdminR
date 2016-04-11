using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clinical_Reporting.Model;
using Clinical_Reporting.Services;
using System.Data.Entity;
using System.Linq;
using System.Transactions;

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

        public async Task DeletePatientAsync(long patientID)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var patient = _context.Patients.FirstOrDefault(x => x.PatientID == patientID);
                var Biochemistry = _context.Patients.Include("Biochemistry").FirstOrDefault(x => x.PatientID == patientID);
                var BloodGroup = _context.Patients.Include("BloodGroup").FirstOrDefault(x => x.PatientID == patientID);
                var ELISA_HBSAG = _context.Patients.Include("ELISA_HBSAG").FirstOrDefault(x => x.PatientID == patientID);
                var ELISA_HCV  = _context.Patients.Include("ELISA_HCV").FirstOrDefault(x => x.PatientID == patientID);
                var ELISA_TB = _context.Patients.Include("ELISA_TB").FirstOrDefault(x => x.PatientID == patientID);
                var Haematology = _context.Patients.Include("Haematology").FirstOrDefault(x => x.PatientID == patientID);
                var SemenAnalysi = _context.Patients.Include("SemenAnalysi").FirstOrDefault(x => x.PatientID == patientID);
                var Serology = _context.Patients.Include("Serology").FirstOrDefault(x => x.PatientID == patientID);
                var UrineExamination = _context.Patients.Include("UrineExamination").FirstOrDefault(x => x.PatientID == patientID);

                foreach (var item in Biochemistry.Biochemistries)
                {
                    _context.Biochemistries.Remove(item);
                }
                 foreach(var item in BloodGroup.BloodGroups) {
                    _context.BloodGroups.Remove(item);
                }
                foreach (var item in BloodGroup.ELISA_HBSAG)
                {
                    _context.ELISA_HBSAG.Remove(item);
                }

                foreach (var item in BloodGroup.ELISA_HCV)
                {
                    _context.ELISA_HCV.Remove(item);
                }


                foreach (var item in BloodGroup.ELISA_TB)
                {
                    _context.ELISA_TB.Remove(item);
                }

                foreach (var item in BloodGroup.Haematologies)
                {
                    _context.Haematologies.Remove(item);
                }
                foreach (var item in BloodGroup.SemenAnalysis)
                {
                    _context.SemenAnalysis.Remove(item);
                }
                foreach (var item in BloodGroup.Serologies)
                {
                    _context.Serologies.Remove(item);
                }
                foreach (var item in BloodGroup.UrineExaminations)
                {
                    _context.UrineExaminations.Remove(item);
                }
                if(patient!=null)
                _context.Patients.Remove(patient);
             await   _context.SaveChangesAsync();
                scope.Complete();
            }

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

