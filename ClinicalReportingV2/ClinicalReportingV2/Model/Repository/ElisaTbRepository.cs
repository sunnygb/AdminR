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
    public class ElisaTbRepository : IElisaTbsRepository, IDisposable
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

        public async Task<ElisaTb> AddElisaTbAsync(ElisaTb elisatb)
        {
            await conn.InsertAsync(elisatb);
            elisatb.SerialNo = conn.LastInsertId();
            return elisatb;
        }

        public async Task<List<ElisaTb>> GetAllElisaTbAsync()
        {
            return await conn.SelectAsync<ElisaTb>();
        }

        public async Task<ElisaTb> FindElisaTbAsync(long id)
        {
            return await conn.SingleByIdAsync<ElisaTb>(id);
        }

        public async Task<ElisaTb> UpdateElisaTbAsync(ElisaTb elisatb)
        {
            int result = await conn.UpdateAsync(elisatb);
            return elisatb;
        }

        public async Task RemoveElisaTbAsync(long id)
        {
            await conn.DeleteByIdAsync<ElisaTb>(id);
        }

        public async Task<ElisaTb> GetElisaTbWithChildrenAsync(long id)
        {
            ElisaTb elisatb = await conn.SingleByIdAsync<ElisaTb>(id);


            // One To One 
            Patient patient = await conn.SingleAsync<Patient>(e => e.PatientID == id);
            if (elisatb != null && patient != null)
            {
                elisatb.Patient = patient;
            }


            return elisatb;
        }


        public async Task<ElisaTb> SaveElisaTbAsync(ElisaTb elisatb)
        {
            using (var txScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if (elisatb.IsNew)
                {
                    await AddElisaTbAsync(elisatb);
                }
                else
                {
                    await UpdateElisaTbAsync(elisatb);
                }


                // One To One 
                if (elisatb.Patient != null)
                {
                    if (elisatb.Patient.IsDeleted)
                    {
                        long id = elisatb.Patient.PatientID;
                        await _conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if (!elisatb.Patient.IsDeleted)
                    {
                        Patient patient = elisatb.Patient;
                        patient.PatientID = elisatb.SerialNo;
                        await conn.SaveAsync(patient);
                    }
                }


                txScope.Complete();
            }
            return elisatb;
        }
    }
}