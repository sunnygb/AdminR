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



#region Interface

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
       
       SemenAnalysis AddSemenAnalysis(SemenAnalysis semenanalysis);
       List< SemenAnalysis> GetAllSemenAnalysis();
       SemenAnalysis FindSemenAnalysis(long id);
       SemenAnalysis UpdateSemenAnalysis(SemenAnalysis semenanalysis);
       void RemoveSemenAnalysis(long id); 
       SemenAnalysis GetWithChildren(long id);
       SemenAnalysis SaveSemenAnalysis(SemenAnalysis semenanalysis);
       List< SemenAnalysis> Query(string query);
       
       IDbConnection Custom { get;  }
    }

#endregion

#region Original Repository
        


                                                            

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
       
       
       public SemenAnalysis AddSemenAnalysis(SemenAnalysis semenanalysis)
       {
          this.Conn.Insert(semenanalysis);
          semenanalysis.SerialNo =this.Conn.LastInsertId();
          return semenanalysis;
       
       }
       
      public List<SemenAnalysis> GetAllSemenAnalysis()
       {
         return Conn.Select<SemenAnalysis>();
       
       }
       
      public SemenAnalysis FindSemenAnalysis(long id)
       {
         return Conn.SingleById<SemenAnalysis>(id);
       
       }
       
      public SemenAnalysis UpdateSemenAnalysis(SemenAnalysis semenanalysis)
       {
          var result=Conn.Update<SemenAnalysis>(semenanalysis);
          return semenanalysis;
       
       }
       
      public void RemoveSemenAnalysis(long id)
       {
          Conn.DeleteById<SemenAnalysis>(id);
       
       }
       
      public SemenAnalysis GetWithChildren(long id)
       {
          var semenanalysis = Conn.SingleById<SemenAnalysis>(id);
          
          
          
   
                 // One To One 
           var patient = Conn.Select<Patient>().Where(a => a.PatientID == id).SingleOrDefault();
           if (semenanalysis != null && patient != null)
           {
             semenanalysis.Patient = patient;
           }
         
  
         return semenanalysis;
         }
       
       
      public SemenAnalysis SaveSemenAnalysis(SemenAnalysis semenanalysis)
      {
          using(var txScope= new TransactionScope())
            {
                if(semenanalysis.IsNew)
                {
                    this.AddSemenAnalysis(semenanalysis);
                }
                else
                {
                    this.UpdateSemenAnalysis(semenanalysis);
                }
                
                
                    
                    
                 // One To One 
                 if(semenanalysis.Patient !=null)
                 {
                    var patient = semenanalysis.Patient;
                    patient.PatientID = semenanalysis.SerialNo;
                    Conn.Save(patient);
                 }
                 
                   
                    txScope.Complete();
            }
            return semenanalysis;
       
       }
       
       public List< SemenAnalysis> Query(string query)
       {
          return Conn.Select<SemenAnalysis>(query);
       }
       
 #endregion
 
 
#region Asyn Methods
                                                               
                                                               
       
       
       

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
        return await Conn.SelectAsync<SemenAnalysis>(query);
      }
      
      
       #endregion
       
       
       
#region Design Repository
       


      public IDbConnection Custom { get { return Conn; }  }
       
       public void Dispose()
       {
          if (Conn != null)
              Conn.Dispose();
       }
   
    }
    
    public class DesignSemenAnalysesRepository : ISemenAnalysesRepository
    {
    
    
       public SemenAnalysis AddSemenAnalysis(SemenAnalysis semenanalysis)
       {
          return null;
       }
       public List< SemenAnalysis> GetAllSemenAnalysis()
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
       public  SemenAnalysis FindSemenAnalysis(long id)
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
       public SemenAnalysis UpdateSemenAnalysis(SemenAnalysis semenanalysis)
       {
         return null;
       }
       public void RemoveSemenAnalysis(long id)
       {
          return;
       
       }
       public SemenAnalysis GetWithChildren(long id)
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
       public SemenAnalysis SaveSemenAnalysis(SemenAnalysis semenanalysis)
       {
         return null;
       }
       public List< SemenAnalysis> Query(string query)
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
      public IDbConnection Custom { get { return null;}  }
    }
    
#endregion    
    
    
    
    
    
    
}