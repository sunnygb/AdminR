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
    public class SerologyRepository : ISerologiesRepository, IDisposable
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

        public async Task<Serology> AddSerologyAsync(Serology serology)
        {
            await conn.InsertAsync(serology);
            serology.Serialno = conn.LastInsertId();
            return serology;
        }

        public async Task<List<Serology>> GetAllSerologyAsync()
        {
            return await conn.SelectAsync<Serology>();
        }

        public async Task<Serology> FindSerologyAsync(long id)
        {
            return await conn.SingleByIdAsync<Serology>(id);
        }

        public async Task<Serology> UpdateSerologyAsync(Serology serology)
        {
            int result = await conn.UpdateAsync(serology);
            return serology;
        }

        public async Task RemoveSerologyAsync(long id)
        {
            await conn.DeleteByIdAsync<Serology>(id);
        }

        public async Task<Serology> GetSerologyWithChildrenAsync(long id)
        {
            Serology serology = await conn.SingleByIdAsync<Serology>(id);


            // One To One 
            Patient patient = await conn.SingleAsync<Patient>(e => e.PatientID == id);
            if (serology != null && patient != null)
            {
                serology.Patient = patient;
            }


            return serology;
        }


        public async Task<Serology> SaveSerologyAsync(Serology serology)
        {
            using (var txScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if (serology.IsNew)
                {
                    await AddSerologyAsync(serology);
                }
                else
                {
                    await UpdateSerologyAsync(serology);
                }


                // One To One 
                if (serology.Patient != null)
                {
                    if (serology.Patient.IsDeleted)
                    {
                        long id = serology.Patient.PatientID;
                        await _conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if (!serology.Patient.IsDeleted)
                    {
                        Patient patient = serology.Patient;
                        patient.PatientID = serology.Serialno;
                        await conn.SaveAsync(patient);
                    }
                }


                txScope.Complete();
            }
            return serology;
        }
    }
}