using AdmissionAndResult.Data.Services;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Transactions;

namespace AdmissionAndResult.Data.Repository
{    
    public class QualificationRepository : IQualificationsRepository,IDisposable
    { 
      
      
       public IDbConnectionFactory DbFactory { get; set; }
      
       private IDbConnection _conn;
       private IDbConnection conn 
       { 
          get 
          {
            return _conn = _conn ??  DbFactory.Open();
          }
       }

      public async Task<Qualification> AddQualificationAsync(Qualification qualification)
       {
          await this.conn.InsertAsync(qualification);
          qualification.QualificationId =this.conn.LastInsertId();
          return qualification;
       
       }
       
      public async Task<List<Qualification>> GetAllQualificationAsync()
       {
         return await this.conn.SelectAsync<Qualification>();
       
       }
       
      public async Task<Qualification> FindQualificationAsync(long id)
       {
         return await this.conn.SingleByIdAsync<Qualification>(id);
       
       }
       
      public async Task<Qualification> UpdateQualificationAsync(Qualification qualification)
       {
          var result= await this.conn.UpdateAsync<Qualification>(qualification);
          return qualification;
       
       }
       
      public async Task RemoveQualificationAsync(long id)
       {
         await this.conn.DeleteByIdAsync<Qualification>(id);
       
       }
       
      public async Task<Qualification> GetQualificationWithChildrenAsync(long id)
       {
          var qualification = await this.conn.SingleByIdAsync<Qualification>(id);
          
          
          
   
                 // One To One 
           var student = await this.conn.SingleAsync<Student>(a => a.Where(e => e.StudentId == id));
           if (qualification != null && student != null)
           {
             qualification.Student = student;
           }
         
  
         return qualification;
         }
       
       
      public async Task<Qualification> SaveQualificationAsync(Qualification qualification)
      {
          using(var txScope= new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if(qualification.IsNew)
                {
                   await this.AddQualificationAsync(qualification);
                }
                else
                {
                   await this.UpdateQualificationAsync(qualification);
                }
                
                
                    
                    
                 // One To One 
                 if(qualification.Student!=null)
                 {
                    if(qualification.Student.IsDeleted)
                    {
                      var id = qualification.Student.StudentId;
                      await this._conn.DeleteByIdAsync<Student>(id);
                    }
                    else if(!qualification.Student.IsDeleted)
                    {
                      var student = qualification.Student;
                      student.StudentId = qualification.QualificationId;
                      await this.conn.SaveAsync(student);
                    }
                    
                  }
                 
                   
                    txScope.Complete();
            }
            return qualification;
       
       }
       
       public void Dispose()
       {
          if (_conn != null)
              _conn.Dispose();
       }
   
    }
}