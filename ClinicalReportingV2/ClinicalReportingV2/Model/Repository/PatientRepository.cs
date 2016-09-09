using ClinicalReporting.Data.Services;
using Microsoft.Practices.Unity;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace ClinicalReporting.Data.Repository
{
    public class PatientRepository : IPatientsRepository, IDisposable
    {
        private IDbConnection _conn;

        private IDbConnection conn
        {
            get { return _conn ?? DbFactory.Open(); }
        }

        public void Dispose()
        {
            if (_conn != null)
                _conn.Dispose();
        }

        [Dependency]
        public IDbConnectionFactory DbFactory { get; set; }

        public async Task<Patient> AddPatientAsync(Patient patient)
        {
            await conn.InsertAsync(patient);
            patient.PatientID = conn.LastInsertId();
            return patient;
        }

        public async Task<List<Patient>> GetAllPatientAsync()
        {
            return await conn.SelectAsync<Patient>();
        }

        public async Task<Patient> FindPatientAsync(long id)
        {
            return await conn.SingleByIdAsync<Patient>(id);
        }

        public async Task<Patient> UpdatePatientAsync(Patient patient)
        {
            int result = await conn.UpdateAsync(patient);
            return patient;
        }

        public async Task RemovePatientAsync(long id)
        {
            await conn.DeleteByIdAsync<Patient>(id);
        }

        public async Task<Patient> GetPatientWithChildrenAsync(long id)
        {
            Patient patient = await conn.SingleByIdAsync<Patient>(id);


            //One To Many
            List<Haematology> haematologies = await conn.SelectAsync<Haematology>(e => e.SerialNo == id);
            if (patient != null && haematologies != null)
            {
                patient.Haematologies.AddRange(haematologies);
            }


            //One To Many
            List<ElisaTb> elisatbs = await conn.SelectAsync<ElisaTb>(e => e.SerialNo == id);
            if (patient != null && elisatbs != null)
            {
                patient.ElisaTbs.AddRange(elisatbs);
            }


            //One To Many
            List<ElisaHcv> elisahcvs = await conn.SelectAsync<ElisaHcv>(e => e.SerialNo == id);
            if (patient != null && elisahcvs != null)
            {
                patient.ElisaHcvs.AddRange(elisahcvs);
            }


            //One To Many
            List<ElisaHbsag> elisahbsags = await conn.SelectAsync<ElisaHbsag>(e => e.SerialNo == id);
            if (patient != null && elisahbsags != null)
            {
                patient.ElisaHbsags.AddRange(elisahbsags);
            }


            //One To Many
            List<BloodGroup> bloodgroups = await conn.SelectAsync<BloodGroup>(e => e.SerialNo == id);
            if (patient != null && bloodgroups != null)
            {
                patient.BloodGroups.AddRange(bloodgroups);
            }


            //One To Many
            List<Biochemistry> biochemistries = await conn.SelectAsync<Biochemistry>(e => e.SerialNo == id);
            if (patient != null && biochemistries != null)
            {
                patient.Biochemistries.AddRange(biochemistries);
            }


            //One To Many
            List<SemenAnalysis> semenanalyses = await conn.SelectAsync<SemenAnalysis>(e => e.SerialNo == id);
            if (patient != null && semenanalyses != null)
            {
                patient.SemenAnalyses.AddRange(semenanalyses);
            }


            //One To Many
            List<UrineExamination> urineexaminations = await conn.SelectAsync<UrineExamination>(e => e.SerialNo == id);
            if (patient != null && urineexaminations != null)
            {
                patient.UrineExaminations.AddRange(urineexaminations);
            }


            //One To Many
            List<Serology> serologies = await conn.SelectAsync<Serology>(e => e.Serialno == id);
            if (patient != null && serologies != null)
            {
                patient.Serologies.AddRange(serologies);
            }


            return patient;
        }


        public async Task<Patient> SavePatientAsync(Patient patient)
        {
            using (var txScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if (patient.IsNew)
                {
                    await AddPatientAsync(patient);
                }
                else
                {
                    await UpdatePatientAsync(patient);
                }


                //One To Many
                foreach (Haematology haematology in patient.Haematologies.Where(s => !s.IsDeleted))
                {
                    haematology.PatientID = patient.PatientID;
                    await conn.SaveAsync(haematology);
                }
                foreach (Haematology haematology in patient.Haematologies.Where(s => s.IsDeleted))
                {
                    await conn.DeleteByIdAsync<Haematology>(haematology.SerialNo);
                }

                //One To Many
                foreach (ElisaTb elisatb in patient.ElisaTbs.Where(s => !s.IsDeleted))
                {
                    elisatb.PatientID = patient.PatientID;
                    await conn.SaveAsync(elisatb);
                }
                foreach (ElisaTb elisatb in patient.ElisaTbs.Where(s => s.IsDeleted))
                {
                    await conn.DeleteByIdAsync<ElisaTb>(elisatb.SerialNo);
                }

                //One To Many
                foreach (ElisaHcv elisahcv in patient.ElisaHcvs.Where(s => !s.IsDeleted))
                {
                    elisahcv.PatientID = patient.PatientID;
                    await conn.SaveAsync(elisahcv);
                }
                foreach (ElisaHcv elisahcv in patient.ElisaHcvs.Where(s => s.IsDeleted))
                {
                    await conn.DeleteByIdAsync<ElisaHcv>(elisahcv.SerialNo);
                }

                //One To Many
                foreach (ElisaHbsag elisahbsag in patient.ElisaHbsags.Where(s => !s.IsDeleted))
                {
                    elisahbsag.PatientID = patient.PatientID;
                    await conn.SaveAsync(elisahbsag);
                }
                foreach (ElisaHbsag elisahbsag in patient.ElisaHbsags.Where(s => s.IsDeleted))
                {
                    await conn.DeleteByIdAsync<ElisaHbsag>(elisahbsag.SerialNo);
                }

                //One To Many
                foreach (BloodGroup bloodgroup in patient.BloodGroups.Where(s => !s.IsDeleted))
                {
                    bloodgroup.PatientID = patient.PatientID;
                    await conn.SaveAsync(bloodgroup);
                }
                foreach (BloodGroup bloodgroup in patient.BloodGroups.Where(s => s.IsDeleted))
                {
                    await conn.DeleteByIdAsync<BloodGroup>(bloodgroup.SerialNo);
                }

                //One To Many
                foreach (Biochemistry biochemistry in patient.Biochemistries.Where(s => !s.IsDeleted))
                {
                    biochemistry.PatientID = patient.PatientID;
                    await conn.SaveAsync(biochemistry);
                }
                foreach (Biochemistry biochemistry in patient.Biochemistries.Where(s => s.IsDeleted))
                {
                    await conn.DeleteByIdAsync<Biochemistry>(biochemistry.SerialNo);
                }

                //One To Many
                foreach (SemenAnalysis semenanalysis in patient.SemenAnalyses.Where(s => !s.IsDeleted))
                {
                    semenanalysis.PatientID = patient.PatientID;
                    await conn.SaveAsync(semenanalysis);
                }
                foreach (SemenAnalysis semenanalysis in patient.SemenAnalyses.Where(s => s.IsDeleted))
                {
                    await conn.DeleteByIdAsync<SemenAnalysis>(semenanalysis.SerialNo);
                }

                //One To Many
                foreach (UrineExamination urineexamination in patient.UrineExaminations.Where(s => !s.IsDeleted))
                {
                    urineexamination.PatientID = patient.PatientID;
                    await conn.SaveAsync(urineexamination);
                }
                foreach (UrineExamination urineexamination in patient.UrineExaminations.Where(s => s.IsDeleted))
                {
                    await conn.DeleteByIdAsync<UrineExamination>(urineexamination.SerialNo);
                }

                //One To Many
                foreach (Serology serology in patient.Serologies.Where(s => !s.IsDeleted))
                {
                    serology.Patientid = patient.PatientID;
                    await conn.SaveAsync(serology);
                }
                foreach (Serology serology in patient.Serologies.Where(s => s.IsDeleted))
                {
                    await conn.DeleteByIdAsync<Serology>(serology.Serialno);
                }


                txScope.Complete();
            }
            return patient;
        }
    }
}