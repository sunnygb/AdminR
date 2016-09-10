using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Transactions;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace ClinicalReporting.Model.Repository
{
    public interface IElisaTbsRepository
    {
        IDbConnection Custom { get; }
        Task<ElisaTb> AddElisaTbAsync(ElisaTb elisatb);
        Task<List<ElisaTb>> GetAllElisaTbAsync();
        Task<ElisaTb> FindElisaTbAsync(long id);
        Task<ElisaTb> UpdateElisaTbAsync(ElisaTb elisatb);
        Task RemoveElisaTbAsync(long id);

        Task<ElisaTb> GetElisaTbWithChildrenAsync(long id);
        Task<ElisaTb> SaveElisaTbAsync(ElisaTb elisatb);
        Task<List<ElisaTb>> QueryAsync(string query);
    }


    public class ElisaTbRepository : IElisaTbsRepository, IDisposable
    {
        private IDbConnection _conn;

        public ElisaTbRepository(IDbConnectionFactory dbFactory)
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


        public async Task<ElisaTb> AddElisaTbAsync(ElisaTb elisatb)
        {
            await Conn.InsertAsync(elisatb);
            elisatb.SerialNo = Conn.LastInsertId();
            return elisatb;
        }

        public async Task<List<ElisaTb>> GetAllElisaTbAsync()
        {
            return await Conn.SelectAsync<ElisaTb>();
        }

        public async Task<ElisaTb> FindElisaTbAsync(long id)
        {
            return await Conn.SingleByIdAsync<ElisaTb>(id);
        }

        public async Task<ElisaTb> UpdateElisaTbAsync(ElisaTb elisatb)
        {
            await Conn.UpdateAsync(elisatb);
            return elisatb;
        }

        public async Task RemoveElisaTbAsync(long id)
        {
            await Conn.DeleteByIdAsync<ElisaTb>(id);
        }

        public async Task<ElisaTb> GetElisaTbWithChildrenAsync(long id)
        {
            ElisaTb elisatb = await Conn.SingleByIdAsync<ElisaTb>(id);


            // One To One 
            Patient patient = await Conn.SingleAsync<Patient>(e => e.PatientID == id);
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
                        await Conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if (!elisatb.Patient.IsDeleted)
                    {
                        Patient patient = elisatb.Patient;
                        patient.PatientID = elisatb.SerialNo;
                        await Conn.SaveAsync(patient);
                    }
                }


                txScope.Complete();
            }
            return elisatb;
        }

        public async Task<List<ElisaTb>> QueryAsync(string query)
        {
            List<ElisaTb> result = await Conn.SelectAsync<ElisaTb>(query);
            return result;
        }

        public IDbConnection Custom
        {
            get { return Conn; }
        }
    }

    public class DesignElisaTbsRepository : IElisaTbsRepository
    {
        public Task<ElisaTb> AddElisaTbAsync(ElisaTb elisatb)
        {
            return null;
        }

        public async Task<List<ElisaTb>> GetAllElisaTbAsync()
        {
            var resultList = new List<ElisaTb>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new ElisaTb
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

        public async Task<ElisaTb> FindElisaTbAsync(long id)
        {
            return new ElisaTb
                       {
                           SerialNo = 12345,
                           PatientID = 12345,
                           TDate = DateTime.Now,
                           PatientValue = 12345,
                           CutOffValue = 12345,
                           Fee = 12345,
                       };
        }

        public async Task<ElisaTb> UpdateElisaTbAsync(ElisaTb elisatb)
        {
            return null;
        }

        public async Task RemoveElisaTbAsync(long id)
        {
        }

        public async Task<ElisaTb> GetElisaTbWithChildrenAsync(long id)
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


            return new ElisaTb
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

        public async Task<ElisaTb> SaveElisaTbAsync(ElisaTb elisatb)
        {
            return null;
        }

        public async Task<List<ElisaTb>> QueryAsync(string query)
        {
            return null;
        }

        public IDbConnection Custom
        {
            get { return null; }
        }
    }
}