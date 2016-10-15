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

    public interface ISemenAnalysesRepository
    {
       Task<SemenAnalysis> AddSemenAnalysisAsync(SemenAnalysis semenanalysis);
       Task<List< SemenAnalysis>> GetAllSemenAnalysisAsync();
       Task<SemenAnalysis> FindSemenAnalysisAsync(long id);
       Task<SemenAnalysis> UpdateSemenAnalysisAsync(SemenAnalysis semenanalysis);
       Task RemoveSemenAnalysisAsync(long id); 
       
       Task<SemenAnalysis> GetSemenAnalysisWithChildrenAsync(long id);
       Task<SemenAnalysis> SaveSemenAnalysisAsync(SemenAnalysis semenanalysis);
       Task<List<SemenAnalysis>> QueryAsync(string query);
       IDbConnection Custom { get;  }
    }


    public class SemenAnalysisRepository : ISemenAnalysesRepository,IDisposable
    { 
      
      
       private IDbConnectionFactory DbFactory { get; set; }
      
       private IDbConnection _conn;
       private IDbConnection Conn 
       { 
           get { return _conn ?? (_conn = DbFactory.Open()); }
       }
       
       public SemenAnalysisRepository(IDbConnectionFactory dbFactory)
       {
          DbFactory= dbFactory;
       }
       

      public async Task<SemenAnalysis> AddSemenAnalysisAsync(SemenAnalysis semenanalysis)
       {
          await Conn.InsertAsync(semenanalysis);
          semenanalysis.SerialNo =Conn.LastInsertId();
          return semenanalysis;
       
       }
       
      public async Task<List<SemenAnalysis>> GetAllSemenAnalysisAsync()
       {
         return await Conn.SelectAsync<SemenAnalysis>();
       
       }
       
      public async Task<SemenAnalysis> FindSemenAnalysisAsync(long id)
       {
         return await Conn.SingleByIdAsync<SemenAnalysis>(id);
       
       }
       
      public async Task<SemenAnalysis> UpdateSemenAnalysisAsync(SemenAnalysis semenanalysis)
       {
          await Conn.UpdateAsync<SemenAnalysis>(semenanalysis);
          return semenanalysis;
       
       }
       
      public async Task RemoveSemenAnalysisAsync(long id)
       {
         await Conn.DeleteByIdAsync<SemenAnalysis>(id);
       
       }
       
      public async Task<SemenAnalysis> GetSemenAnalysisWithChildrenAsync(long id)
       {
          var semenanalysis = await Conn.SingleByIdAsync<SemenAnalysis>(id);
          
          
          
   
                 // One To One 
           var patient = await Conn.SingleAsync<Patient>(e => e.PatientID == id);
           if (semenanalysis != null && patient != null)
           {
             semenanalysis.Patient = patient;
           }
         
  
         return semenanalysis;
         }
       
       
      public async Task<SemenAnalysis> SaveSemenAnalysisAsync(SemenAnalysis semenanalysis)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(semenanalysis.IsNew)
                {
                   await AddSemenAnalysisAsync(semenanalysis);
                }
                else
                {
                   await UpdateSemenAnalysisAsync(semenanalysis);
                }
                
                
                    
                 // One To One 
                 if(semenanalysis.Patient!=null)
                 {
                    if(semenanalysis.Patient.IsDeleted)
                    {
                      var id = semenanalysis.Patient.PatientID;
                      await Conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if(!semenanalysis.Patient.IsDeleted)
                    {
                      var patient = semenanalysis.Patient;
                      patient.PatientID = semenanalysis.SerialNo;
                      await Conn.SaveAsync(patient);
                    }
                    
                  }
                 
                   
                    txScope.Complete();
            }
            return semenanalysis;
       
       }
       
      public async Task<List<SemenAnalysis>> QueryAsync(string query)
      {
        var result = await Conn.SelectAsync<SemenAnalysis>(query);
        return result;
      }
      public IDbConnection Custom { get { return Conn; }  }
       
       public void Dispose()
       {
          if (Conn != null)
              Conn.Dispose();
       }
   
    }
    
    public class DesignSemenAnalysesRepository : ISemenAnalysesRepository
    {
      public Task<SemenAnalysis> AddSemenAnalysisAsync(SemenAnalysis semenanalysis)
      {
         return null;
      }
      public async Task<List<SemenAnalysis>> GetAllSemenAnalysisAsync()
      {
            var resultList = new List<SemenAnalysis>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new SemenAnalysis
                {
                    
                  SerialNo = i+12345, 
                  PatientID = i+12345, 
                  TDate =  DateTime.Now, 
                  Colour =  "Colour"+i, 
                  Quantity =  "Quantity"+i, 
                  Ph =  "Ph"+i, 
                  TimeOfCollection =  "TimeOfCollection"+i, 
                  TimeOfExamination =  "TimeOfExamination"+i, 
                  TotalCount =  "TotalCount"+i, 
                  ActiveMotility =  "ActiveMotility"+i, 
                  Sluggish =  "Sluggish"+i, 
                  NonMotile =  "NonMotile"+i, 
                  Abnormal =  "Abnormal"+i, 
                  PusCells =  "PusCells"+i, 
                  Rbc =  "Rbc"+i, 
                  EpithelialCell =  "EpithelialCell"+i, 
                  Fee = i+12345, 
                });
            }
            return resultList;
      }
      public async Task<SemenAnalysis> FindSemenAnalysisAsync(long id)
      {
         return new SemenAnalysis
                {
                    
                    SerialNo =  12345,
                    PatientID =  12345,
                    TDate =  DateTime.Now,
                    Colour =  "Colour",
                    Quantity =  "Quantity",
                    Ph =  "Ph",
                    TimeOfCollection =  "TimeOfCollection",
                    TimeOfExamination =  "TimeOfExamination",
                    TotalCount =  "TotalCount",
                    ActiveMotility =  "ActiveMotility",
                    Sluggish =  "Sluggish",
                    NonMotile =  "NonMotile",
                    Abnormal =  "Abnormal",
                    PusCells =  "PusCells",
                    Rbc =  "Rbc",
                    EpithelialCell =  "EpithelialCell",
                    Fee =  12345,
                };
      }
      public async Task<SemenAnalysis> UpdateSemenAnalysisAsync(SemenAnalysis semenanalysis)
      {
        return null;
      }
      public async Task RemoveSemenAnalysisAsync(long id)
      {
        
      }
       
      public async Task<SemenAnalysis> GetSemenAnalysisWithChildrenAsync(long id)
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

         
        return new SemenAnalysis
                {
                    
                    SerialNo = 12345,
                    PatientID = 12345,
                    TDate =  DateTime.Now,
                    Colour =  "Colour",
                    Quantity =  "Quantity",
                    Ph =  "Ph",
                    TimeOfCollection =  "TimeOfCollection",
                    TimeOfExamination =  "TimeOfExamination",
                    TotalCount =  "TotalCount",
                    ActiveMotility =  "ActiveMotility",
                    Sluggish =  "Sluggish",
                    NonMotile =  "NonMotile",
                    Abnormal =  "Abnormal",
                    PusCells =  "PusCells",
                    Rbc =  "Rbc",
                    EpithelialCell =  "EpithelialCell",
                    Fee = 12345,
                    
                     //One to One
                     Patient = patient,
                     
                };
         
      }
      public async Task<SemenAnalysis> SaveSemenAnalysisAsync(SemenAnalysis semenanalysis)
      {
        return null;
      }
      public async Task<List<SemenAnalysis>> QueryAsync(string query)
      {
         return null;
      }
      public IDbConnection Custom { get { return null;}  }
    }
    
    
    
    
    
    
    
    
}