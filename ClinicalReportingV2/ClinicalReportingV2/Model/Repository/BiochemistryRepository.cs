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
    public class BiochemistryRepository : IBiochemistriesRepository, IDisposable
    {
        private IDbConnection _conn;

        private IDbConnection conn
        {
            get { return _conn = _conn ?? DbFactory.Open(); }
        }

        public IDbConnectionFactory DbFactory { get; set; }

        public async Task<Biochemistry> AddBiochemistryAsync(Biochemistry biochemistry)
        {
            await conn.InsertAsync(biochemistry);
            biochemistry.SerialNo = conn.LastInsertId();
            return biochemistry;
        }

        public async Task<List<Biochemistry>> GetAllBiochemistryAsync()
        {
            return await conn.SelectAsync<Biochemistry>();
        }

        public async Task<Biochemistry> FindBiochemistryAsync(long id)
        {
            return await conn.SingleByIdAsync<Biochemistry>(id);
        }

        public async Task<Biochemistry> UpdateBiochemistryAsync(Biochemistry biochemistry)
        {
            int result = await conn.UpdateAsync(biochemistry);
            return biochemistry;
        }

        public async Task RemoveBiochemistryAsync(long id)
        {
            await conn.DeleteByIdAsync<Biochemistry>(id);
        }

        public async Task<Biochemistry> GetBiochemistryWithChildrenAsync(long id)
        {
            Biochemistry biochemistry = await conn.SingleByIdAsync<Biochemistry>(id);


            // One To One 
            Patient patient = await conn.SingleAsync<Patient>(e => e.PatientID == id);
            if (biochemistry != null && patient != null)
            {
                biochemistry.Patient = patient;
            }


            return biochemistry;
        }


        public async Task<Biochemistry> SaveBiochemistryAsync(Biochemistry biochemistry)
        {
            using (var txScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if (biochemistry.IsNew)
                {
                    await AddBiochemistryAsync(biochemistry);
                }
                else
                {
                    await UpdateBiochemistryAsync(biochemistry);
                }


                // One To One 
                if (biochemistry.Patient != null)
                {
                    if (biochemistry.Patient.IsDeleted)
                    {
                        long id = biochemistry.Patient.PatientID;
                        await _conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if (!biochemistry.Patient.IsDeleted)
                    {
                        Patient patient = biochemistry.Patient;
                        patient.PatientID = biochemistry.SerialNo;
                        await conn.SaveAsync(patient);
                    }
                }


                txScope.Complete();
            }
            return biochemistry;
        }

        public void Dispose()
        {
            if (_conn != null)
                _conn.Dispose();
        }
    }
}