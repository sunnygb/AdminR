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
    public class ElisaHbsagRepository : IElisaHbsagsRepository, IDisposable
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

        public async Task<ElisaHbsag> AddElisaHbsagAsync(ElisaHbsag elisahbsag)
        {
            await conn.InsertAsync(elisahbsag);
            elisahbsag.SerialNo = conn.LastInsertId();
            return elisahbsag;
        }

        public async Task<List<ElisaHbsag>> GetAllElisaHbsagAsync()
        {
            return await conn.SelectAsync<ElisaHbsag>();
        }

        public async Task<ElisaHbsag> FindElisaHbsagAsync(long id)
        {
            return await conn.SingleByIdAsync<ElisaHbsag>(id);
        }

        public async Task<ElisaHbsag> UpdateElisaHbsagAsync(ElisaHbsag elisahbsag)
        {
            int result = await conn.UpdateAsync(elisahbsag);
            return elisahbsag;
        }

        public async Task RemoveElisaHbsagAsync(long id)
        {
            await conn.DeleteByIdAsync<ElisaHbsag>(id);
        }

        public async Task<ElisaHbsag> GetElisaHbsagWithChildrenAsync(long id)
        {
            ElisaHbsag elisahbsag = await conn.SingleByIdAsync<ElisaHbsag>(id);


            // One To One 
            Patient patient = await conn.SingleAsync<Patient>(e => e.PatientID == id);
            if (elisahbsag != null && patient != null)
            {
                elisahbsag.Patient = patient;
            }


            return elisahbsag;
        }


        public async Task<ElisaHbsag> SaveElisaHbsagAsync(ElisaHbsag elisahbsag)
        {
            using (var txScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if (elisahbsag.IsNew)
                {
                    await AddElisaHbsagAsync(elisahbsag);
                }
                else
                {
                    await UpdateElisaHbsagAsync(elisahbsag);
                }


                // One To One 
                if (elisahbsag.Patient != null)
                {
                    if (elisahbsag.Patient.IsDeleted)
                    {
                        long id = elisahbsag.Patient.PatientID;
                        await _conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if (!elisahbsag.Patient.IsDeleted)
                    {
                        Patient patient = elisahbsag.Patient;
                        patient.PatientID = elisahbsag.SerialNo;
                        await conn.SaveAsync(patient);
                    }
                }


                txScope.Complete();
            }
            return elisahbsag;
        }
    }
}