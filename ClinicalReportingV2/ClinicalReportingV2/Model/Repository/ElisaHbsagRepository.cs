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

    public interface IElisaHbsagsRepository
    {
       Task<ElisaHbsag> AddElisaHbsagAsync(ElisaHbsag elisahbsag);
       Task<List< ElisaHbsag>> GetAllElisaHbsagAsync();
       Task<ElisaHbsag> FindElisaHbsagAsync(long id);
       Task<ElisaHbsag> UpdateElisaHbsagAsync(ElisaHbsag elisahbsag);
       Task RemoveElisaHbsagAsync(long id); 
       Task<ElisaHbsag> GetElisaHbsagWithChildrenAsync(long id);
       Task<ElisaHbsag> SaveElisaHbsagAsync(ElisaHbsag elisahbsag);
       Task<List<ElisaHbsag>> QueryAsync(string query);
       
       ElisaHbsag AddElisaHbsag(ElisaHbsag elisahbsag);
       List< ElisaHbsag> GetAllElisaHbsag();
       ElisaHbsag FindElisaHbsag(long id);
       ElisaHbsag UpdateElisaHbsag(ElisaHbsag elisahbsag);
       void RemoveElisaHbsag(long id); 
       ElisaHbsag GetWithChildren(long id);
       ElisaHbsag SaveElisaHbsag(ElisaHbsag elisahbsag);
       List< ElisaHbsag> Query(string query);
       
       IDbConnection Custom { get;  }
    }

#endregion

