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
    public class SemenAnalysisRepository : ISemenAnalysesRepository, IDisposable
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

        public async Task<SemenAnalysis> AddSemenAnalysisAsync(SemenAnalysis semenanalysis)
        {
            await conn.InsertAsync(semenanalysis);
            semenanalysis.SerialNo = conn.LastInsertId();
            return semenanalysis;
        }

        public async Task<List<SemenAnalysis>> GetAllSemenAnalysisAsync()
        {
            return await conn.SelectAsync<SemenAnalysis>();
        }

        public async Task<SemenAnalysis> FindSemenAnalysisAsync(long id)
        {
            return await conn.SingleByIdAsync<SemenAnalysis>(id);
        }

        public async Task<SemenAnalysis> UpdateSemenAnalysisAsync(SemenAnalysis semenanalysis)
        {
            int result = await conn.UpdateAsync(semenanalysis);
            return semenanalysis;
        }

        public async Task RemoveSemenAnalysisAsync(long id)
        {
            await conn.DeleteByIdAsync<SemenAnalysis>(id);
        }

        public async Task<SemenAnalysis> GetSemenAnalysisWithChildrenAsync(long id)
        {
            SemenAnalysis semenanalysis = await conn.SingleByIdAsync<SemenAnalysis>(id);


            // One To One 
            Patient patient = await conn.SingleAsync<Patient>(e => e.PatientID == id);
            if (semenanalysis != null && patient != null)
            {
                semenanalysis.Patient = patient;
            }


            return semenanalysis;
        }


        public async Task<SemenAnalysis> SaveSemenAnalysisAsync(SemenAnalysis semenanalysis)
        {
            using (var txScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if (semenanalysis.IsNew)
                {
                    await AddSemenAnalysisAsync(semenanalysis);
                }
                else
                {
                    await UpdateSemenAnalysisAsync(semenanalysis);
                }


                // One To One 
                if (semenanalysis.Patient != null)
                {
                    if (semenanalysis.Patient.IsDeleted)
                    {
                        long id = semenanalysis.Patient.PatientID;
                        await _conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if (!semenanalysis.Patient.IsDeleted)
                    {
                        Patient patient = semenanalysis.Patient;
                        patient.PatientID = semenanalysis.SerialNo;
                        await conn.SaveAsync(patient);
                    }
                }


                txScope.Complete();
            }
            return semenanalysis;
        }
    }
}