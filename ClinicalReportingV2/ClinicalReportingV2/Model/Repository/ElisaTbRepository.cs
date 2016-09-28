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

    public interface IElisaTbsRepository
    {
       Task<ElisaTb> AddElisaTbAsync(ElisaTb elisatb);
       Task<List< ElisaTb>> GetAllElisaTbAsync();
       Task<ElisaTb> FindElisaTbAsync(long id);
       Task<ElisaTb> UpdateElisaTbAsync(ElisaTb elisatb);
       Task RemoveElisaTbAsync(long id); 
       Task<ElisaTb> GetElisaTbWithChildrenAsync(long id);
       Task<ElisaTb> SaveElisaTbAsync(ElisaTb elisatb);
       Task<List<ElisaTb>> QueryAsync(string query);
       
       ElisaTb AddElisaTb(ElisaTb elisatb);
       List< ElisaTb> GetAllElisaTb();
       ElisaTb FindElisaTb(long id);
       ElisaTb UpdateElisaTb(ElisaTb elisatb);
       void RemoveElisaTb(long id); 
       ElisaTb GetWithChildren(long id);
       ElisaTb SaveElisaTb(ElisaTb elisatb);
       List< ElisaTb> Query(string query);
       
       IDbConnection Custom { get;  }
    }

#endregion

#region Original Repository
        


                                                            

    public class ElisaTbRepository : IElisaTbsRepository,IDisposable
    { 
      
      
       private IDbConnectionFactory DbFactory { get; set; }
      
       private IDbConnection _conn;
       private IDbConnection Conn 
       { 
           get { return _conn ?? (_conn = DbFactory.Open()); }
       }
       
       public ElisaTbRepository(IDbConnectionFactory dbFactory)
       {
          DbFactory= dbFactory;
       }
       
       
       public ElisaTb AddElisaTb(ElisaTb elisatb)
       {
          this.Conn.Insert(elisatb);
          elisatb.SerialNo =this.Conn.LastInsertId();
          return elisatb;
       
       }
       
      public List<ElisaTb> GetAllElisaTb()
       {
         return Conn.Select<ElisaTb>();
       
       }
       
      public ElisaTb FindElisaTb(long id)
       {
         return Conn.SingleById<ElisaTb>(id);
       
       }
       
      public ElisaTb UpdateElisaTb(ElisaTb elisatb)
       {
          var result=Conn.Update<ElisaTb>(elisatb);
          return elisatb;
       
       }
       
      public void RemoveElisaTb(long id)
       {
          Conn.DeleteById<ElisaTb>(id);
       
       }
       
      public ElisaTb GetWithChildren(long id)
       {
          var elisatb = Conn.SingleById<ElisaTb>(id);
          
          
          
   
                 // One To One 
           var patient = Conn.Select<Patient>().Where(a => a.PatientID == id).SingleOrDefault();
           if (elisatb != null && patient != null)
           {
             elisatb.Patient = patient;
           }
         
  
         return elisatb;
         }
       
       
      public ElisaTb SaveElisaTb(ElisaTb elisatb)
      {
          using(var txScope= new TransactionScope())
            {
                if(elisatb.IsNew)
                {
                    this.AddElisaTb(elisatb);
                }
                else
                {
                    this.UpdateElisaTb(elisatb);
                }
                
                
                    
                    
                 // One To One 
                 if(elisatb.Patient !=null)
                 {
                    var patient = elisatb.Patient;
                    patient.PatientID = elisatb.SerialNo;
                    Conn.Save(patient);
                 }
                 
                   
                    txScope.Complete();
            }
            return elisatb;
       
       }
       
       public List< ElisaTb> Query(string query)
       {
          return Conn.Select<ElisaTb>(query);
       }
       
 #endregion
 
 
#region Asyn Methods
                                                               
                                                               
       
       
       

      public async Task<ElisaTb> AddElisaTbAsync(ElisaTb elisatb)
       {
          await Conn.InsertAsync(elisatb);
          elisatb.SerialNo =Conn.LastInsertId();
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
          await Conn.UpdateAsync<ElisaTb>(elisatb);
          return elisatb;
       
       }
       
      public async Task RemoveElisaTbAsync(long id)
       {
         await Conn.DeleteByIdAsync<ElisaTb>(id);
       
       }
       
      public async Task<ElisaTb> GetElisaTbWithChildrenAsync(long id)
       {
          var elisatb = await Conn.SingleByIdAsync<ElisaTb>(id);
          
          
          
   
                 // One To One 
           var patient = await Conn.SingleAsync<Patient>(e => e.PatientID == id);
           if (elisatb != null && patient != null)
           {
             elisatb.Patient = patient;
           }
         
  
         return elisatb;
         }
       
       
      public async Task<ElisaTb> SaveElisaTbAsync(ElisaTb elisatb)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(elisatb.IsNew)
                {
                   await AddElisaTbAsync(elisatb);
                }
                else
                {
                   await UpdateElisaTbAsync(elisatb);
                }
                
                
                    
                 // One To One 
                 if(elisatb.Patient!=null)
                 {
                    if(elisatb.Patient.IsDeleted)
                    {
                      var id = elisatb.Patient.PatientID;
                      await Conn.DeleteByIdAsync<Patient>(id);
                    }
                    else if(!elisatb.Patient.IsDeleted)
                    {
                      var patient = elisatb.Patient;
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
        return await Conn.SelectAsync<ElisaTb>(query);
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
    
    public class DesignElisaTbsRepository : IElisaTbsRepository
    {
    
    
       public ElisaTb AddElisaTb(ElisaTb elisatb)
       {
          return null;
       }
       public List< ElisaTb> GetAllElisaTb()
       {
           var resultList = new List<ElisaTb>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new ElisaTb
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
       public  ElisaTb FindElisaTb(long id)
       {
             return new ElisaTb
                {
                    
                    SerialNo =  12345,
                    PatientID =  12345,
                    TDate =  DateTime.Now,
                    PatientValue =  12345,
                    CutOffValue =  12345,
                    Fee =  12345,
                };
       }
       public ElisaTb UpdateElisaTb(ElisaTb elisatb)
       {
         return null;
       }
       public void RemoveElisaTb(long id)
       {
          return;
       
       }
       public ElisaTb GetWithChildren(long id)
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

         
        return new ElisaTb
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
       public ElisaTb SaveElisaTb(ElisaTb elisatb)
       {
         return null;
       }
       public List< ElisaTb> Query(string query)
       {
          var resultList = new List<ElisaTb>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new ElisaTb
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
      public async Task<ElisaTb> FindElisaTbAsync(long id)
      {
         return new ElisaTb
                {
                    
                    SerialNo =  12345,
                    PatientID =  12345,
                    TDate =  DateTime.Now,
                    PatientValue =  12345,
                    CutOffValue =  12345,
                    Fee =  12345,
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
                Name =  "Name", 
                Age =  "Age", 
                Sex =  "Sex", 
                RefBy =  "RefBy", 
        };

         
        return new ElisaTb
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
      public async Task<ElisaTb> SaveElisaTbAsync(ElisaTb elisatb)
      {
        return null;
      }
      public async Task<List<ElisaTb>> QueryAsync(string query)
      {
         var resultList = new List<ElisaTb>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new ElisaTb
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