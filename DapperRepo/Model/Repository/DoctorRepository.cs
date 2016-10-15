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

    public interface IDoctorsRepository
    {
       Task<Doctor> AddDoctorAsync(Doctor doctor);
       Task<List< Doctor>> GetAllDoctorAsync();
       Task<Doctor> FindDoctorAsync(long id);
       Task<Doctor> UpdateDoctorAsync(Doctor doctor);
       Task RemoveDoctorAsync(long id); 
       
       Task<Doctor> GetDoctorWithChildrenAsync(long id);
       Task<Doctor> SaveDoctorAsync(Doctor doctor);
       Task<List<Doctor>> QueryAsync(string query);
       IDbConnection Custom { get;  }
    }


    public class DoctorRepository : IDoctorsRepository,IDisposable
    { 
      
      
       private IDbConnectionFactory DbFactory { get; set; }
      
       private IDbConnection _conn;
       private IDbConnection Conn 
       { 
           get { return _conn ?? (_conn = DbFactory.Open()); }
       }
       
       public DoctorRepository(IDbConnectionFactory dbFactory)
       {
          DbFactory= dbFactory;
       }
       

      public async Task<Doctor> AddDoctorAsync(Doctor doctor)
       {
          await Conn.InsertAsync(doctor);
          doctor.DoctorID =Conn.LastInsertId();
          return doctor;
       
       }
       
      public async Task<List<Doctor>> GetAllDoctorAsync()
       {
         return await Conn.SelectAsync<Doctor>();
       
       }
       
      public async Task<Doctor> FindDoctorAsync(long id)
       {
         return await Conn.SingleByIdAsync<Doctor>(id);
       
       }
       
      public async Task<Doctor> UpdateDoctorAsync(Doctor doctor)
       {
          await Conn.UpdateAsync<Doctor>(doctor);
          return doctor;
       
       }
       
      public async Task RemoveDoctorAsync(long id)
       {
         await Conn.DeleteByIdAsync<Doctor>(id);
       
       }
       
      public async Task<Doctor> GetDoctorWithChildrenAsync(long id)
       {
          var doctor = await Conn.SingleByIdAsync<Doctor>(id);
          
          
          
  
         return doctor;
         }
       
       
      public async Task<Doctor> SaveDoctorAsync(Doctor doctor)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(doctor.IsNew)
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
       
      public async Task<List<Doctor>> QueryAsync(string query)
      {
        var result = await Conn.SelectAsync<Doctor>(query);
        return result;
      }
      public IDbConnection Custom { get { return Conn; }  }
       
       public void Dispose()
       {
          if (Conn != null)
              Conn.Dispose();
       }
   
    }
    
    public class DesignDoctorsRepository : IDoctorsRepository
    {
      public Task<Doctor> AddDoctorAsync(Doctor doctor)
      {
         return null;
      }
      public async Task<List<Doctor>> GetAllDoctorAsync()
      {
            var resultList = new List<Doctor>();
            for (int i = 0; i < 10; i++)
            {
                resultList.Add(new Doctor
                {
                    
                  DoctorID = i+12345, 
                  DoctorName =  "DoctorName"+i, 
                });
            }
            return resultList;
      }
      public async Task<Doctor> FindDoctorAsync(long id)
      {
         return new Doctor
                {
                    
                    DoctorID =  12345,
                    DoctorName =  "DoctorName",
                };
      }
      public async Task<Doctor> UpdateDoctorAsync(Doctor doctor)
      {
        return null;
      }
      public async Task RemoveDoctorAsync(long id)
      {
        
      }
       
      public async Task<Doctor> GetDoctorWithChildrenAsync(long id)
      {
         
        return new Doctor
                {
                    
                    DoctorID = 12345,
                    DoctorName =  "DoctorName",
                    
                     
                };
         
      }
      public async Task<Doctor> SaveDoctorAsync(Doctor doctor)
      {
        return null;
      }
      public async Task<List<Doctor>> QueryAsync(string query)
      {
         return null;
      }
      public IDbConnection Custom { get { return null;}  }
    }
    
    
    
    
    
    
    
    
}