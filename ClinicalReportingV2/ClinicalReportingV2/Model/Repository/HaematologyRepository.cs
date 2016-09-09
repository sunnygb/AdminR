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
    public class HaematologyRepository : IHaematologiesRepository, IDisposable
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

        public async Task<Haematology> AddHaematologyAsync(Haematology haematology)
        {
            await conn.InsertAsync(haematology);
            haematology.SerialNo = conn.LastInsertId();
            return haematology;
        }

        public async Task<List<Haematology>> GetAllHaematologyAsync()
        {
            return await conn.SelectAsync<Haematology>();
        }

        public async Task<Haematology> FindHaematologyAsync(long id)
        {
            return await conn.SingleByIdAsync<Haematology>(id);
        }

        public async Task<Haematology> UpdateHaematologyAsync(Haematology haematology)
        {
            int result = await conn.UpdateAsync(haematology);
            return haematology;
        }

        public async Task RemoveHaematologyAsync(long id)
        {
            await conn.DeleteByIdAsync<Haematology>(id);
        }

        public async Task<Haematology> GetHaematologyWithChildrenAsync(long id)
        {
            Haematology haematology = await conn.SingleByIdAsync<Haematology>(id);


            // One To One 
            Patient patient = await conn.SingleAsync<Patient>(e => e.PatientID == id);
            if (haematology != null && patient != null)
            {
                haematology.Patient = patient;
            }


            return haematology;
        }


        public async Task<Haematology> SaveHaematologyAsync(Haematology haematology)
        {
            using (var txScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if (haematology.IsNew)
                {
                    await AddHaematologyAsync(haematology);
                }
                else
                {
                    await UpdateHaematologyAsync(haematology);
                }


                // One To One 
                if (haematology.Patient != null)
                {
                    if (haematology.Patient.IsDeleted)
                    {
                        long id = haematology.Patient.PatientID;
                        await _conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if (!haematology.Patient.IsDeleted)
                    {
                        Patient patient = haematology.Patient;
                        patient.PatientID = haematology.SerialNo;
                        await conn.SaveAsync(patient);
                    }
                }


                txScope.Complete();
            }
            return haematology;
        }
    }
}