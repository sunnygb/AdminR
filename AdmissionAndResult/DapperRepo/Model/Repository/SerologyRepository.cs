using ServiceStack.OrmLite;
using System;
using System.Data;
using System.Collections.Generic;
using System.Transactions;
using ServiceStack.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicalReporting.Model.Repository
{    

    public interface ISerologiesRepository
    {
       Task<Serology> AddSerologyAsync(Serology serology);
       Task<List< Serology>> GetAllSerologyAsync();
       Task<Serology> FindSerologyAsync(long id);
       Task<Serology> UpdateSerologyAsync(Serology serology);
       Task RemoveSerologyAsync(long id); 
       
       Task<Serology> GetSerologyWithChildrenAsync(long id);
       Task<Serology> SaveSerologyAsync(Serology serology);
       Task<List<Serology>> QueryAsync(string query);
       IDbConnection Custom { get;  }
    }


    public class SerologyRepository : ISerologiesRepository,IDisposable
    { 
      
      
       private IDbConnectionFactory DbFactory { get; set; }
      
       private IDbConnection _conn;
       private IDbConnection Conn 
       { 
           get { return _conn ?? (_conn = DbFactory.Open()); }
       }
       
       public SerologyRepository(IDbConnectionFactory dbFactory)
       {
          DbFactory= dbFactory;
       }
       

      public async Task<Serology> AddSerologyAsync(Serology serology)
       {
          await Conn.InsertAsync(serology);
          serology.Serialno =Conn.LastInsertId();
          return serology;
       
       }
       
      public async Task<List<Serology>> GetAllSerologyAsync()
       {
         return await Conn.SelectAsync<Serology>();
       
       }
       
      public async Task<Serology> FindSerologyAsync(long id)
       {
         return await Conn.SingleByIdAsync<Serology>(id);
       
       }
       
      public async Task<Serology> UpdateSerologyAsync(Serology serology)
       {
          await Conn.UpdateAsync<Serology>(serology);
          return serology;
       
       }
       
      public async Task RemoveSerologyAsync(long id)
       {
         await Conn.DeleteByIdAsync<Serology>(id);
       
       }
       
      public async Task<Serology> GetSerologyWithChildrenAsync(long id)
       {
          var serology = await Conn.SingleByIdAsync<Serology>(id);
          
          
          
   
                 // One To One 
           var patient = await Conn.SingleAsync<Patient>(e => e.PatientID == id);
           if (serology != null && patient != null)
           {
             serology.Patient = patient;
           }
         
  
         return serology;
         }
       
       
      public async Task<Serology> SaveSerologyAsync(Serology serology)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(serology.IsNew)
                {
                   await AddSerologyAsync(serology);
                }
                else
                {
                   await UpdateSerologyAsync(serology);
                }
                
                
                    
                 // One To One 
                 if(serology.Patient!=null)
                 {
                    if(serology.Patient.IsDeleted)
                    {
                      var id = serology.Patient.PatientID;
                      await Conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if(!serology.Patient.IsDeleted)
                    {
                      var patient = serology.Patient;
                      patient.PatientID = serology.Serialno;
                      await Conn.SaveAsync(patient);
                    }
                    
                  }
                 
                   
                    txScope.Complete();
            }
            return serology;
       
       }
       
      public async Task<List<Serology>> QueryAsync(string query)
      {
        var result = await Conn.SelectAsync<Serology>(query);
        return result;
      }
      public IDbConnection Custom { get { return Conn; }  }
       
       public void Dispose()
       {
          if (Conn != null)
              Conn.Dispose();
       }
   
    }
    
    public class DesignSerologiesRepository : ISerologiesRepository
    {
      public Task<Serology> AddSerologyAsync(Serology serology)
      {
         return null;
      }
      public async Task<List<Serology>> GetAllSerologyAsync()
      {
            var resultList = new List<Serology>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Serology
                {
                    
                  Serialno = i+12345, 
                  Patientid = i+12345, 
                  Tdate =  "Tdate"+i, 
                  WidalTest =  "WidalTest"+i, 
                  STyphiTo =  "STyphiTo"+i, 
                  STyphiTh =  "STyphiTh"+i, 
                  ParaThyphiAh =  "ParaThyphiAh"+i, 
                  ParaThyphiBh =  "ParaThyphiBh"+i, 
                  Typhoid =  "Typhoid"+i, 
                  IGM =  "IGM"+i, 
                  IGG =  "IGG"+i, 
                  HbsAg =  "HbsAg"+i, 
                  AsoTitre =  "AsoTitre"+i, 
                  PregnancyTest =  "PregnancyTest"+i, 
                  RaFactor =  "RaFactor"+i, 
                  AntiHcv =  "AntiHcv"+i, 
                  Mantoex =  "Mantoex"+i, 
                  KahnsVdrl =  "KahnsVdrl"+i, 
                  TbPlus =  "TbPlus"+i, 
                  Igm =  "Igm"+i, 
                  Igg =  "Igg"+i, 
                  HelicobacterPylori =  "HelicobacterPylori"+i, 
                  Hiv =  "Hiv"+i, 
                  Fee = i+12345, 
                });
            }
            return resultList;
      }
      public async Task<Serology> FindSerologyAsync(long id)
      {
         return new Serology
                {
                    
                    Serialno =  12345,
                    Patientid =  12345,
                    Tdate =  "Tdate",
                    WidalTest =  "WidalTest",
                    STyphiTo =  "STyphiTo",
                    STyphiTh =  "STyphiTh",
                    ParaThyphiAh =  "ParaThyphiAh",
                    ParaThyphiBh =  "ParaThyphiBh",
                    Typhoid =  "Typhoid",
                    IGM =  "IGM",
                    IGG =  "IGG",
                    HbsAg =  "HbsAg",
                    AsoTitre =  "AsoTitre",
                    PregnancyTest =  "PregnancyTest",
                    RaFactor =  "RaFactor",
                    AntiHcv =  "AntiHcv",
                    Mantoex =  "Mantoex",
                    KahnsVdrl =  "KahnsVdrl",
                    TbPlus =  "TbPlus",
                    Igm =  "Igm",
                    Igg =  "Igg",
                    HelicobacterPylori =  "HelicobacterPylori",
                    Hiv =  "Hiv",
                    Fee =  12345,
                };
      }
      public async Task<Serology> UpdateSerologyAsync(Serology serology)
      {
        return null;
      }
      public async Task RemoveSerologyAsync(long id)
      {
        
      }
       
      public async Task<Serology> GetSerologyWithChildrenAsync(long id)
      {
        //One to One
        var patient = new Patient 
        {
        PatientID = 12345, 
                Name =  "Name", 
                Age =  "Age", 
                Sex =  "Sex", 
                RefBy =  "RefBy", 
        };

         
        return new Serology
                {
                    
                    Serialno = 12345,
                    Patientid = 12345,
                    Tdate =  "Tdate",
                    WidalTest =  "WidalTest",
                    STyphiTo =  "STyphiTo",
                    STyphiTh =  "STyphiTh",
                    ParaThyphiAh =  "ParaThyphiAh",
                    ParaThyphiBh =  "ParaThyphiBh",
                    Typhoid =  "Typhoid",
                    IGM =  "IGM",
                    IGG =  "IGG",
                    HbsAg =  "HbsAg",
                    AsoTitre =  "AsoTitre",
                    PregnancyTest =  "PregnancyTest",
                    RaFactor =  "RaFactor",
                    AntiHcv =  "AntiHcv",
                    Mantoex =  "Mantoex",
                    KahnsVdrl =  "KahnsVdrl",
                    TbPlus =  "TbPlus",
                    Igm =  "Igm",
                    Igg =  "Igg",
                    HelicobacterPylori =  "HelicobacterPylori",
                    Hiv =  "Hiv",
                    Fee = 12345,
                    
                     //One to One
                     Patient = patient,
                     
                };
         
      }
      public async Task<Serology> SaveSerologyAsync(Serology serology)
      {
        return null;
      }
      public async Task<List<Serology>> QueryAsync(string query)
      {
         return null;
      }
      public IDbConnection Custom { get { return null;}  }
    }
    
    
    
    
    
    
    
    
}