using ClinicalReporting.Data.Services;
using Microsoft.Practices.Unity;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Transactions;

namespace ClinicalReporting.Data.Repository
{
    public class DoctorRepository : IDoctorsRepository, IDisposable
    {
        private IDbConnection _conn;

        public IDbConnection conn
        {
            get { return _conn ?? DbFactory.Open(); }
        }

        public void Dispose()
        {
            if (conn != null)
                conn.Dispose();
        }

        [Dependency]
        public IDbConnectionFactory DbFactory { get; set; }

        public async Task<Doctor> AddDoctorAsync(Doctor doctor)
        {
            await conn.InsertAsync(doctor);
            doctor.DoctorID = conn.LastInsertId();
            return doctor;
        }

        public async Task<List<Doctor>> GetAllDoctorAsync()
        {
            return await conn.SelectAsync<Doctor>();
        }

        public async Task<Doctor> FindDoctorAsync(long id)
        {
            return await conn.SingleByIdAsync<Doctor>(id);
        }

        public async Task<Doctor> UpdateDoctorAsync(Doctor doctor)
        {
            int result = await conn.UpdateAsync(doctor);
            return doctor;
        }

        public async Task RemoveDoctorAsync(long id)
        {
            await conn.DeleteByIdAsync<Doctor>(id);
        }

        public async Task<Doctor> GetDoctorWithChildrenAsync(long id)
        {
            Doctor doctor = await conn.SingleByIdAsync<Doctor>(id);


            return doctor;
        }


        public async Task<Doctor> SaveDoctorAsync(Doctor doctor)
        {
            using (var txScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if (doctor.IsNew)
                {
                    await AddDoctorAsync(doctor);
                }
                else
                {
                    await UpdateDoctorAsync(doctor);
                }


                txScope.Complete();
            }
            return doctor;
        }
    }
}