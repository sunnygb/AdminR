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
    public class BloodGroupRepository : IBloodGroupsRepository, IDisposable
    {
        private IDbConnection _conn;

        private IDbConnection conn
        {
            get { return _conn = _conn ?? DbFactory.Open(); }
        }

        public IDbConnectionFactory DbFactory { get; set; }

        public async Task<BloodGroup> AddBloodGroupAsync(BloodGroup bloodgroup)
        {
            await conn.InsertAsync(bloodgroup);
            bloodgroup.SerialNo = conn.LastInsertId();
            return bloodgroup;
        }

        public async Task<List<BloodGroup>> GetAllBloodGroupAsync()
        {
            return await conn.SelectAsync<BloodGroup>();
        }

        public async Task<BloodGroup> FindBloodGroupAsync(long id)
        {
            return await conn.SingleByIdAsync<BloodGroup>(id);
        }

        public async Task<BloodGroup> UpdateBloodGroupAsync(BloodGroup bloodgroup)
        {
            int result = await conn.UpdateAsync(bloodgroup);
            return bloodgroup;
        }

        public async Task RemoveBloodGroupAsync(long id)
        {
            await conn.DeleteByIdAsync<BloodGroup>(id);
        }

        public async Task<BloodGroup> GetBloodGroupWithChildrenAsync(long id)
        {
            BloodGroup bloodgroup = await conn.SingleByIdAsync<BloodGroup>(id);


            // One To One 
            Patient patient = await conn.SingleAsync<Patient>(e => e.PatientID == id);
            if (bloodgroup != null && patient != null)
            {
                bloodgroup.Patient = patient;
            }


            return bloodgroup;
        }


        public async Task<BloodGroup> SaveBloodGroupAsync(BloodGroup bloodgroup)
        {
            using (var txScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if (bloodgroup.IsNew)
                {
                    await AddBloodGroupAsync(bloodgroup);
                }
                else
                {
                    await UpdateBloodGroupAsync(bloodgroup);
                }


                // One To One 
                if (bloodgroup.Patient != null)
                {
                    if (bloodgroup.Patient.IsDeleted)
                    {
                        long id = bloodgroup.Patient.PatientID;
                        await _conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if (!bloodgroup.Patient.IsDeleted)
                    {
                        Patient patient = bloodgroup.Patient;
                        patient.PatientID = bloodgroup.SerialNo;
                        await conn.SaveAsync(patient);
                    }
                }


                txScope.Complete();
            }
            return bloodgroup;
        }

        public void Dispose()
        {
            if (_conn != null)
                _conn.Dispose();
        }
    }
}