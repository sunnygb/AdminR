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
    public class ElisaHcvRepository : IElisaHcvsRepository, IDisposable
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

        public async Task<ElisaHcv> AddElisaHcvAsync(ElisaHcv elisahcv)
        {
            await conn.InsertAsync(elisahcv);
            elisahcv.SerialNo = conn.LastInsertId();
            return elisahcv;
        }

        public async Task<List<ElisaHcv>> GetAllElisaHcvAsync()
        {
            return await conn.SelectAsync<ElisaHcv>();
        }

        public async Task<ElisaHcv> FindElisaHcvAsync(long id)
        {
            return await conn.SingleByIdAsync<ElisaHcv>(id);
        }

        public async Task<ElisaHcv> UpdateElisaHcvAsync(ElisaHcv elisahcv)
        {
            int result = await conn.UpdateAsync(elisahcv);
            return elisahcv;
        }

        public async Task RemoveElisaHcvAsync(long id)
        {
            await conn.DeleteByIdAsync<ElisaHcv>(id);
        }

        public async Task<ElisaHcv> GetElisaHcvWithChildrenAsync(long id)
        {
            ElisaHcv elisahcv = await conn.SingleByIdAsync<ElisaHcv>(id);


            // One To One 
            Patient patient = await conn.SingleAsync<Patient>(e => e.PatientID == id);
            if (elisahcv != null && patient != null)
            {
                elisahcv.Patient = patient;
            }


            return elisahcv;
        }


        public async Task<ElisaHcv> SaveElisaHcvAsync(ElisaHcv elisahcv)
        {
            using (var txScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if (elisahcv.IsNew)
                {
                    await AddElisaHcvAsync(elisahcv);
                }
                else
                {
                    await UpdateElisaHcvAsync(elisahcv);
                }


                // One To One 
                if (elisahcv.Patient != null)
                {
                    if (elisahcv.Patient.IsDeleted)
                    {
                        long id = elisahcv.Patient.PatientID;
                        await _conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if (!elisahcv.Patient.IsDeleted)
                    {
                        Patient patient = elisahcv.Patient;
                        patient.PatientID = elisahcv.SerialNo;
                        await conn.SaveAsync(patient);
                    }
                }


                txScope.Complete();
            }
            return elisahcv;
        }
    }
}