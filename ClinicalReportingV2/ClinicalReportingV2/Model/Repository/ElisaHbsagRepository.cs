using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Transactions;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace ClinicalReporting.Model.Repository
{
    public interface IElisaHbsagsRepository
    {
        IDbConnection Custom { get; }
        Task<ElisaHbsag> AddElisaHbsagAsync(ElisaHbsag elisahbsag);
        Task<List<ElisaHbsag>> GetAllElisaHbsagAsync();
        Task<ElisaHbsag> FindElisaHbsagAsync(long id);
        Task<ElisaHbsag> UpdateElisaHbsagAsync(ElisaHbsag elisahbsag);
        Task RemoveElisaHbsagAsync(long id);

        Task<ElisaHbsag> GetElisaHbsagWithChildrenAsync(long id);
        Task<ElisaHbsag> SaveElisaHbsagAsync(ElisaHbsag elisahbsag);
        Task<List<ElisaHbsag>> QueryAsync(string query);
    }


    public class ElisaHbsagRepository : IElisaHbsagsRepository, IDisposable
    {
        private IDbConnection _conn;

        public ElisaHbsagRepository(IDbConnectionFactory dbFactory)
        {
            DbFactory = dbFactory;
        }

        private IDbConnectionFactory DbFactory { get; set; }

        private IDbConnection Conn
        {
            get { return _conn ?? (_conn = DbFactory.Open()); }
        }

        public void Dispose()
        {
            if (Conn != null)
                Conn.Dispose();
        }


        public async Task<ElisaHbsag> AddElisaHbsagAsync(ElisaHbsag elisahbsag)
        {
            await Conn.InsertAsync(elisahbsag);
            elisahbsag.SerialNo = Conn.LastInsertId();
            return elisahbsag;
        }

        public async Task<List<ElisaHbsag>> GetAllElisaHbsagAsync()
        {
            return await Conn.SelectAsync<ElisaHbsag>();
        }

        public async Task<ElisaHbsag> FindElisaHbsagAsync(long id)
        {
            return await Conn.SingleByIdAsync<ElisaHbsag>(id);
        }

        public async Task<ElisaHbsag> UpdateElisaHbsagAsync(ElisaHbsag elisahbsag)
        {
            await Conn.UpdateAsync(elisahbsag);
            return elisahbsag;
        }

        public async Task RemoveElisaHbsagAsync(long id)
        {
            await Conn.DeleteByIdAsync<ElisaHbsag>(id);
        }

        public async Task<ElisaHbsag> GetElisaHbsagWithChildrenAsync(long id)
        {
            ElisaHbsag elisahbsag = await Conn.SingleByIdAsync<ElisaHbsag>(id);


            // One To One 
            Patient patient = await Conn.SingleAsync<Patient>(e => e.PatientID == id);
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
                        await Conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if (!elisahbsag.Patient.IsDeleted)
                    {
                        Patient patient = elisahbsag.Patient;
                        patient.PatientID = elisahbsag.SerialNo;
                        await Conn.SaveAsync(patient);
                    }
                }


                txScope.Complete();
            }
            return elisahbsag;
        }

        public async Task<List<ElisaHbsag>> QueryAsync(string query)
        {
            List<ElisaHbsag> result = await Conn.SelectAsync<ElisaHbsag>(query);
            return result;
        }

        public IDbConnection Custom
        {
            get { return Conn; }
        }
    }

    public class DesignElisaHbsagsRepository : IElisaHbsagsRepository
    {
        public Task<ElisaHbsag> AddElisaHbsagAsync(ElisaHbsag elisahbsag)
        {
            return null;
        }

        public async Task<List<ElisaHbsag>> GetAllElisaHbsagAsync()
        {
            var resultList = new List<ElisaHbsag>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new ElisaHbsag
                                   {
                                       SerialNo = i + 12345,
                                       PatientID = i + 12345,
                                       TDate = DateTime.Now,
                                       PatientValue = i + 12345,
                                       CutOffValue = i + 12345,
                                       Fee = i + 12345,
                                   });
            }
            return resultList;
        }

        public async Task<ElisaHbsag> FindElisaHbsagAsync(long id)
        {
            return new ElisaHbsag
                       {
                           SerialNo = 12345,
                           PatientID = 12345,
                           TDate = DateTime.Now,
                           PatientValue = 12345,
                           CutOffValue = 12345,
                           Fee = 12345,
                       };
        }

        public async Task<ElisaHbsag> UpdateElisaHbsagAsync(ElisaHbsag elisahbsag)
        {
            return null;
        }

        public async Task RemoveElisaHbsagAsync(long id)
        {
        }

        public async Task<ElisaHbsag> GetElisaHbsagWithChildrenAsync(long id)
        {
            //One to One
            var patient = new Patient
                              {
                                  PatientID = 12345,
                                  Name = "Name",
                                  Age = "Age",
                                  Sex = "Sex",
                                  RefBy = "RefBy",
                              };


            return new ElisaHbsag
                       {
                           SerialNo = 12345,
                           PatientID = 12345,
                           TDate = DateTime.Now,
                           PatientValue = 12345,
                           CutOffValue = 12345,
                           Fee = 12345,
                    
                           //One to One
                           Patient = patient,
                       };
        }

        public async Task<ElisaHbsag> SaveElisaHbsagAsync(ElisaHbsag elisahbsag)
        {
            return null;
        }

        public async Task<List<ElisaHbsag>> QueryAsync(string query)
        {
            return null;
        }

        public IDbConnection Custom
        {
            get { return null; }
        }
    }
}