#region Original Repository
        


                                                            

    public class ElisaHbsagRepository : IElisaHbsagsRepository,IDisposable
    { 
      
      
       private IDbConnectionFactory DbFactory { get; set; }
      
       private IDbConnection _conn;
       private IDbConnection Conn 
       { 
           get { return _conn ?? (_conn = DbFactory.Open()); }
       }
       
       public ElisaHbsagRepository(IDbConnectionFactory dbFactory)
       {
          DbFactory= dbFactory;
       }
       
       
       public ElisaHbsag AddElisaHbsag(ElisaHbsag elisahbsag)
       {
          this.Conn.Insert(elisahbsag);
          elisahbsag.SerialNo =this.Conn.LastInsertId();
          return elisahbsag;
       
       }
       
      public List<ElisaHbsag> GetAllElisaHbsag()
       {
         return Conn.Select<ElisaHbsag>();
       
       }
       
      public ElisaHbsag FindElisaHbsag(long id)
       {
         return Conn.SingleById<ElisaHbsag>(id);
       
       }
       
      public ElisaHbsag UpdateElisaHbsag(ElisaHbsag elisahbsag)
       {
          var result=Conn.Update<ElisaHbsag>(elisahbsag);
          return elisahbsag;
       
       }
       
      public void RemoveElisaHbsag(long id)
       {
          Conn.DeleteById<ElisaHbsag>(id);
       
       }
       
      public ElisaHbsag GetWithChildren(long id)
       {
          var elisahbsag = Conn.SingleById<ElisaHbsag>(id);
          
          
          
   
                 // One To One 
           var patient = Conn.Select<Patient>().Where(a => a.PatientID == id).SingleOrDefault();
           if (elisahbsag != null && patient != null)
           {
             elisahbsag.Patient = patient;
           }
         
  
         return elisahbsag;
         }
       
       
      public ElisaHbsag SaveElisaHbsag(ElisaHbsag elisahbsag)
      {
          using(var txScope= new TransactionScope())
            {
                if(elisahbsag.IsNew)
                {
                    this.AddElisaHbsag(elisahbsag);
                }
                else
                {
                    this.UpdateElisaHbsag(elisahbsag);
                }
                
                
                    
                    
                 // One To One 
                 if(elisahbsag.Patient !=null)
                 {
                    var patient = elisahbsag.Patient;
                    patient.PatientID = elisahbsag.SerialNo;
                    Conn.Save(patient);
                 }
                 
                   
                    txScope.Complete();
            }
            return elisahbsag;
       
       }
       
       public List< ElisaHbsag> Query(string query)
       {
          return Conn.Select<ElisaHbsag>(query);
       }
       
 #endregion
 
 
#region Asyn Methods
                                                               
                                                               
       
       
       

      public async Task<ElisaHbsag> AddElisaHbsagAsync(ElisaHbsag elisahbsag)
       {
          await Conn.InsertAsync(elisahbsag);
          elisahbsag.SerialNo =Conn.LastInsertId();
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
          await Conn.UpdateAsync<ElisaHbsag>(elisahbsag);
          return elisahbsag;
       
       }
       
      public async Task RemoveElisaHbsagAsync(long id)
       {
         await Conn.DeleteByIdAsync<ElisaHbsag>(id);
       
       }
       
      public async Task<ElisaHbsag> GetElisaHbsagWithChildrenAsync(long id)
       {
          var elisahbsag = await Conn.SingleByIdAsync<ElisaHbsag>(id);
          
          
          
   
                 // One To One 
           var patient = await Conn.SingleAsync<Patient>(e => e.PatientID == id);
           if (elisahbsag != null && patient != null)
           {
             elisahbsag.Patient = patient;
           }
         
  
         return elisahbsag;
         }
       
       
      public async Task<ElisaHbsag> SaveElisaHbsagAsync(ElisaHbsag elisahbsag)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(elisahbsag.IsNew)
                {
                   await AddElisaHbsagAsync(elisahbsag);
                }
                else
                {
                   await UpdateElisaHbsagAsync(elisahbsag);
                }
                
                
                    
                 // One To One 
                 if(elisahbsag.Patient!=null)
                 {
                    if(elisahbsag.Patient.IsDeleted)
                    {
                      var id = elisahbsag.Patient.PatientID;
                      await Conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if(!elisahbsag.Patient.IsDeleted)
                    {
                      var patient = elisahbsag.Patient;
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
        return await Conn.SelectAsync<ElisaHbsag>(query);
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
    
    public class DesignElisaHbsagsRepository : IElisaHbsagsRepository
    {
    
    
       public ElisaHbsag AddElisaHbsag(ElisaHbsag elisahbsag)
       {
          return null;
       }
       public List< ElisaHbsag> GetAllElisaHbsag()
       {
           var resultList = new List<ElisaHbsag>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new ElisaHbsag
                {
                    
                  SerialNo = i+12345, 
                  PatientID = i+12345, 
                  TDate =  DateTime.Now, 
                  PatientValue = i+12345, 
                  CutOffValue = i+12345, 
                  Fee = i+12345, 
                });
            }
            return resultList;
         
       }
       public  ElisaHbsag FindElisaHbsag(long id)
       {
             return new ElisaHbsag
                {
                    
                    SerialNo =  12345,
                    PatientID =  12345,
                    TDate =  DateTime.Now,
                    PatientValue =  12345,
                    CutOffValue =  12345,
                    Fee =  12345,
                };
       }
       public ElisaHbsag UpdateElisaHbsag(ElisaHbsag elisahbsag)
       {
         return null;
       }
       public void RemoveElisaHbsag(long id)
       {
          return;
       
       }
       public ElisaHbsag GetWithChildren(long id)
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

         
        return new ElisaHbsag
                {
                    
                    SerialNo = 12345,
                    PatientID = 12345,
                    TDate =  DateTime.Now,
                    PatientValue = 12345,
                    CutOffValue = 12345,
                    Fee = 12345,
                    
                     //One to One
                     Patient = patient,
                     
                };
         
       }
       public ElisaHbsag SaveElisaHbsag(ElisaHbsag elisahbsag)
       {
         return null;
       }
       public List< ElisaHbsag> Query(string query)
       {
          var resultList = new List<ElisaHbsag>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new ElisaHbsag
                {
                    
                  SerialNo = i+12345, 
                  PatientID = i+12345, 
                  TDate =  DateTime.Now, 
                  PatientValue = i+12345, 
                  CutOffValue = i+12345, 
                  Fee = i+12345, 
                });
            }
            return resultList;
       }
    
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
                    
                  SerialNo = i+12345, 
                  PatientID = i+12345, 
                  TDate =  DateTime.Now, 
                  PatientValue = i+12345, 
                  CutOffValue = i+12345, 
                  Fee = i+12345, 
                });
            }
            return resultList;
      }
      public async Task<ElisaHbsag> FindElisaHbsagAsync(long id)
      {
         return new ElisaHbsag
                {
                    
                    SerialNo =  12345,
                    PatientID =  12345,
                    TDate =  DateTime.Now,
                    PatientValue =  12345,
                    CutOffValue =  12345,
                    Fee =  12345,
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
                Name =  "Name", 
                Age =  "Age", 
                Sex =  "Sex", 
                RefBy =  "RefBy", 
        };

         
        return new ElisaHbsag
                {
                    
                    SerialNo = 12345,
                    PatientID = 12345,
                    TDate =  DateTime.Now,
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
         var resultList = new List<ElisaHbsag>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new ElisaHbsag
                {
                    
                  SerialNo = i+12345, 
                  PatientID = i+12345, 
                  TDate =  DateTime.Now, 
                  PatientValue = i+12345, 
                  CutOffValue = i+12345, 
                  Fee = i+12345, 
                });
            }
            return resultList;
      }
      public IDbConnection Custom { get { return null;}  }
    }
    
#endregion    
    
    
    
    
    
    
}