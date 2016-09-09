using ClinicalReporting.Data.Services;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Transactions;

namespace ClinicalReporting.Data.Repository
{
    public class UrineExaminationRepository : IUrineExaminationsRepository, IDisposable
    {
        private IDbConnection _conn;

        private IDbConnection conn
        {
            get { return _conn = _conn ?? DbFactory.Open(); }
        }

        public void Dispose()
        {
            if (_conn != null)
                _conn.Dispose();
        }

        public IDbConnectionFactory DbFactory { get; set; }

        public async Task<UrineExamination> AddUrineExaminationAsync(UrineExamination urineexamination)
        {
            await conn.InsertAsync(urineexamination);
            urineexamination.SerialNo = conn.LastInsertId();
            return urineexamination;
        }

        public async Task<List<UrineExamination>> GetAllUrineExaminationAsync()
        {
            return await conn.SelectAsync<UrineExamination>();
        }

        public async Task<UrineExamination> FindUrineExaminationAsync(long id)
        {
            return await conn.SingleByIdAsync<UrineExamination>(id);
        }

        public async Task<UrineExamination> UpdateUrineExaminationAsync(UrineExamination urineexamination)
        {
            int result = await conn.UpdateAsync(urineexamination);
            return urineexamination;
        }

        public async Task RemoveUrineExaminationAsync(long id)
        {
            await conn.DeleteByIdAsync<UrineExamination>(id);
        }

        public async Task<UrineExamination> GetUrineExaminationWithChildrenAsync(long id)
        {
            UrineExamination urineexamination = await conn.SingleByIdAsync<UrineExamination>(id);


            // One To One 
            Patient patient = await conn.SingleAsync<Patient>(e => e.PatientID == id);
            if (urineexamination != null && patient != null)
            {
                urineexamination.Patient = patient;
            }


            return urineexamination;
        }


        public async Task<UrineExamination> SaveUrineExaminationAsync(UrineExamination urineexamination)
        {
            using (var txScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if (urineexamination.IsNew)
                {
                    await AddUrineExaminationAsync(urineexamination);
                }
                else
                {
                    await UpdateUrineExaminationAsync(urineexamination);
                }


                // One To One 
                if (urineexamination.Patient != null)
                {
                    if (urineexamination.Patient.IsDeleted)
                    {
                        long id = urineexamination.Patient.PatientID;
                        await _conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if (!urineexamination.Patient.IsDeleted)
                    {
                        Patient patient = urineexamination.Patient;
                        patient.PatientID = urineexamination.SerialNo;
                        await conn.SaveAsync(patient);
                    }
                }


                txScope.Complete();
            }
            return urineexamination;
        }
    }
}